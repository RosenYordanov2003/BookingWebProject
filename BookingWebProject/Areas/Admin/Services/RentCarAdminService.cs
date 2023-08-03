namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.RentCar;
    using Core.Models.Pager;
    using Infrastructure.Data.Models;

    public class RentCarAdminService : IRentCarAdminService
    {
        private readonly BookingContext bookingContext;
        public RentCarAdminService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }


        public async Task<IEnumerable<RentCarAdminViewModel>> GetAllCarsAsync(Pager pager)
        {
            IEnumerable<RentCarAdminViewModel> cars = await bookingContext.RentCars
                 .Select(rc => new RentCarAdminViewModel()
                 {
                     Id = rc.Id,
                     MakeType = rc.MakeType,
                     Model = rc.ModelType,
                     RentCount = rc.Reservations.Count(),
                     ImgPath = rc.CarImg,
                     IsDeleted = rc.IsDeleted,
                     Year = rc.Year
                 })
                 .Skip((pager.CurrentPage - 1) * pager.PageSize)
                 .Take(pager.PageSize)
                 .OrderBy(rc => rc.IsDeleted)
                 .ToArrayAsync();

            return cars;
        }

        public async Task<int> GetAllCarsCountAsync()
        {
            return await bookingContext.RentCars.CountAsync();
        }

        public async Task<EditRentCarViewModel> GetRentCarToEditAsync(int carId)
        {
            EditRentCarViewModel carToEdit = await bookingContext.RentCars
                .Select(rc => new EditRentCarViewModel()
                {
                    Id = rc.Id,
                    MakeType = rc.MakeType,
                    Model = rc.ModelType,
                    DoorsCount = rc.DoorsCount,
                    CarImg = rc.CarImg,
                    FuelCapacity = rc.FuelCapacity,
                    FuelConsumption = rc.FuelConsumption,
                    Lattitude = rc.Lattitude,
                    Longitude = rc.Longitude,
                    Location = rc.Location,
                    PeopleCapacity = rc.PeopleCapacity,
                    Price = rc.PricePerDay,
                    Transmission = rc.TransmissionType,
                    Year = rc.Year
                })
                .FirstAsync(rc => rc.Id == carId);

            return carToEdit;
        }

        public async Task<bool> IsCarExistByIdAsync(int carId)
        {
            return await bookingContext.RentCars.AnyAsync(rc => rc.Id == carId);
        }
        public async Task EditCarAsync(int cardId, EditRentCarViewModel editRentCarViewModel)
        {
            RentCar carToEdit = await FindCarByIdAsync(cardId);
            carToEdit.MakeType = editRentCarViewModel.MakeType;
            carToEdit.ModelType = editRentCarViewModel.Model;
            carToEdit.DoorsCount = editRentCarViewModel.DoorsCount;
            carToEdit.PeopleCapacity = editRentCarViewModel.PeopleCapacity;
            carToEdit.Location = editRentCarViewModel.Location;
            carToEdit.Longitude = editRentCarViewModel.Longitude;
            carToEdit.Lattitude = editRentCarViewModel.Lattitude;
            carToEdit.PricePerDay = editRentCarViewModel.Price;
            carToEdit.FuelConsumption = editRentCarViewModel.FuelConsumption;
            carToEdit.FuelCapacity = editRentCarViewModel.FuelCapacity;
            carToEdit.CarImg = editRentCarViewModel.CarImg;
            carToEdit.TransmissionType = editRentCarViewModel.Transmission;
            carToEdit.Year = editRentCarViewModel.Year;

            await bookingContext.SaveChangesAsync();
        }

        public async Task<bool> CheckCarIsAlreadyDeleted(int carId)
        {
            return await bookingContext.RentCars.AnyAsync(rc => rc.Id == carId && rc.IsDeleted);
        }

        public async Task DeleteCarByIdAsync(int carId)
        {
            RentCar carToDelete = await FindCarByIdAsync(carId);
            carToDelete.IsDeleted = true;
            await bookingContext.SaveChangesAsync();
        }

        public Task<bool> CheckCarIsAlreadyRecoveredAsync(int carId)
        {
            return bookingContext.RentCars.AnyAsync(rc => rc.Id == carId && !rc.IsDeleted);
        }

        public async Task RecoverCarByIdAsync(int carId)
        {
            RentCar carToRecover = await FindCarByIdAsync(carId);
            carToRecover.IsDeleted = false;
            await bookingContext.SaveChangesAsync();
        }
        private async Task<RentCar> FindCarByIdAsync(int carId)
        {
            RentCar carToFind = await bookingContext.RentCars
                .FirstAsync(rc => rc.Id == carId);

            return carToFind;
        }
    }
}
