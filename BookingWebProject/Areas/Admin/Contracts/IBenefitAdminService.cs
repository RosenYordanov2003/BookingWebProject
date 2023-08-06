using BookingWebProject.Areas.Admin.Models.Benefit;
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
        Task<bool> CheckIfBenefitIsAlreadyRecoveredByIdAsync(int benefitId);
        Task RecoverBenefitAsync(int benefitId);
        Task<EditBenefitViewModel>GetBenefitToEditAsync(int benefitId);
        Task EditBenefitByIdAsync(int benefitId, EditBenefitViewModel benefit);
        //Can change
        Task CreateBenefitAsync(EditBenefitViewModel benefit);
    }
}
