
namespace BookingWebProject.Services.Tests.Comparators
{
    using Core.Models.Room;
    using System.Collections;
    public class BookRoomViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            BookRoomViewModel bookRoom1 = (BookRoomViewModel)x;
            BookRoomViewModel bookRoom2 = (BookRoomViewModel)y;

            if (bookRoom1 == null || bookRoom2 == null)
            {
                return -1;
            }
            if (bookRoom1.AdultsCount != bookRoom2.AdultsCount || bookRoom1.ChildrenCount != bookRoom1.ChildrenCount || bookRoom1.HotelId != bookRoom2.HotelId
                || bookRoom1.Name != bookRoom2.Name || bookRoom1.SelectedPackage != bookRoom2.SelectedPackage || bookRoom1.Price != bookRoom2.Price)
            {
                return -1;
            }
            return 0;
        }
    }
}
