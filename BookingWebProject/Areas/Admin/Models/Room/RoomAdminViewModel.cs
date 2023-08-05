namespace BookingWebProject.Areas.Admin.Models.Room
{
    public class RoomAdminViewModel
    {
        public int Id { get; init; }
        public int RoomTypeId { get; init; }
        public string RoomTypeName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public decimal PricePerNight { get; set; }
        public string ImgPath { get; set; } = null!;
        public int HotelId { get; set; }
    }
}
