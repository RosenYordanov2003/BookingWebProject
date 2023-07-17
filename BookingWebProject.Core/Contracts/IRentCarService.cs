namespace BookingWebProject.Core.Contracts
{
    using Models.RentCar;
    public interface IRentCarService
    {
        Task<AllCarsSortedAndFilteredDataModel> AllCarsSortedAndFilteredDataModelAsync(CarQuerViewModel carQuerViewModel);
        Task<int> GetCarsCountAsync(CarQuerViewModel carQuerViewModel);
        Task<IEnumerable<string>> GetAllBrandsAsync();
    }
}
