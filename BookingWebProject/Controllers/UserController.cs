namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Core.Contracts;
    using Infrastructure.Data.Models;
    using Extensions;
    using Core.Models.User;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;

    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public UserController(IUserService userService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Personalization(Guid id)
        {
            if (id != this.User.GetId())
            {
                return Unauthorized();
            }
            try
            {
                UserInfoViewModel userInfoViewModel = await userService.GetUserInfoByIdAsync(id);
                return View(userInfoViewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
