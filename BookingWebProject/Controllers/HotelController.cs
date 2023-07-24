namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
