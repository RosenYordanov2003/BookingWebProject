namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Contracts;
    using Models.RoomPackage;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;

    public class RoomPackageController : BaseAdminController
    {
        private readonly IRoomPackageAdminService roomPackageAdminService;
        private readonly IMemoryCache memoryCache;
        public RoomPackageController(IRoomPackageAdminService roomPackageAdminService, IMemoryCache memoryCache)
        {
            this.roomPackageAdminService = roomPackageAdminService;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<RoomPackageAdminViewModel> roomPackages = this.memoryCache.Get<IEnumerable<RoomPackageAdminViewModel>>(AdminRoomPackagesCacheKey);
            if (roomPackages == null)
            {
                roomPackages = await roomPackageAdminService.GetAllRoomPackagesAsync();
                MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(AdminRoomPackagesCacheDuration));
                this.memoryCache.Set(AdminRoomPackagesCacheKey, roomPackages, memoryCacheEntryOptions);
            }
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
                this.memoryCache.Remove(RoomPackageCacheKey);
                this.memoryCache.Remove(AdminRoomPackagesCacheKey);
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
                this.memoryCache.Remove(RoomPackageCacheKey);
                this.memoryCache.Remove(AdminRoomPackagesCacheKey);
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
                this.memoryCache.Remove(RoomPackageCacheKey);
                this.memoryCache.Remove(AdminRoomPackagesCacheKey);
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
                await roomPackageAdminService.CreateRoomPackageAsync(roomPackage);
                TempData[SuccessMessage] = SuccessfullyCreateRoomPackage;
                this.memoryCache.Remove(RoomPackageCacheKey);
                this.memoryCache.Remove(AdminRoomPackagesCacheKey);
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
