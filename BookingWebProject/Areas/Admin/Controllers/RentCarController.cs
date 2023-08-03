namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.RentCar.Data_Models;
    using Contracts;
    using static BookingWebProject.Common.NotificationKeys;
    using static BookingWebProject.Common.NotificationMessages;
    using BookingWebProject.Core.Models.Pager;

    public class RentCarController : BaseAdminController
    {
        private readonly IRentCarAdminService rentCarAdminService;
        public RentCarController(IRentCarAdminService rentCarAdminService)
        {
            this.rentCarAdminService = rentCarAdminService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int pg = 1)
        {

            if (pg <= 0)
            {
                pg = 1;
            }
            int totalCarsCount = await rentCarAdminService.GetAllCarsCountAsync();
            Pager pager = new Pager(totalCarsCount, pg);
            RentCarAdminDataModel model = new RentCarAdminDataModel()
            {
                Pager = pager,
                Cars = await rentCarAdminService.GetAllCarsAsync(pager)

            };
            return View(model);
        }
    }
}
