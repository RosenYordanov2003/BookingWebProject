namespace BookingWebProject.Areas.Admin.Contracts
{
    using Core.Models.Pager;
    using Models.RentCar;
    public interface IRentCarAdminService
    {
        Task<IEnumerable<RentCarAdminViewModel>> GetAllCarsAsync(Pager pager);
        Task<int> GetAllCarsCountAsync();
    }
}
