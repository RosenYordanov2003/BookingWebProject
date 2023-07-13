using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebProject.Infrastructure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            Reservations = new List<Reservation>();
            Comments = new List<Comment>();
            FavoriteHotels = new List<FavoriteHotels>();
            this.Id = Guid.NewGuid();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<FavoriteHotels> FavoriteHotels { get; set; }
        [ForeignKey(nameof(ProfilePicture))]
        public int? PictureId { get; set; }
        public Picture? ProfilePicture { get; set; }
    }
}
