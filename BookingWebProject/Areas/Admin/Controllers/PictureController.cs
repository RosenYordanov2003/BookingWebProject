namespace BookingWebProject.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Contracts;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    using static Common.GeneralAplicationConstants;
    public class PictureController : BaseAdminController
    {
        private readonly IPictureService pictureService;
        public PictureController(IPictureService pictureService)
        {
            this.pictureService = pictureService;
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int pictureId)
        {
            if (!await pictureService.CheckIsPictureExistByIdAsync(pictureId))
            {
                return NotFound();
            }
            if (!await pictureService.CheckIsPictureAlreadyDeleted(pictureId))
            {
                TempData[WarningMessage] = PictureIsAlreadyDeleted;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            try
            {
                await pictureService.DeletePictureAsync(pictureId);
                TempData[SuccessMessage] = SuccessfullyDeletedPicture;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Recover([FromForm] int pictureId)
        {
            if (!await pictureService.CheckIsPictureExistByIdAsync(pictureId))
            {
                return NotFound();
            }
            if (await pictureService.CheckPictureIsAlreadyRecoveredAsync(pictureId))
            {
                TempData[WarningMessage] = PictureIsAlreadyRecovered;
            }
            try
            {
                await pictureService.RecoverPictureAsync(pictureId);
                TempData[SuccessMessage] = SuccessfullyRecoveredPicture;
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
