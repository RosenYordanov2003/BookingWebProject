namespace BookingWebProject.Core.Contracts
{
    using Models.RentCar;
    public interface IRentCarService
    {
        Task<AllCarsSortedAndFilteredDataModel> AllCarsSortedAndFilteredDataModelAsync(CarQueryViewModel carQuerViewModel);
    }
}
