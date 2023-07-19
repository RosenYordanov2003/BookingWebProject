namespace BookingWebProject.Core.Models.RentCar
{
    public class CarBrandViewModel
    {
        public int Id { get; init; }
        public string MakeType { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string CarImg { get; set; } = null!;
    }
}
