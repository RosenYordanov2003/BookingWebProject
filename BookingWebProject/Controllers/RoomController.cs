namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using Core.Contracts;
    using Core.Models.Room;
    using System.ComponentModel.DataAnnotations;

    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly IPackageService packageService;
        public RoomController(IRoomService roomService, IPackageService packageService)
        {
            this.roomService = roomService;
            this.packageService = packageService;
        }
        [HttpGet]
        public async Task<IActionResult> HotelRooms(int id)
        {
            IEnumerable<RoomViewModel> hotelRooms = await roomService.GetHotelRooms(id);
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
                room.Packages = await packageService.GetAllPackagesAsync();

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
