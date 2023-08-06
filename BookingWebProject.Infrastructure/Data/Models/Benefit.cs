namespace BookingWebProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.BenefitEntity;
    public class Benefit
    {
        public Benefit()
        {
            HotelBenefits = new List<HotelBenefits>();
        }
        [Key]
        public int Id { get; init; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        [Required]
        [MaxLength(ClassIconMaxLength)]
        public string ClassIcon { get; set; } = null!;
        public ICollection<HotelBenefits> HotelBenefits { get; set; }
    }
}
