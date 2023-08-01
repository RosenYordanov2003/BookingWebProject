namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Contracts;
    using static BookingWebProject.Common.NotificationKeys;
    using static BookingWebProject.Common.NotificationMessages;

    public class HomeController : BaseAdminController
    {
        private readonly IUserAdminService userAdminService;
        private readonly IAdminService adminService;
        public HomeController(IUserAdminService userAdminService, IAdminService adminService)
        {
            this.userAdminService = userAdminService;
            this.adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                HomeAdminPageViewModel homeAdminPageViewModel = await adminService.GetStatisticsInfoAsync();

                homeAdminPageViewModel.AllUsers = await userAdminService.GetAllUsersAsync();
                return View(homeAdminPageViewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
