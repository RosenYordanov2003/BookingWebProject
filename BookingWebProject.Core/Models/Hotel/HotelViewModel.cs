
namespace BookingWebProject.Core.Models.Hotel
{
    using Room;
    public class HotelViewModel
    {
        public HotelViewModel()
        {
            IsFavorite = false;
        }
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public int StarRating { get; set; }
        public bool IsFavorite { get; set; }
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string PicturePath { get; set; } = null!;

        public CheapestHotelRoomViewModel? CheapestHotelRoomViewModel { get; set; }
    }
}
