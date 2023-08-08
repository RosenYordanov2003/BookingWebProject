﻿namespace BookingWebProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using System.Security.Claims;
    using Core.Contracts;
    using Infrastructure.Data.Models;
    using Extensions;
    using Core.Models.User;
    using Core.Models.Hotel;
    using Core.Models.Reservation;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;

    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public UserController(IUserService userService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
                UserInfoViewModel userInfoViewModel = await userService.GetUserInfoByIdAsync(id);
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
                        Claim claim = this.User.Claims.FirstOrDefault(c => c.Type == "ProfilePicturePath");
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
                Claim claim = this.User.Claims.FirstOrDefault(c => c.Type == "ProfilePicturePath");
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
                IEnumerable<HotelViewModel> userHotels = await userService.GetUserFavoriteHotelsAsync(id);
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
                IEnumerable<UserReservationViewModel> userReservations = await userService.GetUserReservationsAsync(id);
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
