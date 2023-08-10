namespace BookingWebProject.Services.Tests.Comparators
{
    using System.Collections;
    using Core.Models.RentCar;
    public class CarViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            CarViewModel car1 = (CarViewModel)x;
            CarViewModel car2 = (CarViewModel)y;

            if (car1 == null || car2 == null)
            {
                return -1;
            }
            if (car1.Id != car2.Id || car1.Year != car2.Year || car1.CarImg != car2.CarImg
                || car1.MakeType != car2.MakeType || car1.PricePerDay != car2.PricePerDay
                || car1.Location != car2.Location)
            {
                return -1;
            }
            return 0;
        }
    }
}
