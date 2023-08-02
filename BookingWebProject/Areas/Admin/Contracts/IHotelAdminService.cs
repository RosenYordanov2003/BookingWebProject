namespace BookingWebProject.Areas.Admin.Contracts
{
    using Models.Hotel;
    public interface IHotelAdminService
    {
        Task<IEnumerable<HotelAllViewModel>> GetAllHotelsAsync();
    }
}
