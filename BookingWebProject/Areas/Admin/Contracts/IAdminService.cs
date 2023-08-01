namespace BookingWebProject.Areas.Admin.Contracts
{
    using Models;
    public interface IAdminService
    {
        public Task<HomeAdminPageViewModel> GetStatisticsInfoAsync();
    }
}
