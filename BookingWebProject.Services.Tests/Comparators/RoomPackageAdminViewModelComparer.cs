namespace BookingWebProject.Services.Tests.Comparators
{
    using Areas.Admin.Models.RoomPackage;
    using System.Collections;
    public class RoomPackageAdminViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            RoomPackageAdminViewModel roomPackage1 = (RoomPackageAdminViewModel)x;
            RoomPackageAdminViewModel roomPackage2 = (RoomPackageAdminViewModel)y;
            if (roomPackage1 == null || roomPackage2 == null)
            {
                return -1;
            }
            if (roomPackage1.Name != roomPackage2.Name || roomPackage1.Price != roomPackage2.Price
                || roomPackage1.Id != roomPackage2.Id)
            {
                return -1;
            }
            return 0;
        }
    }
}
