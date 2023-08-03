namespace BookingWebProject.Areas.Admin.Contracts
{
    using Core.Models.Benefits;
    public interface IBenefitAdminService
    {
        Task<IEnumerable<BenefitViewModel>> GetOtherBenefitsAsync(int hotelId);
    }
}
