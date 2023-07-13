namespace BookingWebProject.Infrastructure.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    public class FavoriteHotelsEntityConfiguration : IEntityTypeConfiguration<FavoriteHotels>
    {
        public void Configure(EntityTypeBuilder<FavoriteHotels> builder)
        {
            builder.HasKey(ck => new { ck.UserId, ck.HotelId });
            builder.HasOne(fh => fh.User)
                .WithMany(u => u.FavoriteHotels)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fh => fh.Hotel)
                .WithMany(h => h.FavoriteHotels)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
