namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Models.Benefits;
    using Contracts;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    public class HotelBenefitController : BaseAdminController
    {
        private readonly IBenefitAdminService benefitAdminService;
        public HotelBenefitController(IBenefitAdminService benefitAdminService)
        {
            this.benefitAdminService = benefitAdminService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<BenefitViewModel> allHotelBenefits = await benefitAdminService.GetAllHotelBenefitsAsync();
            return View(allHotelBenefits);
        }
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
    }
}
