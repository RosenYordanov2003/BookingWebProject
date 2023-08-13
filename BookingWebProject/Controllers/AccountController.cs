namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Identity;
    using Infrastructure.Data.Models;
    using Core.Models.Account;
    using Data;
    using static Common.GeneralAplicationConstants;

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly IMemoryCache memoryCache;
        //To save the changes on SeedUsers
        private readonly BookingContext bookingContext;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<IdentityRole<Guid>> roleManager, BookingContext bookingContext,
            IMemoryCache memoryCache)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.bookingContext = bookingContext;
            this.memoryCache = memoryCache;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var user = new User()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Username
            };
            var result = await userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                memoryCache.Remove(AdminUsersCacheKey);
                return RedirectToAction(nameof(Login));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(registerViewModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "")
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var user = await userManager.FindByNameAsync(loginViewModel.Username);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    if (!string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl) && Url.IsLocalUrl(loginViewModel.ReturnUrl))
                    {
                        return Redirect(loginViewModel.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(loginViewModel);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }


        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> ChangeRole(Guid id, string? role = null)
        {
            User userToFind = await userManager.FindByIdAsync(id.ToString());
            if (!string.IsNullOrWhiteSpace(role))
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    IdentityRole<Guid> newRole = new IdentityRole<Guid>(role);
                    await roleManager.CreateAsync(newRole);
                }
                if (!await userManager.IsInRoleAsync(userToFind, role))
                {
                    await userManager.AddToRoleAsync(userToFind, role);
                    //To save the changes on SeedUsers
                    await bookingContext.SaveChangesAsync();
                }
            }
            else
            {
                if (await userManager.IsInRoleAsync(userToFind, ModeratorRoleName))
                {
                    await userManager.RemoveFromRoleAsync(userToFind, ModeratorRoleName);
                    if (!await roleManager.RoleExistsAsync(UserRoleName))
                    {
                        IdentityRole<Guid> userRole = new IdentityRole<Guid>(UserRoleName);
                        await roleManager.CreateAsync(userRole);
                    }
                    if (!await userManager.IsInRoleAsync(userToFind, UserRoleName))
                    {
                        await userManager.AddToRoleAsync(userToFind, UserRoleName);
                    }
                    //To save the changes on SeedUsers
                    await bookingContext.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
        }
    }
}
