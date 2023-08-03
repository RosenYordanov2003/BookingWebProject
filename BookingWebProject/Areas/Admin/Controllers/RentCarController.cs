namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.RentCar.Data_Models;
    using Contracts;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    using Core.Models.Pager;
    using Models.RentCar;

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
            try
            {
                if (!await rentCarAdminService.IsCarExistByIdAsync(id))
                {
                    return NotFound();
                }
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
            try
            {
                if (!await rentCarAdminService.IsCarExistByIdAsync(id))
                {
                    return NotFound();
                }
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
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!await rentCarAdminService.IsCarExistByIdAsync(id))
                {
                    return NotFound();
                }
                if (await rentCarAdminService.CheckCarIsAlreadyDeleted(id))
                {
                    TempData[WarningMessage] = CarIsAlreadyDeleted;
                    return RedirectToAction("Index", "RentCar", new { Area = AdminAreaName });
                }
                await rentCarAdminService.DeleteCarByIdAsync(id);
                TempData[SuccessMessage] = SuccessfulyDeleteCar;
                return RedirectToAction("Index", "RentCar", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Recover(int id)
        {
            if (!await rentCarAdminService.IsCarExistByIdAsync(id))
            {
                return NotFound();
            }
            try
            {
                if (await rentCarAdminService.CheckCarIsAlreadyRecoveredAsync(id))
                {
                    TempData[WarningMessage] = CarIsAlreadyRecovored;
                    return RedirectToAction("Index", "RentCar", new { Area = AdminAreaName });
                }
                await rentCarAdminService.RecoverCarByIdAsync(id);
                TempData[SuccessMessage] = SuccessfullyRecoverCar;
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
