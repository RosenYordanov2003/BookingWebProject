namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.RentCar.Data_Models;
    using Contracts;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    using Core.Models.Pager;
    using BookingWebProject.Areas.Admin.Models.RentCar;
    using BookingWebProject.Areas.Admin.Models.Hotel;

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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await rentCarAdminService.IsCarExistByIdAsync(id))
            {
                return NotFound();
            }
            try
            {
                EditRentCarViewModel carToEdit = await rentCarAdminService.GetRentCarToEditAsync(id);
                return View(carToEdit);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRentCarViewModel editRentCarViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editRentCarViewModel);
            }
            if (!await rentCarAdminService.IsCarExistByIdAsync(id))
            {
                return NotFound();
            }
            try
            {
                await rentCarAdminService.EditCarAsync(id, editRentCarViewModel);
                TempData[SuccessMessage] = SuccessfullyEditedCar;
                return RedirectToAction("Index", "RentCar", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
    }
}
