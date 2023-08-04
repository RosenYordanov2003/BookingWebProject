namespace BookingWebProject.Areas.Admin.Models.Room
{
    using Picture;
    using Core.Models.RoomBasis;
    public class EditRoomViewModel
    {
        public EditRoomViewModel()
        {
            CurrentRoomBasis = new List<RoomBasisViewModel>();
            SelectedRoomBasisIds = new List<int>();
            OtherRoomBasis = new List<RoomBasisViewModel>();
            Pictures = new List<PictureAdminViewModel>();
        }
        public int Id { get; init; }
        public int PeopleCapacity { get;set; }
        public decimal PricePerNight { get;set; }
        public string Description { get; set; } = null!;
        public IEnumerable<RoomBasisViewModel> CurrentRoomBasis { get; set; }
        public List<int> SelectedRoomBasisIds { get; set; }
        public IEnumerable<RoomBasisViewModel> OtherRoomBasis { get; set; }
        public IEnumerable<PictureAdminViewModel> Pictures { get; set; }
    }
}
