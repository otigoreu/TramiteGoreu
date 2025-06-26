using Goreu.Tramite.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class UsuarioUnidadOrganicaConfiguration
    {
        public void Configure(EntityTypeBuilder<UsuarioUnidadOrganica> builder)
        {

            builder.HasKey(x => new { x.IdUsuario, x.IdUnidadOrganica });

            builder.Property(x => x.IdUsuario).HasMaxLength(450);

            // Relación con Usuario
            builder
                .HasOne(x => x.Usuario)
                .WithMany(x => x.UsuarioUnidadOrganicas)
                .HasForeignKey(x => x.IdUsuario)
                //.HasPrincipalKey(x => x.Id) // Asegura que se mapea con la PK de Usuario
                .OnDelete(DeleteBehavior.Cascade);

            // Relación con UnidadOrganica
            builder
                .HasOne(x => x.UnidadOrganica)
                .WithMany(x => x.UsuarioUnidadOrganicas)
                .HasForeignKey(x => x.IdUnidadOrganica)
                //.HasPrincipalKey(x => x.Id) // Igual aquí
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
