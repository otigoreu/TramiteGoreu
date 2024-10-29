using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace TramiteGoreu.Persistence.Configurations
{
    public class MenuRolConfiguration : IEntityTypeConfiguration<MenuRol>
    {
        public void Configure(EntityTypeBuilder<MenuRol> builder)
        {
            builder.HasKey(x => new { x.IdMenu, x.IdRol });
            // Configurar la relación con menu
            builder.HasOne(ua => ua.Menu)
                   .WithMany(u => u.MenuRoles)
                   .HasForeignKey(ua => ua.IdMenu);

            // Configurar la relación con role
            builder.HasOne(ua => ua.Rol)
                   .WithMany(a => a.MenuRoles)
                   .HasForeignKey(ua => ua.IdRol);
        }
    }
}
