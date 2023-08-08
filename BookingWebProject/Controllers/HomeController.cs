namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using System.Diagnostics;
    using Core.Contracts;
    using Core.Models.Hotel;
    using Models;
    using static Common.GeneralAplicationConstants;

    public class HomeController : Controller
    {
        private readonly IMemoryCache memoryCache;
        private readonly IHotelService hotelService;
        public HomeController(IHotelService hotelService, IMemoryCache memoryCache)
        {
            this.hotelService = hotelService;
            this.memoryCache = memoryCache;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName) || this.User.IsInRole(ModeratorRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
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