using Azure.Core;
using Goreu.Tramite.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Persistence
{
    public class UserDataSeeder
    {
        private readonly IServiceProvider _service;
        private readonly ApplicationDbContext _context;

        public UserDataSeeder(IServiceProvider service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task SeedAsync()
        {
            var userManager = _service.GetRequiredService<UserManager<Usuario>>();
            var roleManager = _service.GetRequiredService<RoleManager<IdentityRole>>();

            await EnsureRolesCreatedAsync(roleManager);
            await EnsureTipoDocumentosCreatedAsync();
            await EnsureAplicacionesCreatedAsync();
            await EnsureMenusCreatedAsync();
            await EnsureMenuRolesAsync();
            await EnsureUsuariosYSedesAsync(userManager);
        }

        private async Task EnsureRolesCreatedAsync(RoleManager<IdentityRole> roleManager)
        {
            async Task CreateRoleIfNotExists(string name)
            {
                if (!await roleManager.RoleExistsAsync(name))
                {
                    var role = new Role
                    {
                        Name = name,
                        NormalizedName = name.ToUpper(),
                        CanCreate = true,
                        CanUpdate = true,
                        CanDelete = true,
                        CanSearch = true
                    };
                    await roleManager.CreateAsync(role);
                }
            }

            await CreateRoleIfNotExists(Constantes.RoleAdmin);
            await CreateRoleIfNotExists(Constantes.RolCliente);
        }

        private async Task EnsureTipoDocumentosCreatedAsync()
        {
            if (!await _context.Set<TipoDocumento>().AnyAsync())
            {
                _context.AddRange(
                    new TipoDocumento { Descripcion = "Documento nacional de Identidad", Abrev = "DNI" },
                    new TipoDocumento { Descripcion = "Carnet de Extranjeria", Abrev = "CEX" }
                );
                await _context.SaveChangesAsync();
            }
        }

        private async Task EnsureAplicacionesCreatedAsync()
        {
            if (!await _context.Set<Aplicacion>().AnyAsync())
            {
                _context.AddRange(
                    new Aplicacion { Descripcion = "TRAMITE" },
                    new Aplicacion { Descripcion = "PLANILLA" },
                    new Aplicacion { Descripcion = "SISMORE" }
                );
                await _context.SaveChangesAsync();
            }
        }

        private async Task EnsureMenusCreatedAsync()
        {
            var tramiteApp = await _context.Set<Aplicacion>().FirstOrDefaultAsync(a => a.Descripcion == "TRAMITE");
            if (tramiteApp == null) return;

            if (!await _context.Set<Menu>().AnyAsync())
            {
                _context.AddRange(
                    new Menu { DisplayName = "Persona", IconName = "users", Route = "pages/persona", IdAplicacion = tramiteApp.Id },
                    new Menu { DisplayName = "TipoDocumento", IconName = "file-barcode", Route = "pages/tipo-documento", IdAplicacion = tramiteApp.Id },
                    new Menu { DisplayName = "Aplicacion", IconName = "brand-google-play", Route = "pages/aplicacion", IdAplicacion = tramiteApp.Id },
                    new Menu { DisplayName = "Sede", IconName = "building-factory-2", Route = "pages/sede", IdAplicacion = tramiteApp.Id },
                    new Menu { DisplayName = "Menu", IconName = "menu-deep", Route = "pages/menu", IdAplicacion = tramiteApp.Id }
                );
                await _context.SaveChangesAsync();
            }
        }

        private async Task EnsureMenuRolesAsync()
        {
            var adminRole = await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == "Administrador");

            if (adminRole == null)
                return; // o lanza excepción si es requerido

            var menus = await _context.Set<Menu>().ToListAsync();

            foreach (var menu in menus)
            {
                bool existe = await _context.Set<MenuRol>()
                    .AnyAsync(mr => mr.IdMenu == menu.Id && mr.IdRole == adminRole.Id);

                if (!existe)
                {
                    _context.Add(new MenuRol
                    {
                        IdMenu = menu.Id,
                        IdRole = adminRole.Id
                    });
                }
            }

            await _context.SaveChangesAsync();
        }

        private async Task EnsureUsuariosYSedesAsync(UserManager<Usuario> userManager)
        {
            // Usuario Admin
            await CrearUsuarioAsync(userManager, "43056714", "edercin@gmail.com", "System", "Administrator", "Edeher Rossetti", "Ponce", "Morales", "DNI", "00000000", "Central", Constantes.RoleAdmin);

            await CrearUsuarioAsync(userManager, "42928945", "pp.llerenalima@gmail.com", "System", "Administrator", "Piero Paolo", "Llerena", "Lima", "DNI", "42928945", "Central", Constantes.RoleAdmin);

            // Usuario Cliente
            await CrearUsuarioAsync(userManager, "46519259", "edercinsoft@gmail.com", "System", "Customer", "Patricia", "Lopez", "Vasquez", "DNI", "12345678", "Petitas", Constantes.RolCliente);
        }

        private async Task CrearUsuarioAsync(
            UserManager<Usuario> userManager,
            string username, string email, string firstName, string lastName,
            string nombres, string apePat, string apeMat, string abrevDoc, string nroDoc,
            string sedeDesc, string rol)
        {
            if (await userManager.FindByEmailAsync(email) != null) return;

            var tipoDoc = await _context.Set<TipoDocumento>().FirstOrDefaultAsync(td => td.Abrev == abrevDoc);
            if (tipoDoc == null) throw new InvalidOperationException($"TipoDocumento '{abrevDoc}' no existe.");

            var persona = new Persona
            {
                Nombres = nombres,
                ApellidoPat = apePat,
                ApellidoMat = apeMat,
                FechaNac = new DateTime(1990, 1, 1),
                Edad = "",
                Email = email,
                IdTipoDoc = tipoDoc.Id,
                NroDoc = nroDoc
            };

            var sede = await _context.Set<Sede>().FirstOrDefaultAsync(s => s.Descripcion == sedeDesc);
            if (sede == null)
            {
                sede = new Sede { Descripcion = sedeDesc };
                _context.Add(sede);
                await _context.SaveChangesAsync();
            }

            _context.Add(persona);
            await _context.SaveChangesAsync();

            var user = new Usuario
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = username,
                Email = email,
                EmailConfirmed = true,
                IdPersona = persona.Id,
                IdSede = sede.Id
            };

            var result = await userManager.CreateAsync(user, "Acceso*2024");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, rol);

                var tramiteApp = await _context.Set<Aplicacion>().FirstOrDefaultAsync(a => a.Descripcion == "TRAMITE");

                if (tramiteApp != null)
                {
                    _context.Add(new UsuarioAplicacion { IdUsuario = user.Id, IdAplicacion = tramiteApp.Id });

                    var sedeAppExistente = await _context.Set<SedeAplicacion>()
                        .FirstOrDefaultAsync(sa => sa.IdSede == sede.Id && sa.IdAplicacion == tramiteApp.Id);

                    if (sedeAppExistente == null)
                    {
                        _context.Add(new SedeAplicacion
                        {
                            IdSede = sede.Id,
                            IdAplicacion = tramiteApp.Id,
                            status = true
                        });
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}