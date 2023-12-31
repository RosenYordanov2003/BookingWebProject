﻿namespace BookingWebProject.Areas.Admin.Contracts
{
    using Core.Models.Pager;
    using Models.Hotel;
    public interface IHotelAdminService
    {
        Task<IEnumerable<HotelAllViewModel>> GetAllHotelsAsync(Pager pager);
        Task<bool> CheckIfHotelIsAlredyDeletedAsync(int hotelId);
        Task DeleteHotelByIdAsync(int hotelId);
        Task RecoverHotelByIdAsync(int hotelId);
        Task<bool> CheckIfHotelForRecoverExistByIdAsync(int hotelId);
        Task<EditHotelViewModel>GetHotelToEditAsync(int hotelId);
        Task EditHotelByIdAsync(int hotelId, EditHotelViewModel editHotelViewModel);
        Task <bool> CheckIsHotelBenefitExistAsync(int benefitId, int hotelId);
        Task<bool> CheckIsHotelBenefitIsAlreadyDeletedAsync(int benefitId, int hotelId);
        Task DeleteHotelBenefitAsync(int benefitId, int hotelId);
        Task CreateHotelAsync(CreateHotelViewModel createHotelViewModel);
        Task CreateHotelImgsAsync(CreateHotelViewModel hotelViewModel);
        Task<int> GetAllHotelsCountAsync();
        Task<bool> CheckIsHotelExistAsync(int hotelId);
        Task<IEnumerable<HotelOptionsViewModel>> GetAllHotelsAsHotelRoomOptionsAsync();
    }
}
