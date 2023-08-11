namespace BookingWebProject.Services.Tests.Comparators
{
    using System.Collections;
    using Areas.Admin.Models.RoomBasis;

    public class RoomBasisAdminViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
           RoomBasisAdminViewModel roomBasis1 = (RoomBasisAdminViewModel)x;
            RoomBasisAdminViewModel roomBasis2 = (RoomBasisAdminViewModel)y;

            if (roomBasis1 == null || roomBasis2 == null)
            {
                return -1;
            }
            if (roomBasis1.Name != roomBasis2.Name || roomBasis1.Id != roomBasis2.Id || roomBasis1.ClassIcon != roomBasis2.ClassIcon)
            {
                return -1;
            }
            return 0;
        }
    }
}
