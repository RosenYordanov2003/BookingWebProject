namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly IPackageService packageService;
        public RoomController(IRoomService roomService, IPackageService packageService)
        {
            this.roomService = roomService;
            this.packageService = packageService;
        }
    }
}
