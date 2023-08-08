namespace BookingWebProject.Extensions
{
    using Areas.Admin.Contracts;
    using Areas.Admin.Services;
    using Core.Contracts;
    using Core.Services;
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IHotelService, HotelService>();
            serviceCollection.AddScoped<IRentCarService, RentCarService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IReservationService, ReservationService>();
            serviceCollection.AddScoped<IBenefitService, BenefitService>();
            serviceCollection.AddScoped<ICommentService, CommentService>();
            serviceCollection.AddScoped<IPackageService, PackageService>();
            serviceCollection.AddScoped<IRoomService, RoomService>();
            serviceCollection.AddScoped<IUserAdminService, UserAdminService>();
            serviceCollection.AddScoped<IAdminService, AdminService>();
            serviceCollection.AddScoped<IHotelAdminService, HotelAdminService>();
            serviceCollection.AddScoped<IPictureService, PictureService>();
            serviceCollection.AddScoped<IBenefitAdminService, BenefitAdminService>();
            serviceCollection.AddScoped<IRentCarAdminService, RentCarAdminService>();
            serviceCollection.AddScoped<IRoomAdminService, RoomAdminService>();
            serviceCollection.AddScoped<IRoomBasesAdminService, RoomBasesAdminService>();
            serviceCollection.AddScoped<IRoomTypeService, RoomTypeService>();
            serviceCollection.AddScoped<IRoomBasisService, RoomBasisService>();
            serviceCollection.AddScoped<IRoomPackageAdminService, RoomPackageAdminService>();
        }
    }
}
