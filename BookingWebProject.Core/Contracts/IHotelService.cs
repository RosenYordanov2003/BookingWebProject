namespace BookingWebProject.Core.Contracts
{
    using BookingWebProject.Core.Models.Pager;
    using Models.Hotel;
    public interface IHotelService
    {
        Task<IEnumerable<HotelCardViewModel>> GetTopHotelsAsync();
        Task<AllHotelsSortedAndFilteredDataModel> GetAllHotelsSortedAndFilteredAsync(Guid userId, HotelQueryViewModel hotelQueryViewModel);
        Task<int> GetCountAsync(HotelQueryViewModel hotelQueryViewModel);
        Task<IEnumerable<string>> GetAllHotelCitiesAsync();
        Task<IEnumerable<string>> GetAllHotelCountriesAsync();
        Task<bool> CheckIsHotelExistAsync(int hotelId);
        Task AddHotelToUserFavoriteHotels(int hotelId, Guid userId);
        Task RemoveHotelFromUserFavoriteHotels(int hotelId, Guid userId);
        Task<HotelInfoViewModel> GetHotelByIdAsync(int hotelId, Pager pager);
        Task<int> GetHotelCommentsCountAsync(int hotelId);  
    }
}
