namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Mvc;
    using Core.Models.Benefits;
    using Contracts;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    using Models.Benefit;

    public class HotelBenefitController : BaseAdminController
    {
        private readonly IBenefitAdminService benefitAdminService;
        private readonly IMemoryCache memoryCache;

        public HotelBenefitController(IBenefitAdminService benefitAdminService, IMemoryCache memoryCache)
        {
            this.benefitAdminService = benefitAdminService;
            this.memoryCache = memoryCache;
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
                this.memoryCache.Remove(HotelBenefitsCacheKey);
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
                this.memoryCache.Remove(HotelBenefitsCacheKey);
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
                this.memoryCache.Remove(HotelBenefitsCacheKey);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(EditBenefitViewModel editBenefitViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editBenefitViewModel);
            }
            try
            {
                await benefitAdminService.CreateBenefitAsync(editBenefitViewModel);
                TempData[SuccessMessage] = SuccessfullyCreateBenefit;
                this.memoryCache.Remove(HotelBenefitsCacheKey);
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
