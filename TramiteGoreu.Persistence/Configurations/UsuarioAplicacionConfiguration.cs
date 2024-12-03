using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class UsuarioAplicacionConfiguration : IEntityTypeConfiguration<UsuarioAplicacion>

    {
        public void Configure(EntityTypeBuilder<UsuarioAplicacion> builder)
        {
            builder.HasKey(x => new { x.IdUsuario, x.IdAplicacion });
            // Configurar la relación con AspNetUsers
            builder.HasOne(ua => ua.Usuario)
                   .WithMany(u => u.UsuarioAplicaciones)
                   .HasForeignKey(ua => ua.IdUsuario);

            // Configurar la relación con Aplication
            builder.HasOne(ua => ua.Aplicacion)
                   .WithMany(a => a.UsuarioAplicaciones)
                   .HasForeignKey(ua => ua.IdAplicacion);
        }
    }
}
