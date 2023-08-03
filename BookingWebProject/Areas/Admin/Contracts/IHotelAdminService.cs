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
        Task<bool> CheckIsHotelBenefitIsAlreadyDeleted(int benefitId, int hotelId);
        Task DeleteHotelBenefitAsync(int benefitId, int hotelId);
    }
}
