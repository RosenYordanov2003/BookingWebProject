namespace BookingWebProject.Services.Tests
{
    using Data;
    using Infrastructure.Data.Enums;
    using Infrastructure.Data.Models;
    public static class DatabaseSeeder
    {
        public static Hotel hotel1;
        public static Hotel hotel2;
        public static Hotel hotel3;
        public static Hotel hotel4;

        public static RentCar car1;
        public static RentCar car2;

        public static Comment comment1;
        public static Comment comment2;

        public static RoomPackage roomPackage1;
        public static RoomPackage roomPackage2;
        public static RoomPackage roomPackage3;

        public static Benefit benefit1;
        public static Benefit benefit2;
        public static Benefit benefit3;
        public static Benefit benefit4;

        public static Room room1;
        public static Room room2;
        public static Room room3;

        public static RoomType roomType1;
        public static RoomType roomType2;
        public static RoomType roomType3;

        public static void SeedDatabase(BookingContext bookingContext)
        {


            bookingContext.Hotels.AddRange(SeedHotels());
            bookingContext.RentCars.AddRange(SeedRentCars());
            bookingContext.Comments.AddRange(SeedComments());
            bookingContext.RoomPackages.AddRange(SeedRoomPackages());
            bookingContext.Benefits.AddRange(SeedBenefits());
            bookingContext.RoomTypes.AddRange(SeedRoomTypes());
            bookingContext.Rooms.AddRange(SeedRooms());
            bookingContext.FavoriteHotels.AddRange(SeedFavoriteHotels());
            bookingContext.SaveChanges();
        }

        private static IEnumerable<Hotel> SeedHotels()
        {
            List<Hotel> hotels = new List<Hotel>();
            hotel1 = new Hotel()
            {
                Id = 1,
                Name = "Spa Hotel Dvoretsa",
                Country = "Bulgaria",
                City = "Velingrad",
                Description = "СПА хотел „Двореца” се намира във Велинград, в прегръдката на Родопите.Той е един от малкото 5-звездни спа хотели във Велинград. Поради благотворните свойства на минералните си извори и прекрасния климат градът не само се е доказал, но е и официално обявен за СПА столица на Балканите. Велинград предлага спокойствие и бягство от стреса на делника, живописни маршрути за разходка сред природата и разнообразие от възможности за забавление. СПА хотел „Двореца” е в съседство с красив боров парк и разкрива очарователна гледка към околните планини. Тук въздухът е чист, а басейните са с топла минерална вода през цялата година. Хотелът е предпочитано място за романтични почивки, тиймбилдинги и бизнес събития. „Двореца” е особено любимо място на семейства с деца, тъй като „Двореца” предлага разнообразие от забавления за най-малките си гости – детски басейн, водна пързалка, люлки и кът с аниматор, много играчки и игри. На Ваше разположение са сауна, парна баня и сауна.",
                StarRating = 5,
                Latitude = 42.032235406916385m,
                Longitude = 23.987805838924398m,
                IsDeleted = false,
                HotelBenefits = new List<HotelBenefits>()
                {
                    new HotelBenefits() { BenefitId = 1, HotelId = 1 },
                    new HotelBenefits() { BenefitId = 2, HotelId = 1 }
                },
                Reservations = new List<Reservation>()
                {
                    new Reservation()
                    {
                        Id = Guid.Parse("1A5B6A64-1A7A-4E88-90AE-011257E72A06"),
                        CountNights = 3,
                        StartDate = DateTime.Parse("2023-08-06 00:00:00.0000000"),
                        EndDate = DateTime.Parse("2023-08-09 00:00:00.0000000"),
                        FirstName = "Rosen",
                        LastName = "Yordanov",
                        PeopleCount = 1,
                        RentCarId = 18,
                        UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                        EmailAddress = "testuser123@gmail.com"
                    },
                    new Reservation()
                    {
                        Id = Guid.Parse("0FA904EF-7DE8-49BA-986F-9ECB1580A195"),
                        CountNights = 3,
                        StartDate = DateTime.Parse("2023-08-06 00:00:00.0000000"),
                        EndDate = DateTime.Parse("2023-08-09 00:00:00.0000000"),
                        FirstName = "Rosen",
                        LastName = "Yordanov",
                        PeopleCount = 3,
                        RoomId = 1,
                        UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                        EmailAddress = "testuser123@gmail.com"
                    },
                     new Reservation()
                     {
                        Id = Guid.Parse("10672AC6-1BF2-4FED-A4DF-09CC18298D07"),
                        CountNights = 3,
                        StartDate = DateTime.Parse("2023-08-06 00:00:00.0000000"),
                        EndDate = DateTime.Parse("2023-08-09 00:00:00.0000000"),
                        FirstName = "Rosen",
                        LastName = "Yordanov",
                        PeopleCount = 1,
                        RentCarId = 1,
                        UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                        EmailAddress = "testuser123@gmail.com"
                     },
                     new Reservation()
                     {
                        Id = Guid.Parse("B380CA76-B962-4EB6-9CB0-2BFDE906B5CC"),
                        CountNights = 2,
                        StartDate = DateTime.Parse("2023-07-25 00:00:00.0000000"),
                        EndDate = DateTime.Parse("2023-07-27 00:00:00.0000000"),
                        FirstName = "Rosen",
                        LastName = "Yordanov",
                        PeopleCount = 1,
                        RentCarId = 1,
                        UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                        EmailAddress = "testuser123@gmail.com"
                     }
                }
            };
            hotel2 = new Hotel()
            {
                Id = 2,
                City = "Velingrad",
                Country = "Bulgaria",
                Name = "Spa hotel Infinity",
                Description = "Добре дошли  в СПА ХОТЕЛ ИНФИНИТИ ПАРК ВЕЛИНГРАД  – място, където ще намерите комфорт и планинско спокойствие.\r\n\r\nНашият пет звезден хотел предлага 95 луксозни стаи и апартаменти, отлични конферентни съоръжения, изискана кухня и уникален спа център.\r\nЗакрити термални басейни /полуолимпийски плувен, акватоничен, детски, бебешки, ледено шоков и контрастен/,\r\nджакузи 3 бр., парна баня, билкова парна баня, приключенски душ, кнайп пътека, горска пътека, финландска сауна,\r\nбилкова сауна, инфрачервена сауна , солна баня, турска баня, японска баня, релакс зона, външни бани, фитнес,\r\nсезонен панорамен инфинити басейн, джакузи, сауна и открити басейни.",
                Latitude = 42.030206649356195m,
                Longitude = 23.979628495721478m,
                StarRating = 5,
                Reservations = new List<Reservation>()
                {
                    new Reservation()
                    {
                        Id = Guid.Parse("E09DB7FF-CD5F-4074-8991-FD5F54E98BAC"),
                        CountNights = 3,
                        StartDate = DateTime.Parse("2023-07-21 00:00:00.0000000"),
                        EndDate = DateTime.Parse("2023-07-24 00:00:00.0000000"),
                        FirstName = "Rosen",
                        LastName = "Yordanov",
                        PeopleCount = 1,
                        RentCarId = 1,
                        UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                        EmailAddress = "testuser123@gmail.com"
                    },
                     new Reservation()
                     {
                        Id = Guid.Parse("2E09A998-07AB-4997-8D86-FC7D7E85E390"),
                        CountNights = 2,
                        StartDate = DateTime.Parse("2023-08-03 00:00:00.0000000"),
                        EndDate = DateTime.Parse("2023-08-05 00:00:00.0000000"),
                        FirstName = "Rosen",
                        LastName = "Yordanov",
                        PeopleCount = 1,
                        RentCarId = 18,
                        UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                        EmailAddress = "testuser123@gmail.com"
                     },
                }
            };
            hotel3 = new Hotel()
            {
                Id = 3,
                City = "Sofia",
                Country = "Bulgaria",
                Name = "Hotel Marinela",
                Latitude = 42.67252787183476m,
                Longitude = 23.318956866924907m,
                Description = "Петзвездният хотел Маринела София е проектиран от известния японски архитект Кишо Курокава - автор на редица световни забележителности.\r\nХотелът е разположен на площ от 30 000 кв.м. Нашите 442 стаи и апартаменти, включително най-големият президентски апартамент в България, предлагат лукс & комфорт с прекрасен изглед към града и планината.\r\nС общо 10 мултифукнционални зали, сред които една от най-големите бални и конферентни зали в града и забележително зала на последния етаж.\r\nХотел Маринела е сред емблематичните сгради в София и уникално място за Балканския полуостров. Това е точното място за бягство от натоварения градски живот, като същевременно се намира в самия център на града.",
                StarRating = 5,
                Reservations = new List<Reservation>()
                {
                    new Reservation()
                    {
                        Id = Guid.Parse("C93B9E3F-9EA2-4C91-9014-6E84618798C4"),
                        CountNights = 3,
                        StartDate = DateTime.Parse("2023-08-03 00:00:00.0000000"),
                        EndDate = DateTime.Parse("2023-08-05 00:00:00.0000000"),
                        FirstName = "Rosen",
                        LastName = "Yordanov",
                        PeopleCount = 1,
                        RentCarId = 18,
                        UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                        EmailAddress = "testuser123@gmail.com"
                    }
                },
                HotelBenefits = new List<HotelBenefits>()
                {
                    new HotelBenefits() { BenefitId = 1, HotelId = 3 },
                    new HotelBenefits() { BenefitId = 2, HotelId = 3 }
                },
            };
            hotel4 = new Hotel()
            {
                Id = 4,
                City = "Milan",
                Country = "Italy",
                Name = "NH Collection Milano Porta Nuova",
                StarRating = 4,
                Latitude = 45.48175408930197m,
                Longitude = 9.1916942539707m,
                Description = "The NH Collection Milano Porta Nuova, formerly NH Milano Grand Hotel Verdi, stands in an extraordinary position near Porta Nuova, the new business district of the city, also renowned for its lively nightlife and cultural activities. The center of Milan is a short distance away and can be easily reached by taxi, underground and train connections in the vicinity of the hotel.",
            };

            hotels.Add(hotel1);
            hotels.Add(hotel2);
            hotels.Add(hotel3);
            hotels.Add(hotel4);

            return hotels;
        }
        private static IEnumerable<RentCar> SeedRentCars()
        {
            List<RentCar> rentCars = new List<RentCar>();

            car1 = new RentCar()
            {
                Id = 1,
                MakeType = "Bmw",
                ModelType = "X6",
                Year = 2020,
                DoorsCount = 4,
                CarImg = "/img/Cars/BmwX6 Blue.jpeg",
                PricePerDay = 180,
                FuelCapacity = 85,
                FuelConsumption = 13.4,
                Location = "Velingrad",
                Lattitude = 42.026543162263934m,
                Longitude = 23.991291982406658m,
                TransmissionType = TransmissionType.AutomaticTransmission,
                PeopleCapacity = 4,
            };
            car2 = new RentCar()
            {
                Id = 18,
                MakeType = "Bmw",
                ModelType = "X6",
                Year = 2019,
                DoorsCount = 4,
                CarImg = "/img/Cars/Bmw X6 2021 Maroon.jpg",
                PricePerDay = 170,
                FuelCapacity = 85,
                FuelConsumption = 13.4,
                Location = "Milano",
                Lattitude = 45.43995264548058m,
                Longitude = 9.20198333778624m,
                TransmissionType = TransmissionType.AutomaticTransmission,
                PeopleCapacity = 4,
            };

            rentCars.Add(car1);
            rentCars.Add(car2);
            return rentCars;
        }
        private static IEnumerable<Comment> SeedComments()
        {
            List<Comment> comments = new List<Comment>();

            comment1 = new Comment()
            {
                Id = 1,
                HotelId = 1,
                Description = "Test comment1",
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                IsDeleted = false,
                UserName = "Test User"
            };

            comment2 = new Comment()
            {
                Id = 2,
                HotelId = 1,
                Description = "Test comment2",
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                IsDeleted = false,
                UserName = "Test User"
            };

            comments.Add(comment1);
            comments.Add(comment2);

            return comments;
        }
        private static IEnumerable<RoomPackage> SeedRoomPackages()
        {
            List<RoomPackage> roomPackages = new List<RoomPackage>();

            roomPackage1 = new RoomPackage()
            {
                Id = 1,
                Name = "Breakfast",
                Price = 0,
            };
            roomPackage2 = new RoomPackage()
            {
                Id = 2,
                Name = "Breakfast and Dinner",
                Price = 70,
            };
            roomPackage3 = new RoomPackage()
            {
                Id = 3,
                Name = "All Inclusive",
                Price = 100
            };

            roomPackages.Add(roomPackage1);
            roomPackages.Add(roomPackage2);
            roomPackages.Add(roomPackage3);

            return roomPackages;
        }
        private static IEnumerable<Benefit> SeedBenefits()
        {
            List<Benefit> benefits = new List<Benefit>();

            benefit1 = new Benefit()
            {
                Id = 1,
                Name = "Allow pets",
                ClassIcon = "fa-solid fa-dog",
            };
            benefit2 = new Benefit()
            {
                Id = 2,
                Name = "Spa",
                ClassIcon = "fa-solid fa-hot-tub-person",
            };
            benefit3 = new Benefit()
            {
                Id = 3,
                Name = "Room service",
                ClassIcon = "fa-solid fa-bell-concierge"
            };
            benefit4 = new Benefit()
            {
                Id = 4,
                Name = "Gym",
                ClassIcon = "fa-solid fa-dumbbell"
            };
            benefits.Add(benefit1);
            benefits.Add(benefit2);
            benefits.Add(benefit3);
            benefits.Add(benefit4);

            return benefits;
        }
        private static IEnumerable<RoomType> SeedRoomTypes()
        {
            List<RoomType> roomTypes = new List<RoomType>();

            roomType1 = new RoomType()
            {
                Id = 1,
                Name = "Apartment",
                IncreasePercentage = 40,
            };
            roomType2 = new RoomType()
            {
                Id = 2,
                Name = "Studio",
                IncreasePercentage = 35
            };
            roomType3 = new RoomType()
            {
                Id = 3,
                Name = "Double bed",
                IncreasePercentage = 30
            };
            roomTypes.Add(roomType1);
            roomTypes.Add(roomType2);
            roomTypes.Add(roomType3);

            return roomTypes;
        }
        private static IEnumerable<Room> SeedRooms()
        {
            List<Room> rooms = new List<Room>();

            room1 = new Room()
            {
                Id = 1,
                RoomTypeId = 1,
                PricePerNight = 190,
                HotelId = 1,
                Capacity = 2,
                Description = "Test description"
            };
            room2 = new Room()
            {
                Id = 2,
                RoomTypeId = 2,
                PricePerNight = 190,
                HotelId = 1,
                Capacity = 4,
                Description = "Test description"
            };
            room3 = new Room()
            {
                Id = 3,
                HotelId = 1,
                RoomTypeId = 3,
                PricePerNight = 200,
                Capacity = 2,
                Description = "Test description"
            };

            rooms.Add(room1);
            rooms.Add(room2);
            rooms.Add(room3);

            return rooms;
        }
        private static IEnumerable<FavoriteHotels> SeedFavoriteHotels()
        {
            List<FavoriteHotels> favoriteHotels = new List<FavoriteHotels>()
            {
                new FavoriteHotels()
                {
                    HotelId = 1,
                    UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254")
                },
                new FavoriteHotels()
                {
                    HotelId = 2,
                    UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254")
                }
            };

            return favoriteHotels;
        }
    }
}
