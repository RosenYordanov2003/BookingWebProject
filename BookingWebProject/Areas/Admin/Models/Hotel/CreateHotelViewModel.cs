namespace BookingWebProject.Areas.Admin.Models.Hotel
{
    using BookingWebProject.Core.Models.Benefits;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.HotelEntity;
    public class CreateHotelViewModel
    {
        public CreateHotelViewModel()
        {
            PicturesPath = new List<string>();
            AllBenefits = new List<BenefitViewModel>();
            SelectedBenefitIds = new List<int>();
        }
        [StringLength(MaxHotelNameValue, MinimumLength = MinHotelNameValue)]
        [Display(Name = "Hotel Name")]
        [Required]
        public string Name { get; set; } = null!;

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
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public IFormFileCollection? PicturesFileProvider { get; set; }
        public List<string> PicturesPath { get; set; }
        public IEnumerable<BenefitViewModel> AllBenefits { get; set; }
        public List<int> SelectedBenefitIds { get; set; }
    }
}
