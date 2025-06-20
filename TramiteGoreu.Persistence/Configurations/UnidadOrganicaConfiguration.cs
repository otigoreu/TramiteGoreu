using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class UnidadOrganicaConfiguration : IEntityTypeConfiguration<UnidadOrganica>
    {
        public void Configure(EntityTypeBuilder<UnidadOrganica> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion).HasMaxLength(50);
            builder.ToTable(nameof(UnidadOrganica), "General");
            builder.HasQueryFilter(x => x.Estado);

            builder.HasOne(ua => ua.Entidad)
                .WithMany(u => u.UnidadOrganicas)
                .HasForeignKey(ua => ua.IdEntidad);

            
        }

    }
}
