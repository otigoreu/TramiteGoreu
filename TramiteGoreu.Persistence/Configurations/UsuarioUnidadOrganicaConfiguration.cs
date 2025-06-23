using Goreu.Tramite.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class UsuarioUnidadOrganicaConfiguration
    {

        public void Configure(EntityTypeBuilder<UsuarioUnidadOrganica> builder)
        {

            builder.HasKey(x => new { x.IdUsuario, x.IdUnidadOrganica });

            //configurar la relacion con usuario
            builder.HasOne(ua => ua.Usuario)
                .WithMany(u => u.UsuarioUnidadOrganicas)
                .HasForeignKey(ua=>ua.IdUsuario);

            //configurar la relacion con UnidadOrganica
            builder.HasOne(ua => ua.UnidadOrganica)
                .WithMany(a => a.UsuarioUnidadOrganicas)
                .HasForeignKey(ua=>ua.IdUnidadOrganica);
        
        }

    }
}
