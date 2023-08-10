namespace BookingWebProject.Core.Models.Room
{
    using Picture;
    using RoomPackage;

    public class BookRoomViewModel
    {
        public string Name { get; set; } = null!;
        public int AdultsCount { get; set; }
        public int ChildrenCount { get; set; }
        public RoomPackageViewModel SelectedPackage { get; set; } = null!;
        public int HotelId { get; set; }
        public decimal Price { get; set; }
        public PictureViewModel? RoomPicture { get; set; }
    }
}
