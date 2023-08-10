namespace BookingWebProject.Services.Tests.Comparators
{
    using Core.Models.RentCar;
    using System.Collections;

    public class CarDetailsViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
           CarDetailsViewModel car1 = (CarDetailsViewModel)x;
           CarDetailsViewModel car2 = (CarDetailsViewModel)y;

            if (car1 == null || car2 == null)
            {
                return -1;
            }
            if (car1.Id != car2.Id || car1.Year != car2.Year || car1.CarImg != car2.CarImg || car1.FuelCapacity != car2.FuelCapacity
                ||car1.MakeType != car2.MakeType || car1.Model != car2.Model || car1.DoorsCount != car2.DoorsCount || car1.Longitude != car2.Longitude
                || car1.Latitude != car2.Latitude || car1.Location != car2.Location || car1.TransmissionType != car2.TransmissionType ||
                car1.PricePerDay != car2.PricePerDay || car1.FuelConsumption != car2.FuelConsumption)
            {
                return -1;
            }
            return 0;
        }
    }
}
