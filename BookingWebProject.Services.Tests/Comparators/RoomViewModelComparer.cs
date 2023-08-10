namespace BookingWebProject.Services.Tests.Comparators
{
    using Core.Models.Room;
    using System.Collections;
    public class RoomViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            RoomViewModel room1 = (RoomViewModel)x;
            RoomViewModel room2 = (RoomViewModel)y;

            if (room1 == null || room2 == null)
            {
                return -1;
            }
            if (room1.Id != room2.Id || room1.PricePerNight != room2.PricePerNight || room1.Description != room2.Description
              || room1.RoomCapacity != room2.RoomCapacity || room1.RoomType != room2.RoomType || room1.HotelName != room2.HotelName)
            {
                return -1;
            }
            return 0;
        }
    }
}
