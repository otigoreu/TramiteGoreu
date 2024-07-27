using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TramiteGoreu.Entities;

namespace TramiteGoreu.Persistence
{
    public class ApplicationDbContext : DbContext
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
            //modelBuilder.Entity<Person>().Property(x => x.nombres).HasMaxLength(50);
            //modelBuilder.Entity<Person>().Property(x => x.apellidos).HasMaxLength(50);
        }

        //Entity to tables
       // public DbSet<Person> Persons { get; set; }

    }
}
