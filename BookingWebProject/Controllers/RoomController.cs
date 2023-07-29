namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using Core.Models.Room;

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
    }
}
