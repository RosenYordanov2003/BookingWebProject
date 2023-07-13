namespace BookingWebProject.Infrastructure.Data.Configurations
{
    using BookingWebProject.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PictureEntityConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasOne(p => p.Room)
                 .WithMany(r => r.Pictures)
                 .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Hotel)
                .WithMany(h => h.Pictures)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.User)
                .WithOne(u => u.ProfilePicture)
                .OnDelete(DeleteBehavior.NoAction);

            ICollection<Picture> pictures = CreatePictures();
            builder.HasData(pictures);
        }

        private ICollection<Picture> CreatePictures()
        {
            List<Picture> pictures = new List<Picture>()
            {
                new Picture()
                {
                    Id = 1,
                    HotelId = 1,
                    Path = "/img/Hotels/Spa Hotel Dvoretsa/Spa Hotel Dvoretsa.jpg"
                },
                new Picture()
                {
                    Id = 2,
                    HotelId = 1,
                    Path = "/img/Hotels/Spa Hotel Dvoretsa/Spa Hotel Dvoretsa2.jpg"
                },
                new Picture()
                {
                    Id = 3,
                    HotelId = 1,
                    Path = "/img/Hotels/Spa Hotel Dvoretsa/Spa Hotel Dvoretsa3.jpg"
                },
                new Picture()
                {
                    Id = 4,
                    HotelId = 1,
                    Path = "/img/Hotels/Spa Hotel Dvoretsa/Spa Hotel Dvoretsa4.jpg"
                },
                new Picture()
                {
                    Id = 5,
                    RoomId = 1,
                    Path = "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvorestsa SingleRoom.jpg",
                },
                new Picture()
                {
                    Id = 6,
                    RoomId = 1,
                    Path = "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvorestsa SingleRoom2.jpg",
                },
                new Picture()
                {
                    Id = 7,
                    RoomId = 2,
                    Path = "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvoretsa Double Bed.jpg",
                },
                new Picture()
                {
                    Id = 8,
                    RoomId = 2,
                    Path = "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvoretsa Double Bed2.jpg",
                },
                new Picture()
                {
                    Id = 9,
                    RoomId = 3,
                    Path = "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvoretsa Apartment.jpg"
                },
                 new Picture()
                 {
                    Id = 10,
                    RoomId = 3,
                    Path = "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvoretsa Apartment2.jpg",
                 },
                 new Picture()
                 {
                     Id = 11,
                     HotelId = 2,
                     Path = "/img/Hotels/Spa Hotel Infinity/Spa Hotel Infinity.jpg"
                 },
                 new Picture()
                 {
                     Id = 12,
                     HotelId = 2,
                     Path = "/img/Hotels/Spa Hotel Infinity/Spa Hotel Infinity2.jpg"
                 },
                 new Picture()
                 {
                     Id = 13,
                     HotelId = 2,
                     Path = "/img/Hotels/Spa Hotel Infinity/Spa Hotel Infinity3.jpg"
                 },
                 new Picture()
                 {
                     Id = 14,
                     RoomId = 4,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Infinity single room1.webp"
                 },
                 new Picture()
                 {
                     Id = 15,
                     RoomId = 4,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Infinity single room2.webp"
                 },
                 new Picture()
                 {
                     Id = 16,
                     RoomId = 4,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Infinity single room3.webp"
                 },
                 new Picture()
                 {
                     Id = 17,
                     RoomId = 5,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Infinity single room3.webp"
                 },
                 new Picture()
                 {
                     Id = 18,
                     RoomId = 5,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity double bed1.jpg"
                 },
                 new Picture()
                 {
                     Id = 19,
                     RoomId = 5,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity double bed2.jpg"
                 },
                 new Picture()
                 {
                     Id = 20,
                     RoomId = 5,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity double bed3.jpg"
                 },
                 new Picture()
                 {
                     Id = 21,
                     RoomId = 6,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity apartment1.jpg"
                 },
                 new Picture()
                 {
                     Id = 22,
                     RoomId = 6,
                      Path = "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity apartment2.jpg"
                 },
                 new Picture()
                 {
                     Id = 23,
                     RoomId = 6,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity apartment3.jpg"
                 },
                 new Picture()
                 {
                     Id = 24,
                     RoomId = 7,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity house1.jpg",
                 },
                 new Picture()
                 {
                     Id = 25,
                     RoomId = 7,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity house2.jpg",
                 },
                 new Picture()
                 {
                     Id = 26,
                     RoomId = 7,
                     Path = "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity house3.jpg",
                 },
                 new Picture()
                 {
                     Id = 27,
                     HotelId = 3,
                     Path = "/img/Hotels/Hotel Marinela/Hotel Marinela1.jpg"
                 },
                 new Picture()
                 {
                     Id = 28,
                     HotelId = 3,
                     Path = "/img/Hotels/Hotel Marinela/Hotel Marinela2.jpg"
                 },
                 new Picture()
                 {
                     Id = 29,
                     HotelId = 3,
                     Path = "/img/Hotels/Hotel Marinela/Hotel Marinela3.jpg"
                 },
                 new Picture()
                 {
                     Id = 30,
                     RoomId = 8,
                     Path = "/img/Rooms/Hotel Marinela rooms/Hotel Marinela siglebed1.webp"
                 },
                 new Picture()
                 {
                     Id = 31,
                     RoomId = 8,
                     Path = "/img/Rooms/Hotel Marinela rooms/Hotel Marinela siglebed2.webp"
                 },
                 new Picture()
                 {
                     Id = 32,
                     RoomId = 9,
                     Path = "/img/Rooms/Hotel Marinela rooms/Hotel Marinela doublebed.webp"
                 },
                 new Picture()
                 {
                     Id = 33,
                     RoomId = 9,
                     Path = "/img/Rooms/Hotel Marinela rooms/Hotel Marinela doublebed2.webp"
                 },
                 new Picture()
                 {
                     Id = 34,
                     RoomId = 10,
                     Path = "/img/Rooms/Hotel Marinela rooms/Hotel Marinela apartment1.webp",
                 },
                 new Picture()
                 {
                     Id = 35,
                     RoomId = 10,
                     Path = "/img/Rooms/Hotel Marinela rooms/Hotel Marinela apartment2.webp"
                 },
                 new Picture()
                 {
                     Id = 36,
                     RoomId = 10,
                     Path = "/img/Rooms/Hotel Marinela rooms/Hotel Marinela apartment3.webp"
                 },
                 new Picture()
                 {
                     Id = 37,
                     HotelId = 4,
                     Path = "/img/Hotels/NH Collection Milano Porta Nuova/Porta Nuova.jpg"
                 },
                 new Picture()
                 {
                     Id = 38,
                     RoomId = 11,
                     Path = "/img/Rooms/Porta Nuova rooms/Porta Nuova doublebed1.jpg"
                 },
                 new Picture()
                 {
                     Id = 39,
                     RoomId = 11,
                     Path = "/img/Rooms/Porta Nuova rooms/Porta Nuova doublebed2.jpg"
                 },
                 new Picture()
                 {
                     Id = 40,
                     RoomId = 11,
                     Path = "/img/Rooms/Porta Nuova rooms/Porta Nuova doublebed3.jpg"
                 },
                 new Picture()
                 {
                     Id = 41,
                     RoomId = 12,
                     Path = "/img/Rooms/Porta Nuova rooms/Porta Nuova singlebed1.jpg"
                 },
                 new Picture()
                 {
                     Id = 42,
                     RoomId = 12,
                     Path = "/img/Rooms/Porta Nuova rooms/Porta Nuova singlebed2.jpg"
                 },
                 new Picture()
                 {
                     Id = 43,
                     RoomId = 13,
                     Path = "/img/Rooms/Porta Nuova rooms/Porta Nuova aapartment1.jpg"
                 },
                 new Picture()
                 {
                     Id = 44,
                     RoomId = 13,
                     Path = "/img/Rooms/Porta Nuova rooms/Porta Nuova apartment2.jpg"
                 },
                 new Picture()
                 {
                     Id = 45,
                     RoomId = 13,
                     Path = "/img/Rooms/Porta Nuova rooms/Porta Nuova aapartment3.jpg"
                 },
                 new Picture()
                 {
                     Id = 46,
                     HotelId = 5,
                     Path = "/img/Hotels//Paradise Blue/Paradaise Albena1.jpg"
                 },
                 new Picture()
                 {
                     Id = 47,
                     HotelId = 5,
                     Path = "/img/Hotels//Paradise Blue/Paradaise Albena2.jpg"
                 },
                 new Picture()
                 {
                     Id = 48,
                     HotelId = 5,
                     Path = "/img/Hotels//Paradise Blue/Paradaise Albena3.jpg"
                 },
                 new Picture()
                 {
                     Id = 49,
                     RoomId = 14,
                     Path = "/img/Rooms/Paradise rooms/Paradise doublebed1.jpg"
                 },
                 new Picture()
                 {
                     Id = 50,
                     RoomId = 14,
                     Path = "/img/Rooms/Paradise rooms/Paradise double bed2.jpg"
                 },
                 new Picture()
                 {
                     Id = 51,
                     RoomId = 15,
                     Path = "/img/Rooms/Paradise rooms/Paradise stuido1.jpg"
                 },
                 new Picture()
                 {
                     Id = 52,
                     RoomId = 15,
                     Path = "/img/Rooms/Paradise rooms/Paradise studio2.jpg"
                 },
                 new Picture()
                 {
                     Id = 53,
                     RoomId = 15,
                     Path = "/img/Rooms/Paradise rooms/Paradise studio3.jpg"
                 },
                 new Picture()
                 {
                     Id = 54,
                     RoomId = 15,
                     Path = "/img/Rooms/Paradise rooms/Paradise stuido 4.jpg"
                 },
                 new Picture()
                 {
                     Id = 55,
                     RoomId = 16,
                     Path = "/img/Rooms/Paradise rooms/Paradise apartment1.jpg"
                 },
                 new Picture()
                 {
                     Id = 56,
                     RoomId = 16,
                     Path = "/img/Rooms/Paradise rooms/Paradise apartment2.jpg"
                 },
                 new Picture()
                 {
                     Id = 57,
                     HotelId = 6,
                     Path = "/img/Hotels/Hotel Amelia/Hotel Amelia1.jpg"
                 },
                 new Picture()
                 {
                     Id = 58,
                     HotelId = 6,
                     Path = "/img/Hotels/Hotel Amelia/Hotel Amelia2.jpg"
                 },
                 new Picture()
                 {
                     Id = 59,
                     HotelId = 6,
                     Path = "/img/Hotels/Hotel Amelia/Hotel Amelia3.jpg"
                 },
                 new Picture()
                 {
                     Id = 60,
                     RoomId = 17,
                     Path = "/img/Rooms/Amelia rooms/Amelia double bed1.jpg"
                 },
                 new Picture()
                 {
                     Id = 61,
                     RoomId = 17,
                     Path = "/img/Rooms/Amelia rooms/Amelia double bed2.jpg"
                 },
                 new Picture()
                 {
                     Id = 62,
                     RoomId = 18,
                     Path = "/img/Rooms//Amelia rooms/Amelia apartment1.jpg"
                 },
                 new Picture()
                 {
                     Id = 63,
                     RoomId = 18,
                     Path = "/img/Rooms//Amelia rooms/Amelia apartment2.jpg"
                 },
                 new Picture()
                 {
                     Id = 64,
                     RoomId = 18,
                     Path = "/img/Rooms//Amelia rooms/Amelia apartment3.jpg"
                 },
                 new Picture()
                 {
                     Id = 65,
                     RoomId = 19,
                     Path = "/img/Rooms//Amelia rooms/Amelia double bed delux1.jpg"
                 },
                 new Picture()
                 {
                     Id = 66,
                     RoomId = 19,
                     Path = "/img/Rooms//Amelia rooms/Amelia double bed delux2.jpg"
                 },
                 new Picture()
                 {
                     Id = 67,
                     RoomId = 19,
                     Path = "/img/Rooms//Amelia rooms/Amelia double bed delux3.jpg"
                 },
                 new Picture()
                 {
                     Id = 68,
                     RoomId = 19,
                     Path = "/img/Rooms//Amelia rooms/Amelia double bed delux4.jpg"
                 },
                 new Picture()
                 {
                     Id = 69,
                     HotelId = 4,
                     Path = "/img/Hotels/NH Collection Milano Porta Nuova/Porta Nuova2.jpg"
                 }
            };
            return pictures;
        }
    }
}
