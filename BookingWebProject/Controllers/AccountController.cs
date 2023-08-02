namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Infrastructure.Data.Models;
    using Core.Models.Account;
    using static Common.GeneralAplicationConstants;

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
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
        public IActionResult Login()
        {
            return View(new LoginViewModel());
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
                }
            }
            else
            {
                if (await userManager.IsInRoleAsync(userToFind, ModeratorRoleName))
                {
                    await userManager.RemoveFromRoleAsync(userToFind, ModeratorRoleName);
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
