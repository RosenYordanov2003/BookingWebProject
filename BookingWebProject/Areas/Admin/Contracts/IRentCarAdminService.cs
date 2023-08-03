namespace BookingWebProject.Areas.Admin.Contracts
{
    using BookingWebProject.Areas.Admin.Models.Hotel;
    using Core.Models.Pager;
    using Models.RentCar;
    public interface IRentCarAdminService
    {
        Task<IEnumerable<RentCarAdminViewModel>> GetAllCarsAsync(Pager pager);
        Task<int> GetAllCarsCountAsync();
        Task<bool> IsCarExistByIdAsync(int carId);
        Task<EditRentCarViewModel> GetRentCarToEditAsync(int carId);
        Task EditCarAsync(int cardId, EditRentCarViewModel editRentCarViewModel);
    }
}
