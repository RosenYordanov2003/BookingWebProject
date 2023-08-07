namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    using Contracts;
    using Models.RoomBasis;
    using BookingWebProject.Areas.Admin.Models.Benefit;

    public class RoomBasisController : BaseAdminController
    {
        private readonly IRoomBasisService roomBasisService;
        public RoomBasisController(IRoomBasisService roomBasisService)
        {
            this.roomBasisService = roomBasisService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<RoomBasisAdminViewModel> allRoomBasis = await roomBasisService.GetAllRoomBasisAsync();
            return View(allRoomBasis);
        }
        [HttpPost]
        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                if (!await roomBasisService.CheckIfRoomBasisExistByIdAsync(id))
                {
                    return NotFound();
                }
                if (await roomBasisService.CheckIfRoomBasisIsAlreadyDeletedByIdAsync(id))
                {
                    TempData[WarningMessage] = RoomBasisIsAlreadyDeleted;
                    return RedirectToAction(nameof(Index));
                }
                await roomBasisService.DeleteRoomBasisByIdAsync(id);
                TempData[SuccessMessage] = SuccessfullyRemoveRoomBasis;
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
                if (!await roomBasisService.CheckIfRoomBasisExistByIdAsync(id))
                {
                    return NotFound();
                }
                if (await roomBasisService.CheckIfRoomBasisIsAlreadyRecoveredAsync(id))
                {
                    TempData[WarningMessage] = RoomBasisIsAlreadyRecovered;
                    return RedirectToAction(nameof(Index));
                }
                await roomBasisService.RecoverRoomBasisByIdAsync(id);
                TempData[SuccessMessage] = SuccessfullyRecoveredRoomBasis;
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
                if (!await roomBasisService.CheckIfRoomBasisExistByIdAsync(id))
                {
                    return NotFound();
                }
                EditRoomBasisViewModel editRoomBasisViewModel = await roomBasisService.GetRoomBasisToEditByIdAsync(id);
                return View(editRoomBasisViewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Edit(int id, EditRoomBasisViewModel editRoomBasisViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editRoomBasisViewModel);
            }
            try
            {
                if (!await roomBasisService.CheckIfRoomBasisExistByIdAsync(id))
                {
                    return NotFound();
                }
                await roomBasisService.EditRoomBasisAsync(id, editRoomBasisViewModel);
                TempData[SuccessMessage] = SuccessfullyEditRoomBasis;
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
        public async Task<IActionResult>Create(EditRoomBasisViewModel roomBasis)
        {
            if (!ModelState.IsValid)
            {
                return View(roomBasis);
            }
            try
            {
                await roomBasisService.CreateRoomBasisAsync(roomBasis);
                TempData[SuccessMessage] = SuccessfullyCreateRoomBasis;
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
