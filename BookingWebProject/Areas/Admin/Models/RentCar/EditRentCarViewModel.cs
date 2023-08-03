namespace BookingWebProject.Areas.Admin.Models.RentCar
{
    using Infrastructure.Data.Enums;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.RentCarEntity;
    public class EditRentCarViewModel
    {
        public int Id { get; init; }

        [Required]
        [StringLength(MakeTypeMaxLength, MinimumLength = MakeTypeMinLength)]
        [Display(Name = "Brand")]
        public string MakeType { get; set; } = null!;

        [Required]
        [StringLength(ModelTypeMaxLength, MinimumLength = ModelTypeMinLength)]
        public string Model { get; set; } = null!;

        [Range(MinDoorsCount, MaxDoorsCount)]
        public int DoorsCount { get; set; }
        [Range(MinPriceValue, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(MinPeopleCapacity, MaxPeopleCapacity)]
        public int PeopleCapacity { get; set; }

        [Range(MinFuelConsuptionValue, MaxFuelConsuptionValue)]
        public double FuelConsumption { get; set; }

        [Range(MinFuelCapacityValue, MaxFuelCapacityValue)]
        public double FuelCapacity { get; set; }

        [Required]
        [StringLength(LocationMaxValue, MinimumLength = LocationMinValue)]
        public string Location { get; set; } = null!;

        [Required]
        [Range(MinYear, MaxYear)]
        public int Year { get; set; }
        public string CarImg { get; set; } = null!;
        public decimal Longitude { get; set; }
        
        public decimal Lattitude { get; set; }
        public TransmissionType Transmission { get; set; }
    }
}
