namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.RentCar;
    using Contracts;
    using static BookingWebProject.Common.NotificationKeys;
    using static BookingWebProject.Common.NotificationMessages;

    public class RentCarController : BaseAdminController
    {
        private readonly IRentCarAdminService rentCarAdminService;
        public RentCarController(IRentCarAdminService rentCarAdminService)
        {
            this.rentCarAdminService = rentCarAdminService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<RentCarAdminViewModel> cars = await rentCarAdminService.GetAllCarsAsync();
            return View(cars);
        }
    }
}
