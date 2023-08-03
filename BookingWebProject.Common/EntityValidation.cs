namespace BookingWebProject.Common
{
    public static class EntityValidation
    {
        public static class UserEntity
        {
            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 35;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 30;

            public const int FirstNameMinValue = 3;
            public const int FirstNameMaxValue = 15;

            public const int LastNameMinValue = 4;
            public const int LastNameMaxValue = 15;

            public const int EmailAddressMinValue = 10;
            public const int EmailAddressMaxValue = 30;

            public const int PhoneNumberMaxLength = 20;
        }
        public static class RentCarEntity
        {
            public const int MakeTypeMinLength = 3;
            public const int MakeTypeMaxLength = 25;

            public const int ModelTypeMinLength = 2;
            public const int ModelTypeMaxLength = 51;

            public const int MinYear = 1970;
            public const int MaxYear = 2023;

            public const int MinDoorsCount = 2;
            public const int MaxDoorsCount = 4;

            public const int MinPeopleCapacity = 2;
            public const int MaxPeopleCapacity = 6;

            public const int TransmissionTypeMinValue = 0;
            public const int TransmissionTypeMaxValue = 1;

            public const double MinFuelCapacityValue = 20;
            public const double MaxFuelCapacityValue = 100;

            public const double MinFuelConsuptionValue = 5;
            public const double MaxFuelConsuptionValue = 22;

            public const int MinPriceValue = 10;

            public const int LocationMinValue = 4;
            public const int LocationMaxValue = 100;

        }
        public static class HotelEntity
        {
            public const int MinCountryValue = 4;
            public const int MaxCountryValue = 56;

            public const int MinStarValue = 1;
            public const int MaxStarValue = 5;

            public const int MinHotelNameValue = 4;
            public const int MaxHotelNameValue = 40;

            public const int MaxDescriptionValue = 2000;

            public const int MaxCityValue = 58;
            public const int MinCityValue = 4;
        }
        public static class RoomEntity
        {
            public const int MinRoomCapacity = 1;
            public const int MaxRoomCapacity = 5;

            public const int DescriptionMinLength = 15;
            public const int MaxDescriptionValue = 1900;

            public const decimal MinPricePerNightValue = 30;
        }
        public static class RoomTypeEntity
        {
            public const int RoomTypeNameMinValue = 5;
            public const int RoomTypeNameMaxValue = 25;
        }
        public static class ReservationEntity
        {
            public const int MinCountNightsValue = 1;

            public const int UserFirstNameMinValue = 3;
            public const int UserFirstNameMaxValue = 15;

            public const int UserLastNameMinValue = 4;
            public const int UserLastNameMaxValue = 15;

            public const int UserEmailAddressMinValue = 10;
            public const int UserEmailAddressMaxValue = 30;
        }
        public static class CommentEntity
        {
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 50;
        }
        public static class RoomPackageEntity
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 20;
        }
        public static class ReservationCarEntity
        {
            public const int MinYear = 2000;
            public const int MaxYear = 2023;

            public const double DoorsMinCount = 2;
            public const double DoorsMaxCount = 6;

            public const string MinPriceAsDecimal = "10";
            public const string MaxPriceAsDecimal = "100000";
        }
    }
}
