using BookingWebProject.Data;
using BookingWebProject.Extensions;
using BookingWebProject.Infrastructure.Data.Models;
using BookingWebProject.ModelBinders.DecimalModelBinder;
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

builder.Services.AddMemoryCache();

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        //This filter adds a guid on the forms
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    });

 builder.Services.AddServices();

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
    app.UseExceptionHandler("/Home/Error/500");
    //Change the environment to see the pages
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.SeedAdministrator("ED842FDC-C71B-4FBC-8DF5-6F97CB73D622");


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
