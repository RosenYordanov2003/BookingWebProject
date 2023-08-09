namespace BookingWebProject.Services.Tests
{
    using Core.Models.Hotel;
    using System.Collections;

    public class HotelCardViewModelComparer : IComparer
    {

        public int Compare(object? x, object? y)
        {
            HotelCardViewModel hotel1 = (HotelCardViewModel)x;
            HotelCardViewModel hotel2 = (HotelCardViewModel)y;

            if (hotel1 == null && hotel2 == null)
                return 0;

            if (hotel1 == null || hotel2 == null)
                return -1;

            if (hotel1.Id != hotel2.Id ||
            hotel1.City != hotel2.City ||
            hotel1.Country != hotel2.Country ||
            hotel1.Name != hotel2.Name ||
                hotel1.Stars != hotel2.Stars)
            {
                return -1;
            }

            return 0;
        }
    }
}