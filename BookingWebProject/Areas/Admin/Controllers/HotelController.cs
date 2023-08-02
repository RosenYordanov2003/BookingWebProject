namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Contracts;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    using BookingWebProject.Areas.Admin.Models.Hotel;

    public class HotelController : BaseAdminController
    {
        private readonly IHotelAdminService hotelAdminService;
        public HotelController(IHotelAdminService hotelAdminService)
        {
            this.hotelAdminService = hotelAdminService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<HotelAllViewModel> allHotels = await hotelAdminService.GetAllHotelsAsync();
                return View(allHotels);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
    }
}
