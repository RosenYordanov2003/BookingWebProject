namespace BookingWebProject.Areas.Admin.Models.Hotel
{
    using System.ComponentModel.DataAnnotations;
    using BookingWebProject.Areas.Admin.Models.Picture;
    using BookingWebProject.Core.Models.Benefits;
    using static Common.EntityValidation.HotelEntity;

    public class EditHotelViewModel
    {
        public EditHotelViewModel()
        {
            Pictures = new List<PictureAdminViewModel>();
            CurrentHotelBenefits = new List<BenefitViewModel>();
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
        public IEnumerable<PictureAdminViewModel> Pictures { get; set; }
        public IEnumerable<BenefitViewModel> CurrentHotelBenefits { get; set; }
    }
}
