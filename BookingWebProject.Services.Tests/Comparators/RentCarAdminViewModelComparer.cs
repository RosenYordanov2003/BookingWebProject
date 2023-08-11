namespace BookingWebProject.Services.Tests.Comparators
{
    using System.Collections;
    using Areas.Admin.Models.RentCar;
    public class RentCarAdminViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            RentCarAdminViewModel car1 = (RentCarAdminViewModel)x;
            RentCarAdminViewModel car2 = (RentCarAdminViewModel)y;

            if (car1 == null || car2 == null)
            {
                return -1;
            }
            if (car1.Id != car2.Id || car1.Year != car2.Year || car1.ImgPath != car2.ImgPath
                || car1.MakeType != car2.MakeType)
            {
                return -1;
            }
            return 0;
        }
    }
}
