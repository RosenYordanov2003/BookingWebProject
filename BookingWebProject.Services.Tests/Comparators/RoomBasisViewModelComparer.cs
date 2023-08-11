namespace BookingWebProject.Services.Tests.Comparators
{
    using System.Collections;
    using Core.Models.RoomBasis;

    public class RoomBasisViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            RoomBasisViewModel roomBasis1 = (RoomBasisViewModel)x;
            RoomBasisViewModel roomBasis2 = (RoomBasisViewModel)y;

            if (roomBasis1 == null || roomBasis2 == null)
            {
                return -1;
            }
            if (roomBasis1.Name != roomBasis2.Name || roomBasis1.ClassIcon != roomBasis2.ClassIcon || roomBasis1.Id != roomBasis2.Id)
            {
                return -1;
            }
            return 0;
        }
    }
}
