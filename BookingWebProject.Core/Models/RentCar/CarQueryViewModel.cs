namespace BookingWebProject.Core.Models.RentCar
{
    using static BookingWebProject.Common.EntityValidation;
    using System.ComponentModel.DataAnnotations;
    using RentCar.Enums;
    using Pager;

    public class CarQuerViewModel
    {

        public CarQuerViewModel()
        {
            Cars = new List<CarViewModel>();
            CurrentPage = 1;
            Brands = new List<string>();
        }
        [Display(Name = "Sort By")]
        public CarSortOption CarSortOption { get; set; }
        public Pager Pager { get; set; } = null!;
        public IEnumerable<CarViewModel> Cars { get; set; }
        public int CurrentPage { get; set; }
        [Range(typeof(decimal), ReservationCarEntity.MinPriceAsDecimal, ReservationCarEntity.MaxPriceAsDecimal)]
        [Display(Name = "Min Price")]
        public decimal? MinPrice { get; set; }
        [Range(typeof(decimal), ReservationCarEntity.MinPriceAsDecimal, ReservationCarEntity.MaxPriceAsDecimal)]
        [Display(Name = "Max Price")]
        public decimal? MaxPrice { get; set; }
        [Range(ReservationCarEntity.DoorsMinCount, ReservationCarEntity.DoorsMaxCount)]
        [Display(Name = "Doors Count")]
        public int? DoorsCount { get; set; }
        [Range(ReservationCarEntity.MinYear, ReservationCarEntity.MaxYear)]
        [Display(Name = "Start Year")]
        public int? MinYear { get; set; }
        [Range(ReservationCarEntity.MinYear, ReservationCarEntity.MaxYear)]
        [Display(Name = "End Year")]
        public int? MaxYear { get; set; }
        public string? Brand { get; set; }
        public IEnumerable<string> Brands { get; set; }

    }
}
