namespace BookingWebProject.Services.Tests.Comparators
{
    using System.Collections;
    using Areas.Admin.Models.User;
    public class AllUserViewModelComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
           AllUsersViewModel user1 = (AllUsersViewModel)x;
           AllUsersViewModel user2 = (AllUsersViewModel)y;

            if (user1 == null || user2 == null)
            {
                return -1;
            }
            if (user1.Id != user2.Id || user1.UserName != user2.UserName || user1.UserEmail != user2.UserEmail)
            {
                return -1;
            }
            return 0;
        }
    }
}
