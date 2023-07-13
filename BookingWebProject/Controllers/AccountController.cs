namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
