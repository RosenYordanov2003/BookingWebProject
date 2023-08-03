namespace BookingWebProject.Areas.Admin.Contracts
{
    using Models.RentCar;
    public interface IRentCarAdminService
    {
        Task<IEnumerable<RentCarAdminViewModel>> GetAllCarsAsync();
    }
}
