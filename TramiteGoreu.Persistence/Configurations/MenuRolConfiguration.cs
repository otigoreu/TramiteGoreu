using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class MenuRolConfiguration : IEntityTypeConfiguration<MenuRol>
    {
        public void Configure(EntityTypeBuilder<MenuRol> builder)
        {
            builder.HasKey(x => x.Id);

            // Configurar la relación con menu
            builder
                .HasOne(ua => ua.Menu)
                .WithMany(u => u.MenuRoles)
                .HasForeignKey(ua => ua.IdMenu)
                .OnDelete(DeleteBehavior.Cascade); // Se mantiene la cascada aquí

            // Configurar la relación con role
            builder
                .HasOne(ua => ua.Rol)
                .WithMany(a => a.MenuRoles)
                .HasForeignKey(ua => ua.IdRole)
                .OnDelete(DeleteBehavior.Restrict); // Evita cascada aquí
        }
    }
}
