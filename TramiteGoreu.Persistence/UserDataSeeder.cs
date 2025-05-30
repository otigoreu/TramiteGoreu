using Azure.Core;
using Goreu.Tramite.Entities;
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
            //Menu Repository

            #region Roles
            //Creating roles
            var role1 = new Role
            {
                Name = Constantes.RoleAdmin,
                CanCreate=true,
                CanDelete = true,
                CanUpdate = true,
                CanSearch = true,
                NormalizedName = Constantes.RoleAdmin
            };
            var role2 = new Role
            {
                Name = Constantes.RolCliente,
                CanCreate = true,
                CanDelete = true,
                CanUpdate = true,
                CanSearch = true,
                NormalizedName = Constantes.RolCliente
            };


            //var adminRole = new IdentityRole(Constantes.RoleAdmin);
            //var clienteRole = new IdentityRole(Constantes.RolCliente);

            //if (!await roleManager.RoleExistsAsync(Constantes.RoleAdmin))
            //    await roleManager.CreateAsync(adminRole);

            //if (!await roleManager.RoleExistsAsync(Constantes.RolCliente))
            //    await roleManager.CreateAsync(clienteRole);

            #endregion

            #region UsuarioAdmin
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
                ApellidoPat = "Ponce",
                ApellidoMat = "Morales",
                FechaNac = new DateTime(1982, 07, 10),
                Direccion = "",
                Referencia = "",
                Celular = "",
                Edad = "",
                Email = "edercin@gmail.com",
                TipoDoc = "",
                NroDoc = "",


            };
            #endregion

            #region Sede
            var sede = new Sede
            {
                Descripcion = "Central",

            };
            // sino existe crear
            //context.Set<Sede>().Add(sede);
            #endregion

            #region UsuarioCustomer
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
                ApellidoPat = "Lopez",
                ApellidoMat = "Vasquez",
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

            #region Aplicacion

            var app1 = new Aplicacion
            {
                Descripcion="TRAMITE"
            };

            

            var app2 = new Aplicacion
            {
                Descripcion = "PLANILLA"
            };

            var app3 = new Aplicacion
            {
                Descripcion = "SISMORE"
            };

            #endregion

            #region menu

            var menu1 = new Menu
            {
                DisplayName= "Persona",
                IconName= "users",
                Route= "pages/persona",
                IdAplicacion=1,
                ParentMenu=null,

            };
            var menu2 = new Menu
            {
                DisplayName = "TipoDocumento",
                IconName = "file-barcode",
                Route = "pages/tipo-documento",
                IdAplicacion = 1,
                ParentMenu = null,

            };
            var menu3 = new Menu
            {
                DisplayName = "Aplicacion",
                IconName = "brand-google-play",
                Route = "pages/aplicacion",
                IdAplicacion = 1,
                ParentMenu = null,

            };
            var menu4 = new Menu
            {
                DisplayName = "Sede",
                IconName = "building-factory-2",
                Route = "pages/sede",
                IdAplicacion = 1,
                ParentMenu = null,

            };
            var menu5 = new Menu
            {
                DisplayName = "Menu",
                IconName = "menu-deep",
                Route = "pages/menu",
                IdAplicacion = 1,
                ParentMenu = null,

            };

            #endregion

            #region tipoDocu

            var tipodoc1 = new TipoDocumento
            {
                Descripcion="Documento nacional de Identidad",
                Abrev="DNI"

            };
            var tipodoc2 = new TipoDocumento
            {
                Descripcion = "Carnet de Extranjeria",
                Abrev = "CEX"

            };

            #endregion

            if (await userManager.FindByEmailAsync("edercin@gmail.com") is null)
            {
                context.Set<Role>().Add(role1);
                context.Set<Role>().Add(role2);
                // sino existe crear
                context.Set<Persona>().Add(persona);
                context.Set<Persona>().Add(persona2);

                context.Set<Sede>().Add(sede);

                context.Set<Sede>().Add(sede2);

                context.Set<Aplicacion>().Add(app1);
                context.Set<Aplicacion>().Add(app2);
                context.Set<Aplicacion>().Add(app3);

                context.Set<Menu>().Add(menu1);
                context.Set<Menu>().Add(menu2);
                context.Set<Menu>().Add(menu3);
                context.Set<Menu>().Add(menu4);
                context.Set<Menu>().Add(menu5);

                context.Set<TipoDocumento>().Add(tipodoc1);
                context.Set<TipoDocumento>().Add(tipodoc2);


                await context.SaveChangesAsync();

                adminUser.IdPersona = persona.Id;
                adminUser.IdSede = sede.Id;
                customerUser.IdPersona = persona2.Id;
                customerUser.IdSede = sede2.Id;

               

            #region sedeApp

                var sedeApp = new SedeAplicacion {
                
                    IdSede=sede.Id,
                    IdAplicacion=app1.Id,
                    status=true
                
                };

                #endregion

            #region menuRol

                //var rol1 = await roleManager.FindByNameAsync(Constantes.RoleAdmin);
                //var rol2 = await roleManager.FindByNameAsync(Constantes.RolCliente);
                var menuRol1 = new MenuRol
                {

                    IdMenu = menu1.Id,
                    IdRole = role1.Id
                };
                var menuRol2 = new MenuRol
                {

                    IdMenu = menu2.Id,
                    IdRole = role1.Id
                };
                var menuRol3 = new MenuRol
                {

                    IdMenu = menu3.Id,
                    IdRole = role1.Id
                };
                var menuRol4 = new MenuRol
                {

                    IdMenu = menu4.Id,
                    IdRole = role1.Id
                };
                var menuRol5 = new MenuRol
                {

                    IdMenu = menu5.Id,
                    IdRole = role1.Id
                };

                var menuRol6 = new MenuRol
                {

                    IdMenu = menu2.Id,
                    IdRole = role2.Id
                };

                context.Set<MenuRol>().Add(menuRol1);
                context.Set<MenuRol>().Add(menuRol2);
                context.Set<MenuRol>().Add(menuRol3);
                context.Set<MenuRol>().Add(menuRol4);
                context.Set<MenuRol>().Add(menuRol5);
                context.Set<MenuRol>().Add(menuRol6);
                

                #endregion



                context.Set<SedeAplicacion>().Add(sedeApp);

                await context.SaveChangesAsync();

                var result = await userManager.CreateAsync(adminUser, "Edeher*2024");
                if (result.Succeeded)
                {
                    // Obtenemos el registro del usuario
                    adminUser = await userManager.FindByEmailAsync(adminUser.Email);
                    // Aqui agregamos el Rol de Administrador para el usuario Admin

                    if (adminUser is not null) { 

                    var userApp = new UsuarioAplicacion
                    {

                        IdUsuario = adminUser.Id,
                        IdAplicacion = app1.Id
                    };
                        context.Set<UsuarioAplicacion>().Add(userApp);
                        await context.SaveChangesAsync();


                        await userManager.AddToRoleAsync(adminUser, Constantes.RoleAdmin);
                }
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
                    if (customerUser is not null) {

                        var userApp1 = new UsuarioAplicacion
                        {

                            IdUsuario = customerUser.Id,
                            IdAplicacion = app1.Id
                        };
                        context.Set<UsuarioAplicacion>().Add(userApp1);
                        await context.SaveChangesAsync();

                        await userManager.AddToRoleAsync(customerUser, Constantes.RolCliente);

                    }

                        


                }
            }
        }
    }
}