namespace BookingWebProject.Areas.Admin.Contracts
{
    using Models.User;

    public interface IUserAdminService
    {
        Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
    }
}
