namespace BookingWebProject.Core.Models.RentCar
{
    public class CarViewModel
    {
        public int Id { get; init; }
        public string MakeType { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public string CarImg { get; set; } = null!;
        public string Location { get; set; } = null!;
        public decimal PricePerDay { get; set; }
    }
}
