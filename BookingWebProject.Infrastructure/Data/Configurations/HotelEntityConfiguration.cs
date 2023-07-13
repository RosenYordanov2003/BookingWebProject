namespace BookingWebProject.Infrastructure.Data.Configurations
{
    using Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    public class HotelEntityConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(h => h.HotelBenefits)
            .WithOne(hb => hb.Hotel)
            .HasForeignKey(hb => hb.HotelId);

            ICollection<Hotel> hotelCollection = CreateHotels();
            builder.HasData(hotelCollection);
        }

        private ICollection<Hotel> CreateHotels()
        {
            List<Hotel> hotels = new List<Hotel>();


            Hotel hotelOne = new Hotel()
            {
                Id = 1,
                Name = "Spa Hotel Dvoretsa",
                Country = "Bulgaria",
                City = "Velingrad",
                Description = "СПА хотел „Двореца” се намира във Велинград, в прегръдката на Родопите.Той е един от малкото 5-звездни спа хотели във Велинград. Поради благотворните свойства на минералните си извори и прекрасния климат градът не само се е доказал, но е и официално обявен за СПА столица на Балканите. Велинград предлага спокойствие и бягство от стреса на делника, живописни маршрути за разходка сред природата и разнообразие от възможности за забавление. СПА хотел „Двореца” е в съседство с красив боров парк и разкрива очарователна гледка към околните планини. Тук въздухът е чист, а басейните са с топла минерална вода през цялата година. Хотелът е предпочитано място за романтични почивки, тиймбилдинги и бизнес събития. „Двореца” е особено любимо място на семейства с деца, тъй като „Двореца” предлага разнообразие от забавления за най-малките си гости – детски басейн, водна пързалка, люлки и кът с аниматор, много играчки и игри. На Ваше разположение са сауна, парна баня и сауна.",
                StarRating = 5,
                Latitude = 42.032235406916385m,
                Longitude = 23.987805838924398m,
            };
            Hotel hotelTwo = new Hotel()
            {
                Id = 2,
                City = "Velingrad",
                Country = "Bulgaria",
                Name = "Spa hotel Infinity",
                Description = "Добре дошли  в СПА ХОТЕЛ ИНФИНИТИ ПАРК ВЕЛИНГРАД  – място, където ще намерите комфорт и планинско спокойствие.\r\n\r\nНашият пет звезден хотел предлага 95 луксозни стаи и апартаменти, отлични конферентни съоръжения, изискана кухня и уникален спа център.\r\nЗакрити термални басейни /полуолимпийски плувен, акватоничен, детски, бебешки, ледено шоков и контрастен/,\r\nджакузи 3 бр., парна баня, билкова парна баня, приключенски душ, кнайп пътека, горска пътека, финландска сауна,\r\nбилкова сауна, инфрачервена сауна , солна баня, турска баня, японска баня, релакс зона, външни бани, фитнес,\r\nсезонен панорамен инфинити басейн, джакузи, сауна и открити басейни.",
                Latitude = 42.030206649356195m,
                Longitude = 23.979628495721478m,
                StarRating = 5,
            };
            Hotel hotelThree = new Hotel()
            {
                Id = 3,
                City = "Sofia",
                Country = "Bulgaria",
                Name = "Hotel Marinela",
                Latitude = 42.67252787183476m,
                Longitude = 23.318956866924907m,
                Description = "Петзвездният хотел Маринела София е проектиран от известния японски архитект Кишо Курокава - автор на редица световни забележителности.\r\nХотелът е разположен на площ от 30 000 кв.м. Нашите 442 стаи и апартаменти, включително най-големият президентски апартамент в България, предлагат лукс & комфорт с прекрасен изглед към града и планината.\r\nС общо 10 мултифукнционални зали, сред които една от най-големите бални и конферентни зали в града и забележително зала на последния етаж.\r\nХотел Маринела е сред емблематичните сгради в София и уникално място за Балканския полуостров. Това е точното място за бягство от натоварения градски живот, като същевременно се намира в самия център на града.",
                StarRating = 5,
            };
            Hotel hotelFour = new Hotel()
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
            Hotel hotelFive = new Hotel()
            {
                Id = 5,
                City = "Albena",
                Country = "Bulgaria",
                Name = "Paradise blue",
                StarRating = 5,
                Latitude = 43.36873068763438m,
                Longitude = 28.082414473014655m,
                Description = "Maritim Hotel Paradise Blue Albena 5* в Албена е отличен и заслужава напълно 5 звезди за всичко, което предлага: интериориорен и екстериорен дизайн, просторни стаи, тихо място точно пред морето, красив плаж. Винаги разполагаме с шезлонги на плажа и басейна и с много на брой малки изненади, които дори не очаквахме: минерална вода в целия хотел, истинско кафе (еспресо, капучино и айс кафе), 100% ябълков сок и пресен хляб на закуска."
            };
            Hotel hotelSix = new Hotel()
            {
                Id = 6,
                City = "Albena",
                Country = "Bulgaria",
                Name = "Amelia",
                StarRating = 5,
                Latitude = 43.368523054572734m,
                Longitude = 28.081230353970707m,
                Description = "Амелия Хотел Албена е най-новото 5-звездно бижу, на което просто не можете да устоите. Първият тематичен хотел в Албена, посветен на първата жена-летец, прекосила Атлантика, Амелия Еърхарт, ще ви посрещне през лято 2022 с невероятни гледки и пълно усещане за релакс. Насладете се на изгревите и залезите от панорамния басейн на покрива, на висококачествените специалитети на топ готвачите на Албена и на многобройните възможности за спортни активности, които комплексът предоставя.\r\n\r\nСамо на метри от морето, в сърцето на комплекса, Амелия хотел Албена ви очаква, за да се превърне в любимото ви място за ваканция, където със сигурност ще пожелаете да се върнет"
            };
            hotels.Add(hotelOne);
            hotels.Add(hotelTwo);
            hotels.Add(hotelThree);
            hotels.Add(hotelFour);
            hotels.Add(hotelFive);
            hotels.Add(hotelSix);

            return hotels;
        }
    }
}
