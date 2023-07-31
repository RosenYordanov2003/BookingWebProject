namespace BookingWebProject.Core.Contracts
{
    using Core.Models.Reservation;
    public interface IReservationService
    {
        public Task<bool> CheckCarIsAlreadyReservedAsync(int carId, DateTime startDate, DateTime endDate);
        public Task RentCarAsync(int carId, RentCarReservationViewModel model);
        public Task<bool> IsThereAvalilableRoomAsync(int hotelId, string roomType, DateTime startDate, DateTime endDate);
        public Task BookRoomAsync(RoomReservationViewModel roomReservation, Guid userId);
    }
}
