namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Core.Contracts;
    using Core.Models.Hotel;
    using Core.Models.Pager;
    using Core.Models.Benefits;
    using Extensions;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;

    [Authorize]
    public class HotelController : Controller
    {
        private readonly IBenefitService benefitService;
        private readonly IHotelService hotelService;
        private readonly IMemoryCache memoryCache;
        public HotelController(IBenefitService benefitService, IHotelService hotelService,
            IMemoryCache memoryCache)
        {
            this.benefitService = benefitService;
            this.hotelService = hotelService;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] HotelQueryViewModel hotelQueryViewModel)
        {
            if (hotelQueryViewModel.CurrentPage < 1)
            {
                hotelQueryViewModel.CurrentPage = 1;
            }

            Guid userId = User.GetId();
            Pager pager = new Pager(await hotelService.GetCountAsync(hotelQueryViewModel), hotelQueryViewModel.CurrentPage);
            hotelQueryViewModel.Pager = pager;
            AllHotelsSortedAndFilteredDataModel sortedHotels = await hotelService.GetAllHotelsSortedAndFilteredAsync(userId, hotelQueryViewModel);
            hotelQueryViewModel.HotelViewModels = sortedHotels.Hotels;
            IEnumerable<BenefitViewModel> benefits = this.memoryCache.Get<IEnumerable<BenefitViewModel>>(HotelBenefitsCacheKey);
            if (benefits == null)
            {
                benefits = await benefitService.GetAllBenefitsAsync();
                MemoryCacheEntryOptions opt = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(HotelBenefitsCacheDuration));
                this.memoryCache.Set(HotelBenefitsCacheKey, benefits, opt);
            }
            IEnumerable<string> cities = this.memoryCache.Get<IEnumerable<string>>(HotelCitisCacheKey);
            if (cities == null)
            {
                cities = await hotelService.GetAllHotelCitiesAsync();
                MemoryCacheEntryOptions opt = new MemoryCacheEntryOptions()
                   .SetAbsoluteExpiration(TimeSpan.FromMinutes(HotelCitiesDuration));
                this.memoryCache.Set(HotelCitisCacheKey, cities, opt);
            }
            IEnumerable<string> countries = this.memoryCache.Get<IEnumerable<string>>(HotelCountriesCacheKey);
            if (countries == null)
            {
                countries = await hotelService.GetAllHotelCountriesAsync();
                MemoryCacheEntryOptions opt = new MemoryCacheEntryOptions()
                   .SetAbsoluteExpiration(TimeSpan.FromMinutes(HotelCountriesDuration));
                this.memoryCache.Set(HotelCountriesCacheKey, countries, opt);
            }
            hotelQueryViewModel.Benefits = benefits;
            hotelQueryViewModel.Countries = countries;
            hotelQueryViewModel.Cities = cities;

            return View(hotelQueryViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddToFavorite(int id)
        {
            if (!await hotelService.CheckIsHotelExistAsync(id))
            {
                TempData[ErrorMessage] = HotelDoesNotExist;
                return RedirectToAction(nameof(All));
            }
            try
            {
                await hotelService.AddHotelToUserFavoriteHotels(id, User.GetId());
                TempData[SuccessMessage] = SuccessfullyAddHotelToUserFavorites;
                this.memoryCache.Remove(string.Format(UserFavoriteHotelsCacheKey, this.User.GetId()));
                return Ok();
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction(nameof(All));
            }

        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorite(int id)
        {
            try
            {
                if (!await hotelService.CheckIsHotelExistAsync(id))
                {
                    TempData[ErrorMessage] = HotelDoesNotExist;
                    return RedirectToAction(nameof(All));
                }
                await hotelService.RemoveHotelFromUserFavoriteHotels(id, User.GetId());
                TempData[SuccessMessage] = SuccessfullyRemoveHotelFromUserFavoriteHotels;
                this.memoryCache.Remove(string.Format(UserFavoriteHotelsCacheKey, this.User.GetId()));
                return NoContent();
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction(nameof(All));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Info(int id, int pg = 1)
        {
            if (pg <= 0)
            {
                pg = 1;
            }
            try
            {
                int hotelCommentsCount = await hotelService.GetHotelCommentsCountAsync(id);
                Pager pager = new Pager(hotelCommentsCount, pg);
                if (!await hotelService.CheckIsHotelExistAsync(id))
                {
                    TempData[ErrorMessage] = HotelDoesNotExist;
                    return RedirectToAction(nameof(All));
                }
                HotelInfoViewModel hotel = await hotelService.GetHotelByIdAsync(id, pager);
                hotel.CommentsPager = pager;
                return View(hotel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction(nameof(All));
            }
        }
    }
}
