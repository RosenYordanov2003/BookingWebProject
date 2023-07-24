namespace BookingWebProject.Core.Contracts
{
     using Core.Models.Benefits;
    public interface IBenefitService
    {
        Task<IEnumerable<BenefitViewModel>> GetAllBenefitsAsync();
    }
}
