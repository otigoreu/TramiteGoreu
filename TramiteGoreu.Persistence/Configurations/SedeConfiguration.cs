using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace TramiteGoreu.Persistence.Configurations
{
    public class SedeConfiguration: IEntityTypeConfiguration<Sede>
    {
        public void Configure(EntityTypeBuilder<Sede> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion).HasMaxLength(50);
            builder.ToTable(nameof(Sede), "General");
            builder.HasQueryFilter(x => x.Status);

            // Relación con SedeAplication (uno a muchos)
            builder.HasMany(s => s.SedeAplications)
                .WithOne(sa => sa.Sede)
                .HasForeignKey(sa => sa.IdSede);
        }

    }
}
