namespace BookingWebProject.Areas.Admin.Contracts
{
    using Models.Hotel;
    public interface IHotelAdminService
    {
        Task<IEnumerable<HotelAllViewModel>> GetAllHotelsAsync();
        Task<bool> CheckIfHotelIsAlredyDeletedAsync(int hotelId);
        Task DeleteHotelByIdAsync(int hotelId);
        Task RecoverHotelByIdAsync(int hotelId);
        Task<bool> CheckIsHotelForRecoverExistByIdAsync(int hotelId);
        Task<EditHotelViewModel>GetHotelToEditAsync(int hotelId);
        Task EditHotelByIdAsync(int hotelId, EditHotelViewModel editHotelViewModel);
        Task <bool> CheckIsHotelBenefitExistAsync(int benefitId, int hotelId);
        Task<bool> CheckIsHotelBenefitIsAlreadyDeletedAsync(int benefitId, int hotelId);
        Task DeleteHotelBenefitAsync(int benefitId, int hotelId);
        Task <bool> CheckIsHotelBenefitIsAlreadyRecovoredAsync(int benefitId, int hotelId);
        Task RecoverHotelBenefitAsync(int benefitId, int hotelId);
    }
}
