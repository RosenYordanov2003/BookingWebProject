namespace BookingWebProject.Areas.Admin.Models.RentCar
{
    using Core.Models.Pager;
    public class RentCarAdminViewModel
    {
        public int Id { get; init; }
        public string MakeType { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public string ImgPath { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public int RentCount { get; set; }

    }
}
