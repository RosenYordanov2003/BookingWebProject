namespace BookingWebProject.Controllers
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using Core.Contracts;
    using Core.Models.Room;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    using BookingWebProject.Core.Models.RoomPackage;

    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly IPackageService packageService;
        private readonly IMemoryCache memoryCache;
        public RoomController(IRoomService roomService, IPackageService packageService,
            IMemoryCache memoryCache)
        {
            this.roomService = roomService;
            this.packageService = packageService;
            this.memoryCache = memoryCache;
        }
        [HttpGet]
        public async Task<IActionResult> HotelRooms(int id)
        {
            string cacheKey = string.Format(HotelRoomsCacheKey, id);
            IEnumerable<RoomViewModel> hotelRooms = this.memoryCache.Get<IEnumerable<RoomViewModel>>(cacheKey);
            if (hotelRooms == null)
            {
                hotelRooms = await roomService.GetHotelRooms(id);
                MemoryCacheEntryOptions opt = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(HotelRoomsCacheDuration));
                this.memoryCache.Set(cacheKey, hotelRooms, opt);
            }
            hotelRooms = hotelRooms.DistinctBy(hr => hr.RoomType);
            return View(hotelRooms);
        }
        [HttpGet]
        public async Task<IActionResult> RoomOrder(int id)
        {
            if (!await roomService.IsRoomExistAsync(id))
            {
                return NotFound();
            }
            try
            {

                RoomOrderInfoViewModel room = await roomService.GetORderRoomInfoAsync(id);
                IEnumerable<RoomPackageViewModel> roomPackages = memoryCache.Get<IEnumerable<RoomPackageViewModel>>(RoomPackageCacheKey);
                if (roomPackages == null)
                {
                    roomPackages = await packageService.GetAllPackagesAsync();
                    MemoryCacheEntryOptions opt = new MemoryCacheEntryOptions().
                    SetAbsoluteExpiration(TimeSpan.FromMinutes(RoomPackageCacheDuration));
                    this.memoryCache.Set(RoomPackageCacheKey, roomPackages, opt);
                }
                room.Packages = roomPackages;
                return View(room);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> RoomOrder(RoomOrderInfoViewModel roomOrderInfoViewModel)
        {
            var validationResults = roomOrderInfoViewModel.Validate(new ValidationContext(roomOrderInfoViewModel));
            if (!ModelState.IsValid || validationResults.Any())
            {
                RoomOrderInfoViewModel model = await roomService.GetORderRoomInfoAsync(roomOrderInfoViewModel.Id);
                model.Packages = await packageService.GetAllPackagesAsync();
                model.AdultsCount = roomOrderInfoViewModel.AdultsCount;
                model.ChildrenCount = roomOrderInfoViewModel.ChildrenCount;
                model.PackageId = roomOrderInfoViewModel.PackageId;

                foreach (ValidationResult validationResult in validationResults)
                {
                    foreach (string memberName in validationResult.MemberNames)
                    {
                        ModelState.AddModelError(memberName, validationResult.ErrorMessage);
                    }
                }

                return View(model);
            }
            return RedirectToAction("BookRoom", "Reservation", roomOrderInfoViewModel);
        }
    }
}
