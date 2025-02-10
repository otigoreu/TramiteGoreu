using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Persistence
{
    public class UserDataSeeder
    {
        private readonly IServiceProvider service;
        private readonly ApplicationDbContext context;

        public UserDataSeeder(IServiceProvider service, ApplicationDbContext context)
        {
            this.service = service;
            this.context = context;
        }
        public async Task SeedAsync()
        {
            //User repository
            var userManager = service.GetRequiredService<UserManager<Usuario>>();
            //Role repository
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            //Creating roles
            var adminRole = new IdentityRole(Constantes.RoleAdmin);
            var clienteRole = new IdentityRole(Constantes.RolCliente);

            if (!await roleManager.RoleExistsAsync(Constantes.RoleAdmin))
                await roleManager.CreateAsync(adminRole);

            if (!await roleManager.RoleExistsAsync(Constantes.RolCliente))
                await roleManager.CreateAsync(clienteRole);

            #region Admin
            //Admin user
            var adminUser = new Usuario()
            {
                FirstName = "System",
                LastName = "Administrator",
                UserName = "43056714",
                Email = "edercin@gmail.com",
                EmailConfirmed = true
            };

            var persona = new Persona
            {
                Nombres = "Edeher Rossetti",
                Apellidos = "Ponce Morales",
                FechaNac = new DateTime(1982, 07, 10),
                Direccion = "",
                Referencia = "",
                Celular = "",
                Edad = "",
                Email = "edercin@gmail.com",
                TipoDoc = "",
                NroDoc = "",


            };

            // Guarda la entidad Persona en la base de datos

            // sino existe crear
            //context.Set<Persona>().Add(persona);

            var sede = new Sede
            {
                Descripcion = "Central",

            };
            // sino existe crear
            //context.Set<Sede>().Add(sede);
            #endregion


            #region Customer
            //Customer user
            var customerUser = new Usuario()
            {
                FirstName = "System",
                LastName = "Customer",
                UserName = "46519259",
                Email = "edercinsoft@gmail.com",
                PhoneNumber = "123456789",
                EmailConfirmed = true
            };

            var persona2 = new Persona
            {
                Nombres = "Patricia",
                Apellidos = "Lopez",
                FechaNac = new DateTime(1990, 05, 31),
                Direccion = "",
                Referencia = "",
                Celular = "",
                Edad = "",
                Email = "edercinsoft@gmail.com",
                TipoDoc = "",
                NroDoc = "",

            };

            // Guarda la entidad Persona en la base de datos
            // sino existe crear
            //context.Set<Persona>().Add(persona2);

            var sede2 = new Sede
            {
                Descripcion = "Petitas",

            };
            // sino existe crear
           // context.Set<Sede>().Add(sede2);
            #endregion

            //await context.SaveChangesAsync();

            //adminUser.IdPersona = persona.Id;
            //adminUser.IdSede = sede.Id;

            //customerUser.IdPersona = persona2.Id;
            //customerUser.IdSede = sede2.Id;


            if (await userManager.FindByEmailAsync("edercin@gmail.com") is null)
            {

                // sino existe crear
                context.Set<Persona>().Add(persona);
                context.Set<Persona>().Add(persona2);

                context.Set<Sede>().Add(sede);

                context.Set<Sede>().Add(sede2);

                await context.SaveChangesAsync();

                adminUser.IdPersona = persona.Id;
                adminUser.IdSede = sede.Id;
                customerUser.IdPersona = persona2.Id;
                customerUser.IdSede = sede2.Id;

                var result = await userManager.CreateAsync(adminUser, "Edeher*2024");
                if (result.Succeeded)
                {
                    // Obtenemos el registro del usuario
                    adminUser = await userManager.FindByEmailAsync(adminUser.Email);
                    // Aqui agregamos el Rol de Administrador para el usuario Admin
                    if (adminUser is not null)
                        await userManager.AddToRoleAsync(adminUser, Constantes.RoleAdmin);
                }
            }
            if (await userManager.FindByEmailAsync("edercinsfot@gmail.com") is null)
            {
                var result = await userManager.CreateAsync(customerUser, "Edeher*2025");
                if (result.Succeeded)
                {
                    // Obtenemos el registro del usuario
                    customerUser = await userManager.FindByEmailAsync(customerUser.Email);
                    // Aqui agregamos el Rol de Administrador para el usuario Admin
                    if (customerUser is not null)
                        await userManager.AddToRoleAsync(customerUser, Constantes.RolCliente);
                }
            }
        }
    }
}