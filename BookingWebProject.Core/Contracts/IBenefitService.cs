namespace BookingWebProject.Core.Contracts
{
     using Models.Benefits;
    public interface IBenefitService
    {
        Task<IEnumerable<BenefitViewModel>> GetAllBenefitsAsync();
    }
}
