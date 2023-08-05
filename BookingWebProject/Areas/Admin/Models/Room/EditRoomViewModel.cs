namespace BookingWebProject.Areas.Admin.Models.Room
{
    using Picture;
    using RoomBasis;
    using Core.Models.RoomBasis;
    using static Common.EntityValidation.RoomEntity;
    using System.ComponentModel.DataAnnotations;

    public class EditRoomViewModel
    {
        public EditRoomViewModel()
        {
            CurrentRoomBasis = new List<RoomBasisAdminViewModel>();
            SelectedRoomBasisIds = new List<int>();
            OtherRoomBasis = new List<RoomBasisViewModel>();
            Pictures = new List<PictureAdminViewModel>();
        }
        [Range(MinRoomCapacity, MaxRoomCapacity)]
        public int PeopleCapacity { get;set; }
        [Range(typeof(decimal), MinPricePerNightValue,"100000.00" )]
        public decimal PricePerNight { get;set; }
        [StringLength(MaxDescriptionValue, MinimumLength = MinDescriptionValue)]
        public string Description { get; set; } = null!;
        public int RoomTypeId { get; set; }
        public int HotelId { get; set; }
        public IEnumerable<RoomBasisAdminViewModel> CurrentRoomBasis { get; set; }
        public List<int> SelectedRoomBasisIds { get; set; }
        public IEnumerable<RoomBasisViewModel> OtherRoomBasis { get; set; }
        public IEnumerable<PictureAdminViewModel> Pictures { get; set; }
    }
}
