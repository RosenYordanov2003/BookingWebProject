namespace BookingWebProject.Services.Tests.Comparators
{
    using System.Collections;
    using Core.Models.RoomPackage;
    public class RoomPackageViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            RoomPackageViewModel roomPackage1 = (RoomPackageViewModel)x;
            RoomPackageViewModel roomPackage2 = (RoomPackageViewModel)y;

            if (roomPackage1 == null || roomPackage2 == null)
            {
                return -1;
            }
            if (roomPackage1.Id != roomPackage2.Id || roomPackage1.Name != roomPackage2.Name || roomPackage1.Price != roomPackage2.Price)
            {
                return -1;
            }
            return 0;
        }
    }
}
