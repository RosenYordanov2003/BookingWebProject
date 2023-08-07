namespace BookingWebProject.Areas.Admin.Controllers
{
    using Models.RoomType;
    using Contracts;
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    public class RoomTypeController : BaseAdminController
    {
        private readonly IRoomTypeService roomTypeService;
        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            this.roomTypeService = roomTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<RoomTypeAdminViewModel> roomTypes = await roomTypeService.GetAllRomTypes();
                return View(roomTypes);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                if (!await roomTypeService.CheckIfRoomTypeExistByIdAsync(id))
                {
                    return NotFound();
                }
                if (await roomTypeService.CheckIfRoomTypeIsAlreadyDeletedByIdAsync(id))
                {
                    TempData[WarningMessage] = RoomTypeIsAlreadyDeleted;
                    return RedirectToAction(nameof(Index));
                }
                await roomTypeService.DeleteRoomTypeAsync(id);
                TempData[SuccessMessage] = SuccessfullyDeleteRoomType;
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
                if (!await roomTypeService.CheckIfRoomTypeExistByIdAsync(id))
                {
                    return NotFound();
                }
                if (await roomTypeService.CheckIfRoomTypeIsAlreadyRecoveredByIdAsync(id))
                {
                    TempData[WarningMessage] = RoomTypeIsAlreadyRecovered;
                    return RedirectToAction(nameof(Index));
                }
                await roomTypeService.RecoverRoomTypeAsync(id);
                TempData[SuccessMessage] = SuccessfullyRecoveredRoomType;
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
                if (!await roomTypeService.CheckIfRoomTypeExistByIdAsync(id))
                {
                    return NotFound();
                }
                EditRoomTypeViewModel editRoomTypeViewModel = await roomTypeService.GetRoomTypeToEditAsync(id);
                return View(editRoomTypeViewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult>Edit(int id, EditRoomTypeViewModel editRoomTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editRoomTypeViewModel);
            }
            try
            {
                await roomTypeService.EditRoomTypeAsync(id, editRoomTypeViewModel);
                TempData[SuccessMessage] = SuccessfullyEditRoomType;
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
        public async Task<IActionResult>Create(EditRoomTypeViewModel editRoomTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editRoomTypeViewModel);
            }
            try
            {
                await roomTypeService.CreateRoomTypeAsync(editRoomTypeViewModel);
                TempData[SuccessMessage] = SuccessfullyCreateRoomType;
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
