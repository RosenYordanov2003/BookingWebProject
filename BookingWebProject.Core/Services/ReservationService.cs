namespace BookingWebProject.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.Data.Models;
    using System.Net;
    using Data;
    using Contracts;
    using Core.Models.Reservation;

    public class ReservationService : IReservationService
    {
        private readonly BookingContext bookingContext;
        public ReservationService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<bool> CheckCarIsAlreadyReservedAsync(int carId, DateTime startDate, DateTime endDate)
        {

            RentCar carToFind = await bookingContext.RentCars
                .Include(rc => rc.Reservations)
                .FirstAsync(rc => rc.Id == carId);
            return carToFind.Reservations.Any(r =>
                      (r.StartDate <= startDate && r.EndDate >= startDate) ||
                     (r.StartDate <= endDate && r.EndDate >= endDate) ||
                     (r.StartDate >= startDate && r.EndDate <= endDate));
        }
        public async Task RentCarAsync(int carId, RentCarReservationViewModel model)
        {
            RentCar carToRent = await bookingContext.RentCars.FirstAsync(rc => rc.Id == carId);
            TimeSpan interval = model.EndRentDate.Subtract(model.StartRentDate);
            int countDays = (int)interval.TotalDays;
            Reservation reservation = new Reservation()
            {
                UserId = model.User.Id,
                EmailAddress = WebUtility.HtmlEncode(model.User.Email),
                StartDate = model.StartRentDate,
                EndDate = model.EndRentDate,
                FirstName = WebUtility.HtmlEncode(model.User.FirstName),
                LastName = WebUtility.HtmlEncode(model.User.LastName),
                CountNights = countDays,
                RentCarId = carId,
                TotalPrice = model.CarlViewModel.PricePerDay * countDays,
                PeopleCount = 1,
            };
            await bookingContext.Reservations.AddAsync(reservation);
            await bookingContext.SaveChangesAsync();
        }
        public async Task<bool> IsThereAvalilableRoomAsync(int hotelId, string roomType, DateTime startDate, DateTime endDate)
        {
            ICollection<Room> roomsWithParticularType = await bookingContext
                  .Rooms.Where(r => r.RoomType.Name == roomType && r.HotelId == hotelId && 
                  !r.IsDeleted && !r.RoomType.IsDeleted && !r.Hotel.IsDeleted)
                  .Include(r => r.Reservations)
                  .ToArrayAsync();
            bool isAvailable = false;
            foreach (Room room in roomsWithParticularType)
            {
                if (!room.Reservations.Any(r =>
                    (r.StartDate <= startDate && r.EndDate >= startDate) ||
                   (r.StartDate <= endDate && r.EndDate >= endDate) ||
                   (r.StartDate >= startDate && r.EndDate <= endDate)))
                {
                    isAvailable = true;
                    break;
                }
            }
            return isAvailable;
        }
        public async Task BookRoomAsync(RoomReservationViewModel roomReservation, Guid userId)
        {
            int roomId = await GetRoomId(roomReservation.Room.HotelId, roomReservation.Room.Name, roomReservation.StartDate, roomReservation.EndDate);
            TimeSpan interval = roomReservation.EndDate.Subtract(roomReservation.StartDate);
            int countDays = (int)interval.TotalDays;
            Reservation reservation = new Reservation()
            {
                UserId = userId,
                StartDate = roomReservation.StartDate,
                EndDate = roomReservation.EndDate,
                HotelId = roomReservation.Room.HotelId,
                RoomId = roomId,
                CountNights = countDays,
                TotalPrice = roomReservation.Room.Price * countDays,
                FirstName = WebUtility.HtmlEncode(roomReservation.User.FirstName),
                LastName = WebUtility.HtmlEncode(roomReservation.User.LastName),
                EmailAddress = WebUtility.HtmlEncode(roomReservation.User.Email),
                PeopleCount = roomReservation.Room.AdultsCount + roomReservation.Room.ChildrenCount,
                RoomPackageId = roomReservation.Room.SelectedPackage.Id

            };
            await bookingContext.Reservations.AddAsync(reservation);
            await bookingContext.SaveChangesAsync();
        }
        public async Task<bool> IsReservationExistAsync(Guid reservationId)
        {
            return await bookingContext.Reservations.AnyAsync(r => r.Id == reservationId);
        }
        public async Task<ReservationInfoViewModel> GetReservationByIdAsync(Guid reservationId)
        {
            Reservation reservationToFind = await bookingContext.Reservations
                 .Include(r => r.Hotel)
                 .Include(r => r.Room)
                 .ThenInclude(r => r.Pictures)
                 .Include(r => r.Room.RoomType)
                 .Include(r => r.RentCar)
                 .Include(r => r.RoomPackage)
                .FirstAsync(r => r.Id == reservationId);
            ReservationInfoViewModel reservationInfoViewModel = null;
            if (reservationToFind.RentCar == null)
            {
                reservationInfoViewModel = new ReservationInfoViewModel()
                {
                    ReservationId = reservationId,
                    PeopleCount = reservationToFind.PeopleCount,
                    StartDate = reservationToFind.StartDate,
                    EndDate = reservationToFind.EndDate,
                    HotelName = reservationToFind.Hotel.Name,
                    RoomName = reservationToFind.Room.RoomType.Name,
                    RoomPicture = reservationToFind.Room.Pictures.First().Path,
                    City = reservationToFind.Hotel.City,
                    Country = reservationToFind.Hotel.Country,
                    TotalPrice = reservationToFind.TotalPrice,
                    RoomPackage = reservationToFind?.RoomPackage?.Name ?? "Bed and Breakfast",
                    FirstName = reservationToFind.FirstName,
                    LastName = reservationToFind.LastName,

                };
                return reservationInfoViewModel;
            }
            reservationInfoViewModel = new ReservationInfoViewModel()
            {
                ReservationId = reservationId,
                PeopleCount = reservationToFind.PeopleCount,
                StartDate = reservationToFind.StartDate,
                EndDate = reservationToFind.EndDate,
                TotalPrice = reservationToFind.TotalPrice,
                City = reservationToFind.RentCar.Location,
                CarModel = reservationToFind.RentCar.ModelType,
                CarMakeType = reservationToFind.RentCar.MakeType,
                CarPicture = reservationToFind.RentCar.CarImg,
                Year = reservationToFind.RentCar.Year,
                TransimssionType = reservationToFind.RentCar.TransmissionType.ToString(),
                FirstName = reservationToFind.FirstName,
                LastName = reservationToFind.LastName,
            };
            return reservationInfoViewModel;
        }
        private async Task<int> GetRoomId(int hotelId, string roomType, DateTime startDate, DateTime endDate)
        {
            ICollection<Room> roomsWithParticularType = await bookingContext
                 .Rooms.Where(r => r.RoomType.Name == roomType && r.HotelId == hotelId)
                 .Include(r => r.Reservations)
                 .ToArrayAsync();
            int roomId = 0;
            foreach (Room room in roomsWithParticularType)
            {
                if (!room.Reservations.Any(r =>
                      (r.StartDate <= startDate && r.EndDate >= startDate) ||
                     (r.StartDate <= endDate && r.EndDate >= endDate) ||
                     (r.StartDate >= startDate && r.EndDate <= endDate)))
                {
                    roomId = room.Id;
                    break;
                }
            }
            return roomId;
        }

    }
}
