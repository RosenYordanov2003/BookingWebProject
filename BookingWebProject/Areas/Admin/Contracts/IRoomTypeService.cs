namespace BookingWebProject.Areas.Admin.Contracts
{
    using Models.RoomType;
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeViewModel>> GetAllRoomTypesAsync();
    }
}
