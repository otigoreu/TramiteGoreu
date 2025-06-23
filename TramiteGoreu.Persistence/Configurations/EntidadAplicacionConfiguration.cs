using Goreu.Tramite.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Goreu.Tramite.Persistence.Configurations
{
   public  class EntidadAplicacionConfiguration
    {

        public void Configure(EntityTypeBuilder<EntidadAplicacion> builder)
        {
            builder.HasKey(x => new { x.IdEntidad,x.IdAplicacion});
            //configuracion de relacion con entidad
            builder.HasOne(ua => ua.Entidad)
                .WithMany(u => u.EntidadAplicaciones)
                .HasForeignKey(ua => ua.IdEntidad);

            //configuracion de relacion con aplicacion
            builder.HasOne(ua => ua.Aplicacion)
                .WithMany(a => a.EntidadAplicaciones)
                .HasForeignKey(ua => ua.IdAplicacion);

        }


    }
}
