using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace TramiteGoreu.Persistence.Configurations
{
    public class SedeAplicacionConfiguration : IEntityTypeConfiguration<SedeAplicacion>
    {
        public void Configure(EntityTypeBuilder<SedeAplicacion> builder)
        {
            builder.HasKey(x => new { x.IdSede, x.IdAplicacion });

            // Relación con Sede
            builder.HasOne(sa => sa.Sede)
                .WithMany(s => s.SedeAplications)
                .HasForeignKey(sa => sa.IdSede);

            // Relación con Aplication
            builder.HasOne(sa => sa.Aplicacion)
                .WithMany(a => a.SedeAplicaciones)
                .HasForeignKey(sa => sa.IdAplicacion);
        }
    }
}
