namespace BookingWebProject.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class HotelBenefits
    {
        [ForeignKey(nameof(Benefit))]
        public int BenefitId { get; set; }
        public Benefit Benefit { get; set; } = null!;
        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
