namespace BookingWebProject.Core.Models.Hotel
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.HotelEntity;
    using Benefits;
    using Pager;
    using Enums;

    public class HotelQueryViewModel
    {
        public HotelQueryViewModel()
        {
            Cities = new List<string>();
            Countries = new List<string>();
            Benefits = new List<BenefitViewModel>();
            HotelViewModels = new List<HotelViewModel>();
            SelectedBenefitIds = new List<int>();
        }
        public HotelSortOption HotelSortOption { get; set; }
        public Pager Pager { get; set; } = null!;
        public int CurrentPage { get; set; }
        [Range(MinStarValue, MaxStarValue)]
        public int? MinStarsCountFilter { get; set; }
        [Range(MinStarValue, MaxStarValue)]
        public int? MaxStarsCountFilter { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public IEnumerable<string> Cities { get; set; }
        public IEnumerable<string> Countries { get; set; }
        public IEnumerable<BenefitViewModel> Benefits { get; set; }
        public IEnumerable<HotelViewModel> HotelViewModels { get; set; }
        public IEnumerable<int> SelectedBenefitIds { get; set; }
    }
}
