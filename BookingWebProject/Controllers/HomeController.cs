namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using Core.Contracts;
    using Core.Models.Hotel;
    using Models;
    using static Common.GeneralAplicationConstants;
    public class HomeController : Controller
    {
        private readonly IHotelService hotelService;
        public HomeController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName) || this.User.IsInRole(ModeratorRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            IEnumerable<HotelCardViewModel> hotels = await hotelService.GetTopHotelsAsync();
            return View(hotels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}