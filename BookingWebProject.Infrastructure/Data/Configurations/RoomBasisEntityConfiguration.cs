namespace BookingWebProject.Infrastructure.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    public class RoomBasisEntityConfiguration: IEntityTypeConfiguration<RoomBasis>
    {
        public void Configure(EntityTypeBuilder<RoomBasis> builder)
        {
            ICollection<RoomBasis> roomBasis = CreateRoomBasis();
            builder.HasData(roomBasis);
        }

        private ICollection<RoomBasis> CreateRoomBasis()
        {
            List<RoomBasis> roomBases = new List<RoomBasis>()
            {
                new RoomBasis()
                {
                    Id = 1,
                    Name = "Tv",
                    ClassIcon = "fa-solid fa-tv"
                },
                new RoomBasis()
                {
                    Id = 2,
                    Name = "Free WiFi",
                    ClassIcon = "fa-solid fa-wifi"
                },
                new RoomBasis()
                {
                    Id = 3,
                    Name = "Vault",
                    ClassIcon = "fa-solid fa-vault",
                },
                new RoomBasis()
                {
                    Id = 4,
                    Name = "Air Conditioning",
                    ClassIcon = "fa-solid fa-snowflake"
                },
                new RoomBasis()
                {
                    Id = 5,
                    Name = "Phone",
                    ClassIcon = "fa-solid fa-phone"
                },
                new RoomBasis()
                {
                    Id = 6,
                    Name = "Jacuzzi",
                    ClassIcon = "fa-solid fa-hot-tub-person"
                },
                new RoomBasis()
                {
                    Id = 7,
                    Name = "Coffee Jug",
                    ClassIcon = "fa-solid fa-mug-hot"
                },
                new RoomBasis()
                {
                    Id = 8,
                    Name = "Shower",
                    ClassIcon = "fa-solid fa-shower"
                }
            };
            return roomBases;
        }
    }
}
