namespace BookingWebProject.Core.Contracts
{
    public interface IReservationService
    {
        public Task<bool> CheckCarIsAlreadyReservedAsync(int carId, DateTime startDate, DateTime endDate);
    }
}
