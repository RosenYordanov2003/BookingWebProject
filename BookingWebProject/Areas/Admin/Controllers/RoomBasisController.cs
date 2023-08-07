namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    using Contracts;
    using Models.RoomBasis;

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
    }
}
