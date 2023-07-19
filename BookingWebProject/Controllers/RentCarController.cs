namespace BookingWebProject.Controllers
{
    using Core.Contracts;
    using Core.Models.Pager;
    using Core.Models.RentCar;
    using Microsoft.AspNetCore.Mvc;
    public class RentCarController : Controller
    {
        private readonly IRentCarService carService;
        public RentCarController(IRentCarService carService)
        {
            this.carService = carService;
        }
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] CarQuerViewModel carQuerViewModel)
        {
            if (carQuerViewModel.CurrentPage <= 0)
            {
                carQuerViewModel.CurrentPage = 1;
            }
            Pager pager = new Pager(await carService.GetCarsCountAsync(carQuerViewModel), carQuerViewModel.CurrentPage);
            carQuerViewModel.Pager = pager;
            AllCarsSortedAndFilteredDataModel allCarsSortedAndFilteredDataModel = await carService.AllCarsSortedAndFilteredDataModelAsync(carQuerViewModel);
            carQuerViewModel.Cars = allCarsSortedAndFilteredDataModel.Cars;
            carQuerViewModel.Brands = await carService.GetAllBrandsAsync();
            return View(carQuerViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await carService.IsCarExistAsync(id))
            {
                return RedirectToAction(nameof(All));
            }
            CarDetailsViewModel carDetailsViewModel = await carService.FindCarByIdAsync(id);
            return View(carDetailsViewModel);
        }
        [HttpGet]
        public async Task<IActionResult>CarsByBrand(string brand = "", int id = 0)
        {
            IEnumerable<CarBrandViewModel> carsByBrand = await carService.GetCarsByBrandAsync(brand, id);
            return PartialView("_CarsByBrand", carsByBrand);
        }
    }
}
