namespace BookingWebProject.Common
{
    public static class GeneralAplicationConstants
    {
        public const int DefaultPageSize = 5;
        public const string AdminRoleName = "Administrator";
        public const string AdminAreaName = "Admin";
        public const string ModeratorRoleName = "Moderator";
        public const string HomePageCacheKey = "HomeCache";
        public const int HomePageCacheDurationMinuties = 5;
        public const string RentCarCacheKey = "Details-{0}";
        public const int RentCarDetailsCacheTimeDuration = 5;
        public const string RoomPackageCacheKey = "RoomPackageCache";
        public const int RoomPackageCacheDuration = 5;
        public const string HotelRoomsCacheKey = "HotelRooms-{0}";
        public const int HotelRoomsCacheDuration = 5;
    }
}
