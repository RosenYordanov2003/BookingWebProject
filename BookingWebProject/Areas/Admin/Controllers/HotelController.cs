﻿namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Contracts;
    using Models.Hotel;
    using Core.Contracts;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;

    public class HotelController : BaseAdminController
    {
        private readonly IHotelAdminService hotelAdminService;
        private readonly IHotelService hotelService;
        public HotelController(IHotelAdminService hotelAdminService, IHotelService hotelService)
        {
            this.hotelService = hotelService;
            this.hotelAdminService = hotelAdminService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<HotelAllViewModel> allHotels = await hotelAdminService.GetAllHotelsAsync();
                return View(allHotels);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int hotelId)
        {
            if (!await hotelService.CheckIsHotelExistAsync(hotelId))
            {
                return NotFound();
            }
            try
            {
                if (await hotelAdminService.CheckIfHotelIsAlredyDeletedAsync(hotelId))
                {
                    TempData[WarningMessage] = HotelIsAlreadyDeleted;
                }
                else
                {
                    await hotelAdminService.DeleteHotelByIdAsync(hotelId);
                    TempData[SuccessMessage] = SuccessfullyDeletedHotel;
                }
                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Recover([FromForm] int hotelId)
        {
            if (!await hotelAdminService.CheckIsHotelForRecoverExistByIdAsync(hotelId))
            {
                return NotFound();
            }
            try
            {
                await hotelAdminService.RecoverHotelByIdAsync(hotelId);
                TempData[SuccessMessage] = SuccessfullyRecoveredHotel;

                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await hotelService.CheckIsHotelExistAsync(id) && !await hotelAdminService.CheckIsHotelForRecoverExistByIdAsync(id))
            {
                return NotFound();
            }
            try
            {
                EditHotelViewModel editHotelViewModel = await hotelAdminService.GetHotelToEditAsync(id);

                return View(editHotelViewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditHotelViewModel editHotelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editHotelViewModel);
            }
            if (!await hotelService.CheckIsHotelExistAsync(id) && !await hotelAdminService.CheckIsHotelForRecoverExistByIdAsync(id))
            {
                return NotFound();
            }
            try
            {
                await hotelAdminService.EditHotelByIdAsync(id, editHotelViewModel);
                TempData[SuccessMessage] = SuccesfullyEditedHotel;
                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveHotelBenefit([FromForm] int benefitId, int hotelId)
        {
            try
            {
                if (!await hotelAdminService.CheckIsHotelBenefitExistAsync(benefitId, hotelId))
                {
                    return NotFound();
                }
                if (!await hotelAdminService.CheckIsHotelBenefitIsAlreadyDeletedAsync(benefitId, hotelId))
                {
                    TempData[WarningMessage] = HotelBenefitIsAlreadyDeleted;
                    return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
                }
                await hotelAdminService.DeleteHotelBenefitAsync(benefitId, hotelId);
                TempData[SuccessMessage] = SuccessfullyDeleteHotelBenefit;

                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> RecoverBenefit([FromForm] int benefitId, int hotelId)
        {
            try
            {
                if (!await hotelAdminService.CheckIsHotelBenefitExistAsync(benefitId, hotelId))
                {
                    return NotFound();
                }
                if (await hotelAdminService.CheckIsHotelBenefitIsAlreadyRecovoredAsync(benefitId, hotelId))
                {
                    TempData[WarningMessage] = HotelBenefitIsAlreadyRecovored;
                    return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
                }
                await hotelAdminService.RecoverHotelBenefitAsync(benefitId, hotelId);
                TempData[SuccessMessage] = SuccessfullyRecoverHotelBenefit;

                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
    }
}
