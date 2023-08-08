namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Contracts;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    using BookingWebProject.Areas.Admin.Models.User;

    public class HomeController : BaseAdminController
    {
        private readonly IUserAdminService userAdminService;
        private readonly IAdminService adminService;
        private readonly IMemoryCache memoryCache;
        public HomeController(IUserAdminService userAdminService, IAdminService adminService,
            IMemoryCache memoryCache)
        {
            this.userAdminService = userAdminService;
            this.adminService = adminService;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                HomeAdminPageViewModel homeAdminPageViewModel = this.memoryCache.Get<HomeAdminPageViewModel>(AdminDashBoardCacheKey);
                if (homeAdminPageViewModel == null)
                {
                    homeAdminPageViewModel = await adminService.GetStatisticsInfoAsync();
                    MemoryCacheEntryOptions memoryCacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(AdminDashBoardCacheDuration));
                    this.memoryCache.Set(AdminDashBoardCacheKey, homeAdminPageViewModel, memoryCacheOptions);
                }
                IEnumerable<AllUsersViewModel> allUsers = this.memoryCache.Get<IEnumerable<AllUsersViewModel>>(AdminUsersCacheKey);
                if (allUsers == null)
                {
                    allUsers = await userAdminService.GetAllUsersAsync();
                    MemoryCacheEntryOptions memoryCacheOptions = new MemoryCacheEntryOptions()
                       .SetAbsoluteExpiration(TimeSpan.FromMinutes(AdminUsersDuration));
                    this.memoryCache.Set(AdminUsersCacheKey, allUsers, memoryCacheOptions);
                }
                homeAdminPageViewModel.AllUsers = allUsers;
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
