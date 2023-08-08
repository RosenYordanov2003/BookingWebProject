﻿namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Contracts;
    using Models.RoomPackage;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    using Microsoft.Win32;

    public class RoomPackageController : BaseAdminController
    {
        private readonly IRoomPackageAdminService roomPackageAdminService;
        public RoomPackageController(IRoomPackageAdminService roomPackageAdminService)
        {
            this.roomPackageAdminService = roomPackageAdminService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<RoomPackageAdminViewModel> roomPackages = await roomPackageAdminService.GetAllRoomPackagesAsync();
            return View(roomPackages);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!await roomPackageAdminService.CheckIfPakcageExistsByIdAsync(id))
                {
                    return NotFound();
                }
                if (await roomPackageAdminService.CheckIfRoomPackageIsAlreadyDeletedByIdAsync(id))
                {
                    TempData[WarningMessage] = RoomPackageIsAlreadyDeleted;
                    return RedirectToAction(nameof(Index));
                }
                await roomPackageAdminService.DeleteRoomPackageAsync(id);
                TempData[SuccessMessage] = SuccessfullyDeleteRoomPackage;
                return RedirectToAction(nameof(Index));
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
            try
            {
                if (!await roomPackageAdminService.CheckIfPakcageExistsByIdAsync(id))
                {
                    return NotFound();
                }
                if (await roomPackageAdminService.CheckIfRoomPackageIsAlreadyRecoveredByIdAsync(id))
                {
                    TempData[WarningMessage] = RoomPackageIsAlreadyRecovered;
                    return RedirectToAction(nameof(Index));
                }
                await roomPackageAdminService.RecoverRoomPackageByIdAsync(id);
                TempData[SuccessMessage] = SuccessfullyRecoverRoomPackage;
                return RedirectToAction(nameof(Index));
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
            try
            {
                if (!await roomPackageAdminService.CheckIfPakcageExistsByIdAsync(id))
                {
                    return NotFound();
                }
                EditRoomPackageViewModel editRoomPackageViewModel = await roomPackageAdminService.GetRoomPackageToEditByIdAsync(id);
                return View(editRoomPackageViewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Edit(int id, EditRoomPackageViewModel editRoomPackageViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editRoomPackageViewModel);
            }
            try
            {
                await roomPackageAdminService.EditRoomPackageAsync(id, editRoomPackageViewModel);
                TempData[SuccessMessage] = SuccessfullyEditRoomPackage;
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
        public async Task<IActionResult> Create(EditRoomPackageViewModel roomPackage)
        {
            if (!ModelState.IsValid)
            {
                return View(roomPackage);
            }
            try
            {

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
    }
}
