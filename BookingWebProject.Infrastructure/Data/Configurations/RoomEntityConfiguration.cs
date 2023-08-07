namespace BookingWebProject.Infrastructure.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoomEntityConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(r => r.Reservations)
                .WithOne(r => r.Room)
                .OnDelete(DeleteBehavior.NoAction);
            ICollection<Room> rooms = CreateRooms();
            builder.HasData(rooms);
        }

        private ICollection<Room> CreateRooms()
        {
            List<Room> rooms = new List<Room>()
            {
               new Room()
               {
                   Id = 1,
                   RoomTypeId = 5,
                   PricePerNight = 190,
                   HotelId = 1,
                   Capacity = 2,
                   Description = "Стаите в хотела разполагат с плоскоекранен телевизор със сателитна телевизия, Wi-Fi, сейф, саниратен възел с вана или душ.\r\nАпартаментите са подходящи за двойки, семейства или група приятели до 4 човека. Голямата спалня е обзаведена с удобно двойно легло, а в по-малката спалня се намират 2 комфортни единични легла. В банята на апартаментите ще откриете луксозна вана, сешоар и всички необходими принадлежности."

               },
               new Room()
               {
                   Id = 2,
                   RoomTypeId = 3,
                   PricePerNight = 190,
                   HotelId = 1,
                   Capacity = 4,
                   Description = "Стаи в хотела разполагат с плоскоекранен телевизор със сателитна телевизия, Wi-Fi, сейф, саниратен възел с вана или душ.\r\nАпартаментите са подходящи за двойки, семейства или група приятели до 4 човека. Голямата спалня е обзаведена с удобно двойно легло, а в по-малката спалня се намират 2 комфортни единични легла. В банята на апартаментите ще откриете луксозна вана, сешоар и всички необходими принадлежности."
               },
               new Room()
               {
                   Id = 3,
                   RoomTypeId = 1,
                   PricePerNight = 190,
                   Capacity = 5,
                   HotelId = 1,
                   Description = "Стаи в хотела разполагат с плоскоекранен телевизор със сателитна телевизия, Wi-Fi, сейф, саниратен възел с вана или душ.\r\nАпартаментите са подходящи за двойки, семейства или група приятели до 4 човека. Голямата спалня е обзаведена с удобно двойно легло, а в по-малката спалня се намират 2 комфортни единични легла. В банята на апартаментите ще откриете луксозна вана, сешоар и всички необходими принадлежности."
               },
               new Room()
               {
                   Id = 4,
                   HotelId = 2,
                   RoomTypeId = 5,
                   PricePerNight = 200,
                   Capacity = 2,
                   Description = "Изживейте лукса и комфорта в стаята си в хотел Infinity. С просторен и стилно обзаведен интериор, стаята предлага уютна атмосфера и модерни удобства, които ще ви осигурят приятен престой.\r\n\r\nРазкройте се в просторната стая в хотел Infinity, където съчетанието от елегантен дизайн и изискани детайли ще ви оставят впечатлени. Отпуснете се и се насладете на комфорта на луксозното легло и удобствата, които предлага тази стилна стая."
               },
               new Room()
               {
                   Id = 5,
                   HotelId = 2,
                   RoomTypeId = 3,
                   PricePerNight = 220,
                   Capacity = 4,
                   Description = "Изживейте лукса и комфорта в стаята си в хотел Infinity. С просторен и стилно обзаведен интериор, стаята предлага уютна атмосфера и модерни удобства, които ще ви осигурят приятен престой.\r\n\r\nРазкройте се в просторната стая в хотел Infinity, където съчетанието от елегантен дизайн и изискани детайли ще ви оставят впечатлени. Отпуснете се и се насладете на комфорта на луксозното легло и удобствата, които предлага тази стилна стая."
               },
               new Room()
               {
                   Id = 6,
                   HotelId = 2,
                   RoomTypeId = 1,
                   PricePerNight = 200,
                   Capacity = 4,
                   Description = "Изживейте лукса и комфорта в стаята си в хотел Infinity. С просторен и стилно обзаведен интериор, стаята предлага уютна атмосфера и модерни удобства, които ще ви осигурят приятен престой.\r\n\r\nРазкройте се в просторната стая в хотел Infinity, където съчетанието от елегантен дизайн и изискани детайли ще ви оставят впечатлени. Отпуснете се и се насладете на комфорта на луксозното легло и удобствата, които предлага тази стилна стая."
               },
               new Room()
               {
                   Id = 7,
                   HotelId = 2,
                   RoomTypeId = 4,
                   PricePerNight = 200,
                   Capacity = 6,
                   Description = "Изживейте лукса и комфорта в стаята си в хотел Infinity. С просторен и стилно обзаведен интериор, стаята предлага уютна атмосфера и модерни удобства, които ще ви осигурят приятен престой.\r\n\r\nРазкройте се в просторната стая в хотел Infinity, където съчетанието от елегантен дизайн и изискани детайли ще ви оставят впечатлени. Отпуснете се и се насладете на комфорта на луксозното легло и удобствата, които предлага тази стилна стая."
               },
               new Room()
               {
                   Id = 8,
                   HotelId = 3,
                   RoomTypeId = 5,
                   PricePerNight = 180,
                   Capacity = 2,
                   Description = "Насладете се на превъзходството на стаята в хотел Маринела София. С елегантен и модерен дизайн, стаята предлага изисканост и комфорт, съчетани с невероятна гледка към града или планината, които ще ви впечатлят.\r\n\r\nОткрийте уют и релаксация в просторната стая в хотел Маринела София. Обзаведена с внимание към детайла и с модерни удобства, тази стая предлага комфортна обстановка, в която можете да се отпуснете и да се насладите на безпроблемен престой в столицата."
               },
               new Room()
               {
                   Id = 9,
                   HotelId = 3,
                   RoomTypeId = 3,
                   PricePerNight = 180,
                   Capacity = 3,
                   Description = "Насладете се на превъзходството на стаята в хотел Маринела София. С елегантен и модерен дизайн, стаята предлага изисканост и комфорт, съчетани с невероятна гледка към града или планината, които ще ви впечатлят.\r\n\r\nОткрийте уют и релаксация в просторната стая в хотел Маринела София. Обзаведена с внимание към детайла и с модерни удобства, тази стая предлага комфортна обстановка, в която можете да се отпуснете и да се насладите на безпроблемен престой в столицата."
               },
               new Room()
               {
                   Id = 10,
                   HotelId = 3,
                   RoomTypeId = 1,
                   PricePerNight = 180,
                   Capacity = 4,
                   Description = "Насладете се на превъзходството на стаята в хотел Маринела София. С елегантен и модерен дизайн, стаята предлага изисканост и комфорт, съчетани с невероятна гледка към града или планината, които ще ви впечатлят.\r\n\r\nОткрийте уют и релаксация в просторната стая в хотел Маринела София. Обзаведена с внимание към детайла и с модерни удобства, тази стая предлага комфортна обстановка, в която можете да се отпуснете и да се насладите на безпроблемен престой в столицата."
               },
               new Room()
               {
                   Id = 11,
                   HotelId = 4,
                   RoomTypeId = 3,
                   PricePerNight = 190,
                   Capacity = 4,
                   Description = "Experience the charm and elegance of the rooms at Milano Porta Nuova Hotel. Immerse yourself in a sophisticated ambiance where modern design seamlessly blends with Italian style, creating a welcoming retreat for your stay in Milan.\r\n\r\nDiscover a haven of comfort and tranquility in the rooms of Milano Porta Nuova Hotel. With tasteful decor, contemporary furnishings, and thoughtful amenities, these rooms provide a relaxing atmosphere, allowing you to unwind and enjoy a seamless stay in the vibrant city of Milan."
               },
               new Room()
               {
                   Id = 12,
                   HotelId = 4,
                   RoomTypeId = 5,
                   PricePerNight = 190,
                   Capacity = 2,
                   Description = "Experience the charm and elegance of the rooms at Milano Porta Nuova Hotel. Immerse yourself in a sophisticated ambiance where modern design seamlessly blends with Italian style, creating a welcoming retreat for your stay in Milan.\r\n\r\nDiscover a haven of comfort and tranquility in the rooms of Milano Porta Nuova Hotel. With tasteful decor, contemporary furnishings, and thoughtful amenities, these rooms provide a relaxing atmosphere, allowing you to unwind and enjoy a seamless stay in the vibrant city of Milan."
               },
               new Room()
               {
                   Id = 13,
                   HotelId = 4,
                   RoomTypeId = 1,
                   PricePerNight = 190,
                   Capacity = 4,
                   Description = "Experience the charm and elegance of the rooms at Milano Porta Nuova Hotel. Immerse yourself in a sophisticated ambiance where modern design seamlessly blends with Italian style, creating a welcoming retreat for your stay in Milan.\r\n\r\nDiscover a haven of comfort and tranquility in the rooms of Milano Porta Nuova Hotel. With tasteful decor, contemporary furnishings, and thoughtful amenities, these rooms provide a relaxing atmosphere, allowing you to unwind and enjoy a seamless stay in the vibrant city of Milan."
               },
               new Room()
               {
                   Id = 14,
                   HotelId = 5,
                   RoomTypeId = 3,
                   Capacity = 3,
                   PricePerNight = 280,
                   Description = "Потопете се в прегръдката на природата с резервация на стая Deluxe в Maritim Hotel Paradise Blue Albena 5* с гледка към морето или парка. За вашата комфортна почивка вие ще разполагате със стилно обзаведени помещения, включително невероятно удобна спалня от единични легла и мек разтегателен диван с 14 см матрак. Баните са оборудвани с душкабина и вана. Стаите са разположени от 1- ви до 7- ми етаж на хотела и ще ви предложат най-красивите и запомнящи се гледки.\r\n\r\nПодходящи за настаняване на 2 възрастни и 1 дете. Максимално допустимо настаняване 2 възрастни и 2 деца."
               },
               new Room()
               {
                   Id = 15,
                   HotelId = 5,
                   RoomTypeId = 2,
                   PricePerNight = 280,
                   Capacity= 4,
                   Description = "Студиа Deluxe са обзаведени с разтегателен диван, маса и фотьойли, с две единични легла, работно бюро, стъклена стена и луксозен кухненски бокс. Оборудвани са с баня с вана или душ кабина, LCD дисплей и тоалетна, както и втора тоалетна в отделно помещение. Яркият декор и съчетанието от естествени дървени нюанси с пастелни сини тонове създават комфорт и уют. Студиата са разположени от 1-ви до 7-ми етаж на хотела."
               },
               new Room()
               {
                   Id = 16,
                   HotelId = 5,
                   RoomTypeId = 1,
                   Capacity = 4,
                   PricePerNight = 280,
                   Description = "Потопете се в несравнимия петзвезден комфорт с резервация на апартамент Deluxe в Maritim Hotel Paradise Blue Albena 5*. Стилните двустайни делукс апартаменти, разполагат с невероятни тераси с изглед към морето или към парка. Състоят се от хол с разтегателен диван, спалня с две единични легла с изключително комфортни матраци за вашия здравословен сън и спално бельо от висококачествени материи, модерни и функционални мебели. Помещенията са подходящи за настаняване на 2 възрастни и 1 дете. Максимално допустимо настаняване 2 възрастни и 2 деца. Банята е с душкабина и вана - 8 кв.м и отделна тоалетна - 1,5 кв. м. Просторната тераса е идеалното място, от което можете да се насладите на лекия и прохладен бриз, докато се любувате на морската панорама. Разположението на апартаментите е от 1- ви до 7- ми етаж."
               },
               new Room()
               {
                   Id = 17,
                   HotelId = 6,
                   RoomTypeId = 5,
                   Capacity = 3,
                   PricePerNight = 250 + (250 * 30)/100,
                   Description = "Просторни и луксозно обзаведени, стаите Делукс с гледка парк ще ви изненадат със своята функционалност. Комфортните възглавници ще ви пренесат високо в облаците, а от широкия балкон ще можете да се насладите на незабравима гледка към централната алея, докато отпивате от сутрешното си кафе или чай от подбрани сортове, които ви очакват в стаята. Или можете просто да се отпуснете пред 49-инчовия телевизор. За Вашата сигурност във всяка стая има сейф. Стаите са оборудвани и със сет за гладене, телефон и мини бар."
               },
               new Room()
               {
                   Id = 18,
                   RoomTypeId = 1,
                   HotelId = 6,
                   Capacity = 4,
                   PricePerNight = 290,
                   Description = "Просторните и луксозно обзаведени апартаменти Делукс с гледка парк са перфектни за семейства. Комфортните възглавници ще ви пренесат в облаците, а от широкия балкон ще можете да се насладите на гледка към оживената централна алея на комплекса, докато отпивате от сутрешното си кафе или чай от селектирани сортове, които ви очакват във всеки апартамент. Или просто можете да релаксирате във ваната или гледайки телевизия на един от двата 49-инчови телевизора. За Вашата сигурност всеки апартамент е оборудван със сейф. На Ваше разположение има и сет за гладене, телефон и мини бар."
               },
               new Room()
               {
                   Id = 19,
                   RoomTypeId = 3,
                   HotelId = 6,
                   Capacity = 4,
                   PricePerNight = 290,
                   Description = "Резервирайте Стая Executive VIP в Хотел Амелия 5* и получете екслузивен достъп до уникалния басейн на покрива със страхотна панорама и бар с изкушаващи напитки. \r\n\r\nСтаята ще ви очарова с морската си гледка и неповторим дизайнерски лукс. Удобните матраци ще ви гарантират сън, сякаш сте в облаците, а просторът ще допринесе за вашият истински и дълго мечтан релакс."
               }
            };
            return rooms;
        }
    }
}
