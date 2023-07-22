namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Extensions;
    using Core.Contracts;
    using Core.Models.Reservation;
    using static BookingWebProject.Common.NotificationKeys;
    using static BookingWebProject.Common.NotificationMessages;
    using Microsoft.AspNetCore.Cors.Infrastructure;

    public class ReservationController : Controller
    {
        private readonly IRentCarService rentCarService;
        private readonly IUserService userService;
        private readonly IReservationService reservationService;
        public ReservationController(IRentCarService rentCarService, IUserService userService, IReservationService reservationService)
        {
            this.rentCarService = rentCarService;
            this.userService = userService;
            this.reservationService = reservationService;
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
        [HttpPost]
        public async Task<IActionResult> RentCar(int id, RentCarReservationViewModel model)
        {
            model.User.Id = User.GetId();
            model.CarlViewModel = await rentCarService.GetOrderCarAsync(id);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!await rentCarService.IsCarExistAsync(id))
            {
                TempData[ErrorMessage] = CarDoesNotExist;
                return NotFound();
            }
            if (await reservationService.CheckCarIsAlreadyReservedAsync(id, model.StartRentDate, model.EndRentDate))
            {
                TempData[WarningMessage] = string.Format(CarIsAlreadyRentedInThisPeriodMsg, model.StartRentDate.ToString("dd/MM/yyyy"), model.EndRentDate.ToString("dd/MM/yyyy"));
                return View(model);
            }
            try
            {
                await reservationService.RentCarAsync(id, model);
                TempData[SuccessMessage] = string.Format(SuccessfullRentCarMsg, model.StartRentDate.ToString("dd/MM/yyyy"), model.EndRentDate.ToString("dd/MM/yyyy"));
                return RedirectToAction("All", "RentCar");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
