namespace BookingWebProject.Common
{
    public static class NotificationMessages
    {
        public const string CarIsAlreadyRentedInThisPeriodMsg = "Car is already rented for period {0} - {1}";
        public const string SuccessfullRentCarMsg = "You have successfully rented your car for period {0} - {1}";
        public const string CarDoesNotExist = "Car with this id does not exist";
        public const string DefaultErrorMessage = "Something went wrong, please try again later or contact us";
        public const string HotelDoesNotExist = "Hotel with this id does not exist";
        public const string SuccessfullyAddHotelToUserFavorites = "You have successfully add hotel to your favorite hotels";
        public const string SuccessfullyRemoveHotelFromUserFavoriteHotels = "You have successfully remove hotel from your favorite hotels";
        public const string SuccessFullyPostedComment = "You have successfully posted your comment";
        public const string CommentDoesNotExist = "Comment with this id does not exist";
        public const string SuccessEditedComment = "Your comment was successfully edited";
        public const string SuccessRemoveMessage = "You have successfully deleted your comment";
        public const string NoAvalilableRoom = "There is no available room for this period";
        public const string SuccessBookedRoom = "You have successfully booked a room";
        public const string HotelIsAlreadyDeleted = "Hotel with this id is already deleted";
        public const string SuccessfullyDeletedHotel = "You have successfully deleted hotel";
        public const string SuccessfullyRecoveredHotel = "You have successfully recovered hotel";
    }
}
