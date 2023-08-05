namespace BookingWebProject.Areas.Admin.Models.Room.DataModels
{
    using Core.Models.Pager;
    public class RoomHotelsDataModel
    {
        public RoomHotelsDataModel()
        {
            Rooms = new List<RoomAdminViewModel>();
        }
        public Pager Pager { get; set; } = null!;
        public IEnumerable<RoomAdminViewModel> Rooms { get; set; }
    }
}
