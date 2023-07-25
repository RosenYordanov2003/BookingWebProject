namespace BookingWebProject.Core.Contracts
{
    using Models.Hotel;
    public interface IHotelService
    {
        Task<IEnumerable<HotelCardViewModel>> GetTopHotelsAsync();
        Task<AllHotelsSortedAndFilteredDataModel> GetAllHotelsSortedAndFilteredAsync(Guid userId, HotelQueryViewModel hotelQueryViewModel);
        Task<int> GetCountAsync(HotelQueryViewModel hotelQueryViewModel);
        Task<IEnumerable<string>> GetAllHotelCitiesAsync();
        Task<IEnumerable<string>> GetAllHotelCountriesAsync();
        Task<bool> IsExist(int hotelId);
        Task AddHotelToUserFavoriteHotels(int hotelId, Guid userId);
        Task RemoveHotelFromUserFavoriteHotels(int hotelId, Guid userId);
    }
}
