namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static BookingWebProject.Common.NotificationKeys;
    using static BookingWebProject.Common.NotificationMessages;
    using Core.Contracts;
    using Core.Models.Hotel;
    using Core.Models.Pager;
    using Extensions;

    [Authorize]
    public class HotelController : Controller
    {
        private readonly IBenefitService benefitService;
        private readonly IHotelService hotelService;
        public HotelController(IBenefitService benefitService, IHotelService hotelService)
        {
            this.benefitService = benefitService;
            this.hotelService = hotelService;
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
            hotelQueryViewModel.Benefits = await benefitService.GetAllBenefitsAsync();
            hotelQueryViewModel.Cities = await hotelService.GetAllHotelCitiesAsync();
            hotelQueryViewModel.Countries = await hotelService.GetAllHotelCountriesAsync();
            return View(hotelQueryViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddToFavorite(int id)
        {
            if (!await hotelService.IsExist(id))
            {
                TempData[ErrorMessage] = HotelDoesNotExist;
                return RedirectToAction(nameof(All));
            }
            try
            {
                await hotelService.AddHotelToUserFavoriteHotels(id, User.GetId());
                TempData[SuccessMessage] = SuccessfullyAddHotelToUserFavorites;
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
            if (!await hotelService.IsExist(id))
            {
                TempData[ErrorMessage] = HotelDoesNotExist;
                return RedirectToAction(nameof(All));
            }
            try
            {
                await hotelService.RemoveHotelFromUserFavoriteHotels(id, User.GetId());
                TempData[SuccessMessage] = SuccessfullyRemoveHotelFromUserFavoriteHotels;
                return NoContent();
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction(nameof(All));
            }
        }
    }
}
