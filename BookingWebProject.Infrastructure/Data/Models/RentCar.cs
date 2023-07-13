namespace BookingWebProject.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.RentCarEntity;
    using Infrastructure.Data.Enums;

    public class RentCar
    {
        public RentCar()
        {
            Reservations = new List<Reservation>();
        }
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }
        [Required]
        [MaxLength(MakeTypeMaxLength)]
        public string MakeType { get; set; } = null!;
        [Required]
        [MaxLength(ModelTypeMaxLength)]
        public string ModelType { get; set; } = null!;
        public int DoorsCount { get; set; }
        [Required]
        public string CarImg { get; set; } = null!;
        public double FuelConsumption { get; set; }
        public double FuelCapacity { get; set; }
        public int PeopleCapacity { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public string Location { get; set; } = null!;
        [Column(TypeName = "decimal(17, 15)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "decimal(17, 15)")]
        public decimal Lattitude { get; set; }
        public decimal PricePerDay { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
