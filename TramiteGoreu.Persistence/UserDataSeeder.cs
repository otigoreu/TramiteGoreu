using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TramiteGoreu.Entities;
using static TramiteGoreu.Persistence.ApplicationUser;

namespace TramiteGoreu.Persistence
{
    public static class UserDataSeeder
    {
        public static async Task Seed(IServiceProvider service)
        {
            //User repository
            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            //Role repository
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            //Creating roles
            var adminRole = new IdentityRole(Constants.RoleAdmin);
            var customerRole = new IdentityRole(Constants.RoleCustomer);

            if (!await roleManager.RoleExistsAsync(Constants.RoleAdmin))
                await roleManager.CreateAsync(adminRole);

            if (!await roleManager.RoleExistsAsync(Constants.RoleCustomer))
                await roleManager.CreateAsync(customerRole);

            //Admin user
            var adminUser = new ApplicationUser()
            {
                FirstName = "System",
                LastName = "Administrator",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };
            if (await userManager.FindByEmailAsync("admin@gmail.com") is null)
            {
                var result = await userManager.CreateAsync(adminUser, "Admin1234*");
                if (result.Succeeded)
                {
                    // Obtenemos el registro del usuario
                    adminUser = await userManager.FindByEmailAsync(adminUser.Email);
                    // Aqui agregamos el Rol de Administrador para el usuario Admin
                    if (adminUser is not null)
                        await userManager.AddToRoleAsync(adminUser, Constants.RoleAdmin);
                }
            }
        }
    }
}
