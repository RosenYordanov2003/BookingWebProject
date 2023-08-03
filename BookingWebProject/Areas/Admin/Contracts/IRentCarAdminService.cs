namespace BookingWebProject.Areas.Admin.Contracts
{
    using Core.Models.Pager;
    using Models.RentCar;
    public interface IRentCarAdminService
    {
        Task<IEnumerable<RentCarAdminViewModel>> GetAllCarsAsync(Pager pager);
        Task<int> GetAllCarsCountAsync();
        Task<bool> IsCarExistByIdAsync(int carId);
        Task<EditRentCarViewModel> GetRentCarToEditAsync(int carId);
        Task EditCarAsync(int cardId, EditRentCarViewModel editRentCarViewModel);
        Task<bool> CheckCarIsAlreadyDeleted(int carId);
        Task DeleteCarByIdAsync(int carId);
        Task<bool> CheckCarIsAlreadyRecoveredAsync(int carId);
        Task RecoverCarByIdAsync(int carId);
    }
}
