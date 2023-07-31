namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Extensions;
    using Core.Contracts;
    using Core.Models.Reservation;
    using Core.Models.Room;
    using Core.Models.RoomPackage;
    using static BookingWebProject.Common.NotificationKeys;
    using static BookingWebProject.Common.NotificationMessages;
    using System.ComponentModel.DataAnnotations;

    public class ReservationController : Controller
    {
        private readonly IRentCarService rentCarService;
        private readonly IUserService userService;
        private readonly IReservationService reservationService;
        private readonly IPackageService packageService;
        private readonly IRoomService roomService;
        public ReservationController(IRentCarService rentCarService, IUserService userService,
            IReservationService reservationService, IPackageService packageService
            ,IRoomService roomService)
        {
            this.rentCarService = rentCarService;
            this.userService = userService;
            this.reservationService = reservationService;
            this.packageService = packageService;
            this.roomService = roomService;
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
        [HttpGet]
        public async Task<IActionResult> BookRoom(RoomOrderInfoViewModel room)
        {
            if (!await roomService.IsRoomExistAsync(room.Id))
            {
                return NotFound();
            }
            try
            {
                RoomPackageViewModel roomSelectedPackage = await packageService.GetPackageByIdAsync(room.PackageId);
                RoomReservationViewModel roomToReserve = new RoomReservationViewModel()
                {
                    User = await userService.GetUserByIdAsync(this.User.GetId()),
                    Room = await roomService.GetRoomToBookAsync(room, roomSelectedPackage)
                };

                return View(roomToReserve);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> BookRoom(RoomReservationViewModel roomReservationViewModel)
        {
            var validationResults = roomReservationViewModel.Validate(new ValidationContext(roomReservationViewModel));
            roomReservationViewModel.User.Id = this.User.GetId();
            if (!ModelState.IsValid || validationResults.Any())
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    foreach (string memberName in validationResult.MemberNames)
                    {
                        ModelState.AddModelError(memberName, validationResult.ErrorMessage);
                    }
                }
                return View(roomReservationViewModel);
            }
            if (!await reservationService.IsThereAvalilableRoomAsync(roomReservationViewModel.Room.HotelId, roomReservationViewModel.Room.Name, roomReservationViewModel.StartDate, roomReservationViewModel.EndDate))
            {
                TempData[WarningMessage] = NoAvalilableRoom;
                return View(roomReservationViewModel);
            }
            try
            {
                await reservationService.BookRoomAsync(roomReservationViewModel, this.User.GetId());
                TempData[SuccessMessage] = SuccessBookedRoom;
                //Should change the redirect
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
