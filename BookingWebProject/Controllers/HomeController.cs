namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Identity;
    using System.Diagnostics;
    using Core.Contracts;
    using Core.Models.Hotel;
    using Infrastructure.Data.Models;
    using Models;
    using Extensions;
    using Data;
    using static Common.GeneralAplicationConstants;

    public class HomeController : Controller
    {
        private readonly IMemoryCache memoryCache;
        private readonly IHotelService hotelService;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly BookingContext bookingContext;
        public HomeController(IHotelService hotelService, IMemoryCache memoryCache, UserManager<User> userManager,
             RoleManager<IdentityRole<Guid>> roleManager, BookingContext bookingContext)
        {
            this.hotelService = hotelService;
            this.memoryCache = memoryCache;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.bookingContext = bookingContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (this.User?.Identity?.IsAuthenticated ?? false)
            {
                if (this.User.IsInRole(AdminRoleName) || this.User.IsInRole(ModeratorRoleName))
                {
                    return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
                }
                else
                {
                    if (!await roleManager.RoleExistsAsync(UserRoleName))
                    {
                        IdentityRole<Guid> userRole = new IdentityRole<Guid>(UserRoleName);
                        await roleManager.CreateAsync(userRole);
                    }
                    if (!this.User.IsInRole(UserRoleName))
                    {
                        User userToFind = await userManager.FindByIdAsync(this.User.GetId().ToString());
                        await userManager.AddToRoleAsync(userToFind, UserRoleName);
                        await bookingContext.SaveChangesAsync();
                    }
                }
            }
            IEnumerable<HotelCardViewModel> hotels = memoryCache.Get<IEnumerable<HotelCardViewModel>>(HomePageCacheKey);
            if (hotels == null)
            {
                hotels = await hotelService.GetTopHotelsAsync();
                MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(HomePageCacheDurationMinuties));

                this.memoryCache.Set(HomePageCacheKey, hotels, memoryCacheEntryOptions);
            }
            return View(hotels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}