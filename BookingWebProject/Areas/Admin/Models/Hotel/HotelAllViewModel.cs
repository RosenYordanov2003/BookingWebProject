namespace BookingWebProject.Areas.Admin.Models.Hotel
{
    public class HotelAllViewModel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; } = null!;
        public int StarsCount { get; set; }
        public string ImgPath { get; set; } = null!;
    }
}
