namespace BookingWebProject.Core.Services
{
    using Models.RentCar;
    using Models.RentCar.Enums;
    using Data;
    using Infrastructure.Data.Models;
    using Contracts;
    using Microsoft.EntityFrameworkCore;

    public class RentCarService : IRentCarService
    {
        private readonly BookingContext bookingContext;
        public RentCarService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<AllCarsSortedAndFilteredDataModel> AllCarsSortedAndFilteredDataModelAsync(CarQuerViewModel carQuerViewModel)
        {
            IQueryable<RentCar> cars = bookingContext.RentCars.Where(rc => !rc.IsDeleted).AsQueryable();
            cars = FilterCars(carQuerViewModel, cars);
            int recordsToSkip = (carQuerViewModel.Pager.CurrentPage - 1) * carQuerViewModel.Pager.PageSize;
            IEnumerable<CarViewModel> carViewModels = await cars
                .Skip(recordsToSkip).Take(carQuerViewModel.Pager.PageSize)
                .Select(rc => new CarViewModel()
                {
                    Id = rc.Id,
                    CarImg = rc.CarImg,
                    Location = rc.Location,
                    MakeType = rc.MakeType,
                    Model = rc.ModelType,
                    PricePerDay = rc.PricePerDay,
                    Year = rc.Year

                }).ToArrayAsync();
            return new AllCarsSortedAndFilteredDataModel()
            {
                Cars = carViewModels
            };
        }
        private static IQueryable<RentCar> FilterCars(CarQuerViewModel carQuerViewModel, IQueryable<RentCar> cars)
        {
            if (carQuerViewModel.DoorsCount.HasValue)
            {
                cars = cars.Where(rc => rc.DoorsCount >= carQuerViewModel.DoorsCount);
            }
            if (carQuerViewModel.MinPrice.HasValue)
            {
                cars = cars.Where(rc => rc.PricePerDay >= carQuerViewModel.MinPrice);
            }
            if (carQuerViewModel.MaxPrice.HasValue)
            {
                cars = cars.Where(rc => rc.PricePerDay <= carQuerViewModel.MaxPrice);
            }
            if (carQuerViewModel.MinYear.HasValue)
            {
                cars = cars.Where(rc => rc.Year >= carQuerViewModel.MinYear);
            }
            if (carQuerViewModel.MaxYear.HasValue)
            {
                cars = cars.Where(rc => rc.Year <= carQuerViewModel.MaxYear);
            }
            if (!string.IsNullOrWhiteSpace(carQuerViewModel.Brand) && carQuerViewModel.Brand != "default")
            {
                cars = cars.Where(rc => rc.MakeType.ToLower() == carQuerViewModel.Brand.ToLower());
            }

            if (carQuerViewModel.CarSortOption == CarSortOption.YearAscending)
            {
                cars = cars.OrderBy(rc => rc.Year);
            }
            else if (carQuerViewModel.CarSortOption == CarSortOption.YearDescending)
            {
                cars = cars.OrderByDescending(rc => rc.Year);
            }
            else if (carQuerViewModel.CarSortOption == CarSortOption.PriceAscending)
            {
                cars = cars.OrderBy(rc => rc.PricePerDay);
            }
            else if (carQuerViewModel.CarSortOption == CarSortOption.PriceDescending)
            {
                cars = cars.OrderByDescending(rc => rc.PricePerDay);
            }
            else if (carQuerViewModel.CarSortOption == CarSortOption.MakeTypeAscending)
            {
                cars = cars.OrderBy(rc => rc.MakeType);
            }
            else if (carQuerViewModel.CarSortOption == CarSortOption.MakeTypeDescending)
            {
                cars = cars.OrderByDescending(rc => rc.MakeType);
            }
            else
            {
                cars = cars.OrderBy(rc => rc.Id);
            }

            return cars;
        }
    }
}
