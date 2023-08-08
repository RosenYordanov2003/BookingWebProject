﻿namespace BookingWebProject.Controllers
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using Core.Models.Pager;
    using Core.Models.RentCar;
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
            string key = string.Format(RentCarCacheKey, id);
            CarDetailsViewModel carDetailsViewModel = memoryCache.Get<CarDetailsViewModel>(key);
            if (carDetailsViewModel == null)
            {
                carDetailsViewModel = await carService.FindCarByIdAsync(id);
                MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(RentCarDetailsCacheTimeDuration));
                memoryCache.Set(key,carDetailsViewModel, memoryCacheEntryOptions);
            }
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
