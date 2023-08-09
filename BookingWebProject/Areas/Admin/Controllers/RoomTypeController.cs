namespace BookingWebProject.Areas.Admin.Controllers
{
    using Models.RoomType;
    using Microsoft.Extensions.Caching.Memory;
    using Contracts;
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;

    public class RoomTypeController : BaseAdminController
    {
        private readonly IRoomTypeService roomTypeService;
        private readonly IMemoryCache memoryCache;
        public RoomTypeController(IRoomTypeService roomTypeService, IMemoryCache memoryCache)
        {
            this.roomTypeService = roomTypeService;
            this.memoryCache = memoryCache;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<RoomTypeAdminViewModel> roomTypes = this.memoryCache.Get<IEnumerable<RoomTypeAdminViewModel>>(AdminRoomTypesCacheKey);
                if (roomTypes == null)
                {
                    roomTypes = await roomTypeService.GetAllRomTypes();
                    MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(AdminRoomTypesCacheDuration));
                    this.memoryCache.Set(AdminRoomTypesCacheKey, roomTypes, memoryCacheEntryOptions);
                }
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
                this.memoryCache.Remove(AdminRoomTypesCacheKey);
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
                this.memoryCache.Remove(AdminRoomTypesCacheKey);
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
                this.memoryCache.Remove(AdminRoomTypesCacheKey);
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
                this.memoryCache.Remove(AdminRoomTypesCacheKey);
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
