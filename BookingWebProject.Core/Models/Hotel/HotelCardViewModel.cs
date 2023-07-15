namespace BookingWebProject.Core.Models.Hotel
{
    using Models.Picture;
    public class HotelCardViewModel
    {
        public HotelCardViewModel()
        {
            Pictures = new List<PictureViewModel>();
        }
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public int Stars { get; set; }
        public List<PictureViewModel> Pictures { get; set; }
    }
}

