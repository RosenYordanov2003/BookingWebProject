namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Hotel.DataModels;
    using Contracts;
    using Models.Hotel;
    using Core.Contracts;
    using Core.Models.Pager;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    using Microsoft.Extensions.Caching.Memory;
    using BookingWebProject.Areas.Admin.Models.User;

    public class HotelController : BaseAdminController
    {
        private readonly IHotelAdminService hotelAdminService;
        private readonly IHotelService hotelService;
        private readonly IBenefitAdminService benefitAdminService;
        private readonly IBenefitService benefitService;
        private readonly IRoomAdminService roomAdminService;
        private readonly IMemoryCache memoryCache;
        private readonly IUserAdminService userAdminService;
        public HotelController(IHotelAdminService hotelAdminService, IHotelService hotelService
            , IBenefitAdminService benefitAdminService, IBenefitService benefitService,
            IRoomAdminService roomAdminService, IMemoryCache memoryCache, IUserAdminService userAdminService)
        {
            this.hotelService = hotelService;
            this.hotelAdminService = hotelAdminService;
            this.benefitAdminService = benefitAdminService;
            this.benefitService = benefitService;
            this.roomAdminService = roomAdminService;
            this.memoryCache = memoryCache;
            this.userAdminService = userAdminService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int pg = 1)
        {
            if (pg <= 0)
            {
                pg = 1;
            }
            try
            {
                int totalHotelsCount = await hotelAdminService.GetAllHotelsCountAsync();
                Pager pager = new Pager(totalHotelsCount, pg);
                HotelDataModel hotelDataModel = new HotelDataModel()
                {
                    AllHotles = await hotelAdminService.GetAllHotelsAsync(pager),
                    Pager = pager
                };
                return View(hotelDataModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int hotelId)
        {
            if (!await hotelService.CheckIsHotelExistAsync(hotelId))
            {
                return NotFound();
            }
            try
            {
                if (await hotelAdminService.CheckIfHotelIsAlredyDeletedAsync(hotelId))
                {
                    TempData[WarningMessage] = HotelIsAlreadyDeleted;
                }
                else
                {
                    await hotelAdminService.DeleteHotelByIdAsync(hotelId);
                    this.memoryCache.Remove(HotelCountriesCacheKey);
                    this.memoryCache.Remove(HotelCitisCacheKey);
                    await ClearCache();
                    TempData[SuccessMessage] = SuccessfullyDeletedHotel;
                }
                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Recover([FromForm] int hotelId)
        {
            if (!await hotelAdminService.CheckIfHotelForRecoverExistByIdAsync(hotelId))
            {
                return NotFound();
            }
            try
            {
                await hotelAdminService.RecoverHotelByIdAsync(hotelId);
                this.memoryCache.Remove(HotelCountriesCacheKey);
                this.memoryCache.Remove(HotelCitisCacheKey);
                TempData[SuccessMessage] = SuccessfullyRecoveredHotel;
                await ClearCache();

                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await hotelService.CheckIsHotelExistAsync(id) && !await hotelAdminService.CheckIfHotelForRecoverExistByIdAsync(id))
            {
                return NotFound();
            }
            try
            {
                EditHotelViewModel editHotelViewModel = await hotelAdminService.GetHotelToEditAsync(id);
                editHotelViewModel.BenefitsToAdd = await benefitAdminService.GetOtherBenefitsAsync(id);
                editHotelViewModel.Rooms = await roomAdminService.GetRoomTypesInHotelByHotelIdAsync(id);
                return View(editHotelViewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditHotelViewModel editHotelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editHotelViewModel);
            }
            if (!await hotelService.CheckIsHotelExistAsync(id) && !await hotelAdminService.CheckIfHotelForRecoverExistByIdAsync(id))
            {
                return NotFound();
            }
            try
            {
                await hotelAdminService.EditHotelByIdAsync(id, editHotelViewModel);
                TempData[SuccessMessage] = SuccesfullyEditedHotel;
                this.memoryCache.Remove(HotelCountriesCacheKey);
                this.memoryCache.Remove(HotelCitisCacheKey);
                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveHotelBenefit([FromForm] int benefitId, int hotelId)
        {
            try
            {
                if (!await hotelAdminService.CheckIsHotelBenefitExistAsync(benefitId, hotelId))
                {
                    return NotFound();
                }
                if (!await hotelAdminService.CheckIsHotelBenefitIsAlreadyDeletedAsync(benefitId, hotelId))
                {
                    TempData[WarningMessage] = HotelBenefitIsAlreadyDeleted;
                    return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
                }
                await hotelAdminService.DeleteHotelBenefitAsync(benefitId, hotelId);
                TempData[SuccessMessage] = SuccessfullyDeleteHotelBenefit;

                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        [HttpGet]
        public async Task<IActionResult> CreateHotel()
        {
            CreateHotelViewModel createHotelViewModel = new CreateHotelViewModel();
            createHotelViewModel.AllBenefits = await benefitService.GetAllBenefitsAsync();

            return View(createHotelViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHotel(CreateHotelViewModel createHotelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createHotelViewModel);
            }
            try
            {
                await hotelAdminService.CreateHotelAsync(createHotelViewModel);
                TempData[SuccessMessage] = SuccessfullyCreatedHotel;
                this.memoryCache.Remove(HotelCountriesCacheKey);
                this.memoryCache.Remove(HotelCitisCacheKey);
                if (createHotelViewModel.PicturesFileProvider != null && createHotelViewModel.PicturesFileProvider.Count > 0)
                {
                    await hotelAdminService.CreateHotelImgsAsync(createHotelViewModel);
                }
                return RedirectToAction("Index", "Hotel", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
        }
        private async Task ClearCache()
        {
            IEnumerable<AllUsersViewModel> allUsers = this.memoryCache.Get<IEnumerable<AllUsersViewModel>>(AdminUsersCacheKey);
            if (allUsers == null)
            {
                allUsers = await userAdminService.GetAllUsersAsync();
                MemoryCacheEntryOptions memoryCacheOptions = new MemoryCacheEntryOptions()
                   .SetAbsoluteExpiration(TimeSpan.FromMinutes(AdminUsersDuration));
                this.memoryCache.Set(AdminUsersCacheKey, allUsers, memoryCacheOptions);
            }
            foreach (AllUsersViewModel user in allUsers)
            {
                this.memoryCache.Remove(string.Format(UserFavoriteHotelsCacheKey, user.Id));
            }
        }
    }
}
