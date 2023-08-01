namespace BookingWebProject.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.User;
    public class UserAdminService : IUserAdminService
    {
        private readonly BookingContext bookingContext;
        public UserAdminService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
        {
            return await this.bookingContext.Users
                 .Select(u => new AllUsersViewModel()
                 {
                     UserName = u.UserName,
                     UserEmail = u.Email,
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     JoinTime = u.JoinTime
                 })
                 .ToArrayAsync();
        }
    }
}
