namespace BookingWebProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Benefit
    {
        public Benefit()
        {
            HotelBenefits = new List<HotelBenefits>();
        }
        [Key]
        public int Id { get; init; }
        [Required]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        [Required]
        public string ClassIcon { get; set; } = null!;
        public ICollection<HotelBenefits> HotelBenefits { get; set; }
    }
}
