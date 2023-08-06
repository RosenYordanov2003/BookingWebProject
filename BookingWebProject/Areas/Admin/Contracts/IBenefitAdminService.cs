using BookingWebProject.Core.Models.Benefits;

namespace BookingWebProject.Areas.Admin.Contracts
{
    public interface IBenefitAdminService
    {
        Task<IEnumerable<BenefitViewModel>> GetOtherBenefitsAsync(int hotelId);
        Task<IEnumerable<BenefitViewModel>> GetAllHotelBenefitsAsync();
        Task<bool> CheckIfBenefitExistByIdAsync(int benefitId);
        Task<bool>CheckIfBenefitIsAlreadyDeletedAsync(int benefitId);
        Task DeleteBenefitAsync(int benefitId);
    }
}
