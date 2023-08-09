namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Caching.Memory;
    using System.Security.Claims;
    using Core.Contracts;
    using Infrastructure.Data.Models;
    using Extensions;
    using Core.Models.User;
    using Core.Models.Hotel;
    using Core.Models.Reservation;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMemoryCache memoryCache;
        public UserController(IUserService userService, UserManager<User> userManager,
            SignInManager<User> signInManager, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.memoryCache = memoryCache;
        }
        [HttpGet]
        public async Task<IActionResult> Personalization(Guid id)
        {
            if (id != this.User.GetId())
            {
                return Unauthorized();
            }
            try
            {
                string cacheKey = string.Format(UserInfoCacheKey, id);
                UserInfoViewModel userInfoViewModel = this.memoryCache.Get<UserInfoViewModel>(cacheKey);
                if (userInfoViewModel == null)
                {
                    userInfoViewModel = await userService.GetUserInfoByIdAsync(id);
                    MemoryCacheEntryOptions opt = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(UserInfoCacheDuration));
                    this.memoryCache.Set(cacheKey, userInfoViewModel, opt);
                }
                return View(userInfoViewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Personalization(UserInfoViewModel userInfoViewModel)
        {
            if (userInfoViewModel.ProfilePictureFile != null)
            {
                string fileExtension = Path.GetExtension(userInfoViewModel.ProfilePictureFile.FileName).ToLower();
                if (!string.IsNullOrWhiteSpace(userInfoViewModel.ProfilePicturePath))
                {
                    await userService.DeleteUserProfilePictureAsync(this.User.GetId(), userInfoViewModel.ProfilePicturePath);
                }
                userInfoViewModel.ProfilePicturePath = await userService.UploadUserImageAsync(userInfoViewModel, this.User.GetId());

                try
                {
                    User user = await userManager.FindByIdAsync(this.User.GetId().ToString());
                    await userService.SaveUserInfoAsync(this.User.GetId(), userInfoViewModel);
                    Claim userNameClaim = new Claim("ProfilePicturePath", userInfoViewModel.ProfilePicturePath);
                    if (this.User.HasClaim(c => c.Type == "ProfilePicturePath"))
                    {
                        Claim claim = this.User.Claims.FirstOrDefault(c => c.Type == "ProfilePicturePath")!;
                        await userManager.RemoveClaimAsync(user, claim);
                    }
                    TempData[SuccessMessage] = SuccessfullyUpdatedAccount;
                    await userManager.AddClaimAsync(user, userNameClaim);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    TempData[ErrorMessage] = DefaultErrorMessage;
                    return RedirectToAction("Index", "Home");
                }
            }
            try
            {
                await userService.SaveUserInfoAsync(this.User.GetId(), userInfoViewModel);
                TempData[SuccessMessage] = SuccessfullyUpdatedAccount;
                string cacheKey = string.Format(UserInfoCacheKey, userInfoViewModel.Id);
                this.memoryCache.Remove(cacheKey);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveProfilePicture(string path)
        {
            await userService.DeleteUserProfilePictureAsync(this.User.GetId(), path);

            User user = await userManager.FindByIdAsync(this.User.GetId().ToString());
            if (this.User.HasClaim(c => c.Type == "ProfilePicturePath"))
            {
                Claim claim = this.User.Claims.FirstOrDefault(c => c.Type == "ProfilePicturePath")!;
                TempData[SuccessMessage] = SuccessfullyRemovedProfilePicture;

                await userManager.RemoveClaimAsync(user, claim);
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> UserFavoriteHotels(Guid id)
        {
            if (this.User.GetId() != id)
            {
                return Unauthorized();
            }
            try
            {
                string cacheKey = string.Format(UserFavoriteHotelsCacheKey, id);
                IEnumerable<HotelViewModel> userHotels = this.memoryCache.Get<IEnumerable<HotelViewModel>>(cacheKey);
                if (userHotels == null)
                {
                    userHotels = await userService.GetUserFavoriteHotelsAsync(id);
                    MemoryCacheEntryOptions opt = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(UserFavoriteHotelsCacheDuration));
                    this.memoryCache.Set(cacheKey, userHotels, opt);
                }
                return View(userHotels);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> UserReservations(Guid id)
        {
            if (this.User.GetId() != id)
            {
                return Unauthorized();
            }
            try
            {
                string cacheKey = string.Format(UserReservationsCacheKey, id);
                IEnumerable<UserReservationViewModel> userReservations = this.memoryCache.Get<IEnumerable<UserReservationViewModel>>(cacheKey);
                if (userReservations == null)
                {
                    userReservations = await userService.GetUserReservationsAsync(id);
                    MemoryCacheEntryOptions opt = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(UserReservationsCacheDuration));
                    this.memoryCache.Set(cacheKey, userReservations, opt);
                }
                return View(userReservations);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
