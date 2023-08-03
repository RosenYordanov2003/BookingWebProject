namespace BookingWebProject.Core.Models.Benefits
{
    public class BenefitViewModel
    {
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public string BenefitIcon { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
