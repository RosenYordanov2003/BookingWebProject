using BookingWebProject.Areas.Admin.Contracts;
using BookingWebProject.Areas.Admin.Services;
using BookingWebProject.Core.Contracts;
using BookingWebProject.Core.Services;
using BookingWebProject.Data;
using BookingWebProject.Extensions;
using BookingWebProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BookingContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.Password.RequireDigit = true;
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<BookingContext>();
builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        //This filter adds a guid to the forms
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRentCarService, RentCarService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IBenefitService, BenefitService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IUserAdminService, UserAdminService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IHotelAdminService, HotelAdminService>();
builder.Services.AddScoped<IPictureService, PictureService>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Home/Index";
    options.ExpireTimeSpan = TimeSpan.FromDays(2);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.SeedAdministrator("ED842FDC-C71B-4FBC-8DF5-6F97CB73D622");

//app.MapControllerRoute(

//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.UseEndpoints(config =>
{
    config.MapControllerRoute(
        name: "areas",
        pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    config.MapControllerRoute(
        name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}");
       

    config.MapDefaultControllerRoute();

    config.MapRazorPages();
});

app.Run();
