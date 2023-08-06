namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Models.Benefits;
    using Contracts;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    using BookingWebProject.Areas.Admin.Models.Benefit;

    public class HotelBenefitController : BaseAdminController
    {
        private readonly IBenefitAdminService benefitAdminService;

        public HotelBenefitController(IBenefitAdminService benefitAdminService)
        {
            this.benefitAdminService = benefitAdminService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<BenefitViewModel> allHotelBenefits = await benefitAdminService.GetAllHotelBenefitsAsync();
            return View(allHotelBenefits);
        }
        [HttpPost]
        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                if (!await benefitAdminService.CheckIfBenefitExistByIdAsync(id))
                {
                    return NotFound();
                }
                if (await benefitAdminService.CheckIfBenefitIsAlreadyDeletedAsync(id))
                {
                    TempData[WarningMessage] = BenefitIsAlreadyDeleted;
                    return RedirectToAction(nameof(Index));
                }
                await benefitAdminService.DeleteBenefitAsync(id);
                TempData[SuccessMessage] = SuccessfullyDeleteHotelBenefit;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Recover(int id)
        {
            try
            {
                if (!await benefitAdminService.CheckIfBenefitExistByIdAsync(id))
                {
                    return NotFound();
                }
                if (await benefitAdminService.CheckIfBenefitIsAlreadyRecoveredByIdAsync(id))
                {
                    TempData[WarningMessage] = BenefitIsAlreaduRecovered;
                    return RedirectToAction(nameof(Index));
                }
                await benefitAdminService.RecoverBenefitAsync(id);
                TempData[SuccessMessage] = SuccessfullyRecoverHotelBenefit;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            try
            {
                if (!await benefitAdminService.CheckIfBenefitExistByIdAsync(id))
                {
                    return NotFound();
                }
                EditBenefitViewModel editBenefitViewModel = await benefitAdminService.GetBenefitToEditAsync(id);
                return View(editBenefitViewModel); 
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Edit(int id, EditBenefitViewModel editBenefitViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editBenefitViewModel);
            }
            try
            {
                if (!await benefitAdminService.CheckIfBenefitExistByIdAsync(id))
                {
                    return NotFound();
                }
                await benefitAdminService.EditBenefitByIdAsync(id, editBenefitViewModel);
                TempData[SuccessMessage] = SuccessfullyUpdateBenefit;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
    }
}
