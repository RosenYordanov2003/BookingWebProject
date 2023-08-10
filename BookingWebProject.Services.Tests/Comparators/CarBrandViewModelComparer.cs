namespace BookingWebProject.Services.Tests.Comparators
{
    using System.Collections;
    using Core.Models.RentCar;
    public class CarBrandViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            CarBrandViewModel car1 = (CarBrandViewModel)x;
            CarBrandViewModel car2 = (CarBrandViewModel)y;

            if (car1 == null || car2 == null)
            {
                return -1;
            }
            if (car1.Id != car2.Id || car1.Model != car2.Model || car1.CarImg != car2.CarImg || car1.MakeType != car2.MakeType)
            {
                return -1;
            }
            return 0;
        }
    }
}
