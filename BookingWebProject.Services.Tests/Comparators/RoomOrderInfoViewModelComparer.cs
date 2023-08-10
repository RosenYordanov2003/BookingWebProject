namespace BookingWebProject.Services.Tests.Comparators
{
    using Core.Models.Room;
    using System.Collections;

    public class RoomOrderInfoViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            RoomOrderInfoViewModel room1 = (RoomOrderInfoViewModel)x;
            RoomOrderInfoViewModel room2 = (RoomOrderInfoViewModel)y;

            if (room1 == null || room2 == null)
            {
                return -1;
            }
            if (room1.Id != room1.Id || room1.HotelId != room2.HotelId || room1.Description != room2.Description
               || room1.Name != room2.Name || room1.RoomCapacity != room2.RoomCapacity || room1.Price != room2.Price)
            {
                return -1;
            }
            return 0;
        }
    }
}
