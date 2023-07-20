namespace BookingWebProject.Controllers
{
    using Core.Models.Reservation;
    using Core.Contracts;
    using Microsoft.AspNetCore.Mvc;
    public class ReservationController : Controller
    {
        private readonly IRentCarService rentCarService;
        private readonly IUserService userService;
        public ReservationController(IRentCarService rentCarService, IUserService userService)
        {
            this.rentCarService = rentCarService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> RentCar(int id)
        {
            if (!await rentCarService.IsCarExistAsync(id))
            {
                return RedirectToAction("All", "Car");
            }
            RentCarReservationViewModel rentCarReservation = new RentCarReservationViewModel();
            rentCarReservation.CarlViewModel = await rentCarService.GetOrderCarAsync(id);
            rentCarReservation.User = await userService.GetUserByIdAsync(this.User.GetId());
            return View(rentCarReservation);
        }
    }
}
