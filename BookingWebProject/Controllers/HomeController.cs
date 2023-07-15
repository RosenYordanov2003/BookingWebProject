using BookingWebProject.Core.Contracts;
using BookingWebProject.Core.Models.Hotel;
using BookingWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookingWebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHotelService hotelService;
        public HomeController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        public async Task<IActionResult> Index()
        {
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