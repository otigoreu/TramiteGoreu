using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class AplicacionConfiguration : IEntityTypeConfiguration<Aplicacion>
    {
        public void Configure(EntityTypeBuilder<Aplicacion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion).HasMaxLength(50);
            builder.ToTable(nameof(Aplicacion), "Administrador");
            builder.HasQueryFilter(x => x.Status);

            // Relación con SedeAplication (uno a muchos)
            builder.HasMany(a => a.SedeAplicaciones)
                .WithOne(sa => sa.Aplicacion)
                .HasForeignKey(sa => sa.IdAplicacion);
        }
    }
}
