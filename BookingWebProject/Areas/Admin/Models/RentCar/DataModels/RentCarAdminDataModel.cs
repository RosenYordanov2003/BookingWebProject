namespace BookingWebProject.Areas.Admin.Models.RentCar.Data_Models
{
    using BookingWebProject.Core.Models.Pager;
    public class RentCarAdminDataModel
    {
        public IEnumerable<RentCarAdminViewModel> Cars { get; set; }
        public Pager Pager { get; set; } = null!;
    }
}
