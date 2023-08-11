namespace BookingWebProject.Controllers
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using Core.Models.Pager;
    using Core.Models.RentCar;
    using static Common.GeneralAplicationConstants;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;

    public class RentCarController : Controller
    {
        private readonly IRentCarService carService;
        private readonly IMemoryCache memoryCache;
        public RentCarController(IRentCarService carService, IMemoryCache memoryCache)
        {
            this.carService = carService;
            this.memoryCache = memoryCache;
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
            IEnumerable<string> brands = this.memoryCache.Get<IEnumerable<string>>(RentCarBrandsCacheKey);
            if (brands == null)
            {
                brands = await carService.GetAllBrandsAsync();
                MemoryCacheEntryOptions opt = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(RentCarBrandsCacheDuration));
                this.memoryCache.Set(RentCarBrandsCacheKey, brands, opt);
            }
            carQuerViewModel.Brands = brands;
            return View(carQuerViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (!await carService.CheckIfCarExistByIdAsync(id))
                {
                    return RedirectToAction(nameof(All));
                }
                string key = string.Format(RentCarCacheKey, id);
                CarDetailsViewModel carDetailsViewModel = memoryCache.Get<CarDetailsViewModel>(key);
                if (carDetailsViewModel == null)
                {
                    carDetailsViewModel = await carService.FindCarByIdAsync(id);
                    MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(RentCarDetailsCacheTimeDuration));
                    memoryCache.Set(key, carDetailsViewModel, memoryCacheEntryOptions);
                }
                return View(carDetailsViewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction(nameof(All));
            }
           
        }
        [HttpGet]
        public async Task<IActionResult>CarsByBrand(string brand = "", int id = 0)
        {
            try
            {
                IEnumerable<CarBrandViewModel> carsByBrand = await carService.GetCarsByBrandAsync(brand, id);
                return PartialView("_CarsByBrand", carsByBrand);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction(nameof(All));
            }
        }
    }
}
