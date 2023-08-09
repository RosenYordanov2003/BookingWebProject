namespace BookingWebProject.Services.Tests.Comparators
{
    using Core.Models.Hotel;
    using System.Collections;
    public class HotelViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            HotelViewModel hotelOne = (HotelViewModel)x;
            HotelViewModel hotelTwo = (HotelViewModel)y;

            if (hotelOne == hotelTwo)
            {
                return 0;
            }
            if (hotelOne == null || hotelTwo == null)
            {
                return -1;
            }
            if (hotelOne.Id != hotelTwo.Id || hotelOne.Name != hotelTwo.Name || hotelOne.City != hotelTwo.City
                || hotelOne.Country != hotelTwo.Country || hotelOne.StarRating != hotelTwo.StarRating)
            {
                return -1;
            }
            return 0;
        }
    }
}
