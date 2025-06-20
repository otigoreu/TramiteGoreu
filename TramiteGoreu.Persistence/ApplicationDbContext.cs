using Goreu.Tramite.Entities.info;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TramiteGoreu.Entities;
using TramiteGoreu.Entities.info;

namespace Goreu.Tramite.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        //PERSONALIZAR LA GEENRACION DE TABLAS
        //FLUENT api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<MenuInfoRol>().HasNoKey();
            modelBuilder.Entity<AplicacionInfo>().HasNoKey();
            modelBuilder.Entity<MenuInfo>().HasNoKey();
            modelBuilder.Entity<PersonaInfo>().HasNoKey();
            modelBuilder.Entity<SedeInfo>().HasNoKey();
            modelBuilder.Entity<TipoDocumentoInfo>().HasNoKey();
            modelBuilder.Entity<AplicacionInfoSede>().HasNoKey();
            //modelBuilder.Entity<Person>().Property(x => x.nombres).HasMaxLength(50);
            //modelBuilder.Entity<Person>().Property(x => x.apellidos).HasMaxLength(50);

            //modelBuilder.Entity<ApplicationUser>(x => x.ToTable("User","General"));
            //modelBuilder.Entity<IdentityRole>(x => x.ToTable("Role","General"));
            modelBuilder.Entity<IdentityUserRole<string>>(x => x.ToTable("UsuarioRol"));
        }

        //Entity to tables
        // public DbSet<Person> Persons { get; set; }

    }
}
