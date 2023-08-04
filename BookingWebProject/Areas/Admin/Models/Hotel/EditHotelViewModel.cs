namespace BookingWebProject.Areas.Admin.Models.Hotel
{
    using System.ComponentModel.DataAnnotations;
    using Picture;
    using Core.Models.Benefits;
    using static Common.EntityValidation.HotelEntity;

    public class EditHotelViewModel
    {
        public EditHotelViewModel()
        {
            Pictures = new List<PictureAdminViewModel>();
            CurrentHotelBenefits = new List<BenefitViewModel>();
            SelectedBenefitIds = new List<int>();
            BenefitsToAdd = new List<BenefitViewModel>();
        }
        public int Id { get; init; }

        [StringLength(MaxHotelNameValue, MinimumLength = MinHotelNameValue)]
        [Display(Name = "Hotel Name")]
        [Required]
        public string HotelName { get; set; } = null!;
        [MaxLength(MaxDescriptionValue)]
        public string? Description { get; set; }
        [Range(MinStarValue, MaxStarValue)]
        [Display(Name = "Hotel Stars Rating")]
        public int StarRating { get; set; }
        [StringLength(MaxCountryValue, MinimumLength = MinCountryValue)]
        [Display(Name = "Hotel Country")]
        [Required]
        public string Country { get; set; } = null!;
        [StringLength(MaxCityValue, MinimumLength = MinCityValue)]
        [Display(Name = "Hotel City")]
        [Required]
        public string City { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public List<int> SelectedBenefitIds { get; set; }
        public IEnumerable<BenefitViewModel> BenefitsToAdd { get; set; }
        public IEnumerable<PictureAdminViewModel> Pictures { get; set; }
        public IEnumerable<BenefitViewModel> CurrentHotelBenefits { get; set; }
    }
}
