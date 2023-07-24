namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using Core.Models.Hotel;
    using Core.Models.Pager;
    using Extensions;
    public class HotelController : Controller
    {
        private readonly IBenefitService benefitService;
        private readonly IHotelService hotelService;
        public HotelController(IBenefitService benefitService, IHotelService hotelService)
        {
            this.benefitService = benefitService;
            this.hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] HotelQueryViewModel hotelQueryViewModel)
        {
            if (hotelQueryViewModel.CurrentPage < 1)
            {
                hotelQueryViewModel.CurrentPage = 1;
            }
            Guid userId = User.GetId();
           
        }
    }
}
