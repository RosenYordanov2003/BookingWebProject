namespace BookingWebProject.Core.Models.Hotel
{
    using Benefits;
    using Comment;
    using Picture;
    using Pager;
    public class HotelInfoViewModel
    {
        public HotelInfoViewModel()
        {
            Pictures = new List<PictureViewModel>();
            Comments = new List<CommentViewModel>();
            Benefits = new List<BenefitViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public IEnumerable<PictureViewModel> Pictures { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public IEnumerable<BenefitViewModel> Benefits { get; set; }
        public int StarRating { get; set; }
        public Pager CommentsPager { get; set; } = null!;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
