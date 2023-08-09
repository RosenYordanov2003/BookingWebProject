namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Contracts;
    using Models.RoomBasis;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;

    public class RoomBasisController : BaseAdminController
    {
        private readonly IRoomBasisService roomBasisService;
        private readonly IMemoryCache memoryCache;
        public RoomBasisController(IRoomBasisService roomBasisService, IMemoryCache memoryCache)
        {
            this.roomBasisService = roomBasisService;
            this.memoryCache = memoryCache;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<RoomBasisAdminViewModel> allRoomBasis = this.memoryCache.Get<IEnumerable<RoomBasisAdminViewModel>>(AdminRoomBasisCacheKey);
            if (allRoomBasis == null)
            {
                allRoomBasis = await roomBasisService.GetAllRoomBasisAsync();
                MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(AdminRoomBasisCacheDuration));
                this.memoryCache.Set(AdminRoomBasisCacheKey, allRoomBasis, memoryCacheEntryOptions);
            }
            return View(allRoomBasis);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
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
                this.memoryCache.Remove(AdminRoomBasisCacheKey);
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
                this.memoryCache.Remove(AdminRoomBasisCacheKey);
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
        public async Task<IActionResult> Edit(int id, EditRoomBasisViewModel editRoomBasisViewModel)
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
                this.memoryCache.Remove(AdminRoomBasisCacheKey);
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
        public async Task<IActionResult> Create(EditRoomBasisViewModel roomBasis)
        {
            if (!ModelState.IsValid)
            {
                return View(roomBasis);
            }
            try
            {
                await roomBasisService.CreateRoomBasisAsync(roomBasis);
                TempData[SuccessMessage] = SuccessfullyCreateRoomBasis;
                this.memoryCache.Remove(AdminRoomBasisCacheKey);
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
