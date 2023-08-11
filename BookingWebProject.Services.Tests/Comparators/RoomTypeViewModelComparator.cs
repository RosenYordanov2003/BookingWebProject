namespace BookingWebProject.Services.Tests.Comparators
{
    using System.Collections;
    using Areas.Admin.Models.RoomType;
    public class RoomTypeViewModelComparator : IComparer
    {
        public int Compare(object? x, object? y)
        {
           RoomTypeViewModel roomType1 = (RoomTypeViewModel)x;
           RoomTypeViewModel roomType2 = (RoomTypeViewModel)y;

            if (roomType1 == null || roomType2 == null)
            {
                return -1;
            }
            if (roomType1.Id != roomType2.Id || roomType1.Name != roomType2.Name)
            {
                return -1;
            }
            return 0;
        }
    }
}
