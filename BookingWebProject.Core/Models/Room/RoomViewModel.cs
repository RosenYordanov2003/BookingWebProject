namespace BookingWebProject.Core.Models.Room
{
    using Models.Picture;
    public class RoomViewModel
    {
        public RoomViewModel()
        {
            RoomPictures = new List<PictureViewModel>();
        }
        public int Id { get; init; }
        public int RoomCapacity { get; init; }
        public string RoomType { get; init; } = null!;
        public string Description { get; init; } = null!;
        public IEnumerable<PictureViewModel> RoomPictures { get; set; }
        public string HotelName { get; set; } = null!;
        public decimal PricePerNight { get; set; }
    }
}
