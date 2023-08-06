namespace BookingWebProject.Areas.Admin.Models.Room
{
    using System.ComponentModel.DataAnnotations;
    using Core.Models.RoomBasis;
    using Hotel;
    using RoomType;
    using static Common.EntityValidation.RoomEntity;
    public class CreateRoomViewModel
    {
        public CreateRoomViewModel()
        {
            RoomTypes = new List<RoomTypeViewModel>();
            HotelOptions = new List<HotelOptionsViewModel>();
            RoomBasis = new List<RoomBasisViewModel>();
            SelectedRoomBasesIds = new List<int>();
        }
        [Range(MinRoomCapacity, MaxRoomCapacity)]
        public int PeopleCapacity { get; set; }

        [Required]
        [StringLength(MaxDescriptionValue, MinimumLength = MinDescriptionValue)]
        public string Description { get; set; } = null!;
        public int RoomTypeId { get; set; }
        public IEnumerable<RoomTypeViewModel> RoomTypes { get; set; }
        public int HotelId { get; set; }
        public IEnumerable<HotelOptionsViewModel> HotelOptions { get; set; }

        [Range(typeof(decimal), MinPricePerNightValue, "100000.00")]
        public decimal PricePerNight { get; set; }
        public IEnumerable<RoomBasisViewModel> RoomBasis { get; set; }
        public List<int> SelectedRoomBasesIds { get; set; }
        public IFormFileCollection? PicturesFileProvider { get; set; }
    }
}
