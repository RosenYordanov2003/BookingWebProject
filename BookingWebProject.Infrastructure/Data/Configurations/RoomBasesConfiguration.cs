namespace BookingWebProject.Infrastructure.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    public class RoomBasesConfiguration : IEntityTypeConfiguration<RoomsBases>
    {
        public void Configure(EntityTypeBuilder<RoomsBases> builder)
        {
            builder.HasKey(ck => new { ck.RoomBasisId, ck.RoomId });
            builder.HasOne(rb => rb.Room).WithMany(r => r.RoomBases).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(rb => rb.RoomBasis).WithMany(rb => rb.RoomBases).OnDelete(DeleteBehavior.NoAction);
            builder.Property(rb => rb.IsDeleted).HasDefaultValue(false);
            ICollection<RoomsBases> roomsBases = CreateRoomsBases();
            builder.HasData(roomsBases);
        }

        private ICollection<RoomsBases> CreateRoomsBases()
        {
            List<RoomsBases> roomsBases = new List<RoomsBases>();
            roomsBases.AddRange(AddRoomBases(1, new int[] { 1, 2, 3, 5, 8 }));
            roomsBases.AddRange(AddRoomBases(2, new int[] { 1, 2, 3, 5, 8 }));
            roomsBases.AddRange(AddRoomBases(3, new int[] { 1, 2, 3, 4, 5, 8 }));
            roomsBases.AddRange(AddRoomBases(4, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(5, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(6, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(7, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(8, new int[] { 1, 2, 3, 4, 5, 8 }));
            roomsBases.AddRange(AddRoomBases(9, new int[] { 1, 2, 3, 4, 5, 8 }));
            roomsBases.AddRange(AddRoomBases(10, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(11, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(12, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(13, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(14, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(15, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(16, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(17, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(18, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            roomsBases.AddRange(AddRoomBases(19, new int[] { 1, 2, 3, 4, 5, 7, 8 }));
            return roomsBases;
        }
        private ICollection<RoomsBases> AddRoomBases(int roomId, int[] roomBaseIds)
        {
            ICollection<RoomsBases> roomsBases = new List<RoomsBases>();
            foreach (int roomBaseId in roomBaseIds.Distinct())
            {
                roomsBases.Add(new RoomsBases() { RoomId = roomId, RoomBasisId = roomBaseId });
            }
            return roomsBases;
        }
    }
}
