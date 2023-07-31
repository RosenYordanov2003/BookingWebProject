namespace BookingWebProject.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;

    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            IEnumerable<Comment> comments = CreateComments();
            builder.HasData(comments);
            builder.HasOne(c => c.Hotel)
                .WithMany(h => h.Comments)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private IEnumerable<Comment> CreateComments()
        {
            List<Comment> comments = new List<Comment>();
           
            for (int i = 1; i <= 6; i++)
            {
                Comment comment = new Comment()
                {
                    Id = i + 12, // Because I already have 12 comments inserted. If you are new user you can set Id to be = i only
                    UserId = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                    Description = "Test Comment",
                    CreatedDate = DateTime.Now,
                    HotelId = i,
                    UserName = "Test User"
                };
                comments.Add(comment);
            }
           return comments;
        }
    }
}
