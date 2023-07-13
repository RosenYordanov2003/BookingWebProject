namespace BookingWebProject.Data
{
    using Infrastructure.Data.Configurations;
    using Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class BookingContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<RoomBasis> RoomBasis { get; set; } = null!;
        public DbSet<RoomType> RoomTypes { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<RentCar> RentCars { get; set; } = null!;
        public DbSet<Benefit> Benefits { get; set; } = null!;
        public DbSet<Picture> Pictures { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<HotelBenefits> HotelBenefits { get; set; } = null!;
        public DbSet<RoomPackage> RoomPackages { get; set; } = null!;
        public DbSet<RoomsBases> RoomsBases { get; set; } = null!;
        public DbSet<FavoriteHotels> FavoriteHotels { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new HotelBenefitsConfiguration());
            builder.ApplyConfiguration(new RoomBasisEntityConfiguration());
            builder.ApplyConfiguration(new HotelEntityConfiguration());
            builder.ApplyConfiguration(new PackageEntityConfiguration());
            builder.ApplyConfiguration(new RentCarEntityConfiguration());
            builder.ApplyConfiguration(new RoomTypeEntityConfiguration());
            builder.ApplyConfiguration(new BenefitEntityConfiguration());
            builder.ApplyConfiguration(new RoomEntityConfiguration());
            builder.ApplyConfiguration(new RoomBasesConfiguration());
            builder.ApplyConfiguration(new PictureEntityConfiguration());
            builder.ApplyConfiguration(new FavoriteHotelsEntityConfiguration());
            //builder.ApplyConfiguration(new CommentEntityConfiguration());
        }
    }
}