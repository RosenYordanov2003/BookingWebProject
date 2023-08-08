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
        public const string AdminDashBoardCacheKey = "AdminDashBoardKey";
        public const int AdminDashBoardCacheDuration = 5;
        public const string AdminUsersCacheKey = "AllUsers";
        public const int AdminUsersDuration = 2;
        public const string UserInfoCacheKey = "UserInfoCacheKey-{0}";
        public const int UserInfoCacheDuration = 5;
        public const string HotelBenefitsCacheKey = "HotelBenefitsCacheKey";
        public const int HotelBenefitsCacheDuration = 5;
        public const string HotelCitisCacheKey = "HotelCities";
        public const int HotelCitiesDuration = 5;
        public const string HotelCountriesCacheKey = "HotelCountries";
        public const int HotelCountriesDuration = 5;
        public const string RentCarBrandsCacheKey = "BrandCacheKey";
        public const int RentCarBrandsCacheDuration = 5;
        public const string UserFavoriteHotelsCacheKey = "FavortieHotelsCacheKey-{0}";
        public const int UserFavoriteHotelsCacheDuration = 5;
        public const string UserReservationsCacheKey = "UserReservationCacheKey-{0}";
        public const int UserReservationsCacheDuration = 5;
    }
}
