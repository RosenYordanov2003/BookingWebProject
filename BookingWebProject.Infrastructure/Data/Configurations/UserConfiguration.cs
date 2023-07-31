namespace BookingWebProject.Infrastructure.Data.Configurations
{
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Microsoft.AspNetCore.Identity;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            IEnumerable<User> users = CreateUsers();
            builder.HasData(users);
        }

        private IEnumerable<User> CreateUsers()
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            User userOne = new User()
            {
                Id = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                UserName = "Test User",
                NormalizedUserName = "TEST USER",
                Email = "testuser123@gmail.com",
                NormalizedEmail = "TESTUSER123@GMAIL.COM",
            };
            User adminUser = new User()
            {
                Id = Guid.Parse("ED842FDC-C71B-4FBC-8DF5-6F97CB73D622"),
                UserName = "Admin",
                NormalizedUserName = "Admin",
                Email = "admin123@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
            };
            userOne.PasswordHash = passwordHasher.HashPassword(userOne, "test12345");
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin12345");
            List<User> users = new List<User>() { userOne, adminUser };

            return users;
        }
    }
}
