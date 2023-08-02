namespace BookingWebProject.Areas.Admin.Models.Hotel
{
    using System.ComponentModel.DataAnnotations;
    using Core.Models.Picture;
    using static Common.EntityValidation.HotelEntity;

    public class EditHotelViewModel
    {
        public EditHotelViewModel()
        {
            Pictures = new List<PictureViewModel>();
        }

        public int Id { get; init; }
        [StringLength(MaxHotelNameValue, MinimumLength = MinHotelNameValue)]
        [Required]
        public string HotelName { get; set; } = null!;
        [MaxLength(MaxDescriptionValue)]
        public string? Description { get; set; }
        [Range(MinStarValue, MaxStarValue)]
        public int StarRating { get; set; }
        [StringLength(MaxCountryValue, MinimumLength = MinCountryValue)]
        [Required]
        public string Country { get; set; } = null!;
        [StringLength(MaxCityValue, MinimumLength = MinCityValue)]
        [Required]
        public string City { get; set; } = null!;
        public IEnumerable<PictureViewModel> Pictures { get; set; }
    }
}
