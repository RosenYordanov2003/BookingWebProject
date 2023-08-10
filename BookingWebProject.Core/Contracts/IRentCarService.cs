namespace BookingWebProject.Core.Contracts
{
    using Models.RentCar;
    public interface IRentCarService
    {
        Task<AllCarsSortedAndFilteredDataModel> AllCarsSortedAndFilteredDataModelAsync(CarQuerViewModel carQuerViewModel);
        Task<int> GetCarsCountAsync(CarQuerViewModel carQuerViewModel);
        Task<CarDetailsViewModel> FindCarByIdAsync(int carId);
        Task<IEnumerable<string>> GetAllBrandsAsync();
        Task<bool> CheckIfCarExistByIdAsync(int carId);
        Task<IEnumerable<CarBrandViewModel>> GetCarsByBrandAsync(string brand, int carId);
        Task<CarViewModel> GetOrderCarAsync(int carId);
    }
}
