namespace BookingWebProject.Core.Contracts
{
    using Models.Reservation;
    public interface IReservationService
    {
         Task<bool> CheckCarIsAlreadyReservedAsync(int carId, DateTime startDate, DateTime endDate);
         Task RentCarAsync(int carId, RentCarReservationViewModel model);
         Task<bool> IsThereAvalilableRoomAsync(int hotelId, string roomType, DateTime startDate, DateTime endDate);
         Task BookRoomAsync(RoomReservationViewModel roomReservation, Guid userId);
         Task<bool> IsReservationExistAsync(Guid reservationId);
         Task<ReservationInfoViewModel> GetReservationByIdAsync(Guid reservationId);
    }
}
