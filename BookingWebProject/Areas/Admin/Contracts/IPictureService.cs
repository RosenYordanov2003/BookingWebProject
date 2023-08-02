namespace BookingWebProject.Areas.Admin.Contracts
{
    public interface IPictureService
    {
         Task<bool> CheckIsPictureExistByIdAsync(int pictureId);
         Task DeletePictureAsync(int pictureId);
         Task RecoverPictureAsync(int pictureId);
         Task<bool> CheckIsPictureAlreadyDeleted(int pictureId);
        Task<bool> CheckPictureIsAlreadyRecoveredAsync(int pictureId);

    }
}
