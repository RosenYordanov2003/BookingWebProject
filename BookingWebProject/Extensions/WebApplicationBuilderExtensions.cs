namespace BookingWebProject.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using Infrastructure.Data.Models;
    using static Common.GeneralAplicationConstants;
    public static class WebApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string userId)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            //Get DI container service provider
            IServiceProvider serviceProvider = scopedServices.ServiceProvider;
            UserManager<User> userManagaer = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    User userToFind = await userManagaer.FindByEmailAsync("admin123@gmail.com");
                    if (userToFind == null)
                    {
                        Console.WriteLine("null");
                        return;
                    }
                    await userManagaer.AddToRoleAsync(userToFind, AdminRoleName);
                    return;
                }
                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);
                await roleManager.CreateAsync(role);
                
            })
                .GetAwaiter()
                .GetResult();
            // To do chaining
            return app;
        }
    }
}
