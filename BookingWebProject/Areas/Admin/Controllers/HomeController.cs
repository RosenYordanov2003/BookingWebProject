namespace BookingWebProject.Areas.Admin.Controllers
{
    using BookingWebProject.Areas.Admin.Models.User;
    using Contracts;
    using Microsoft.AspNetCore.Mvc;

    using static BookingWebProject.Common.NotificationKeys;
    using static BookingWebProject.Common.NotificationMessages;

    public class HomeController : BaseAdminController
    {
        private readonly IUserAdminService userAdminService;
        public HomeController(IUserAdminService userAdminService)
        {
            this.userAdminService = userAdminService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<AllUsersViewModel> allUsers = await userAdminService.GetAllUsersAsync();
                return View(allUsers);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
