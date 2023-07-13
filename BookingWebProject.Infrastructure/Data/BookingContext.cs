using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingWebProject.Data
{
    public class BookingContext : IdentityDbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }
    }
}