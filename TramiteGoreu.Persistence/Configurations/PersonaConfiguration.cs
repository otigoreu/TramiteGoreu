using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombres).HasMaxLength(50);
            builder.Property(x => x.Apellidos).HasMaxLength(50);
            builder.Property(x => x.FechaNac)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Direccion).HasMaxLength(100);
            builder.Property(x => x.Referencia).HasMaxLength(200);
            builder.Property(x => x.Celular).HasMaxLength(20);
            builder.Property(x => x.Edad).HasMaxLength(3);
            builder.Property(x => x.Email).HasMaxLength(50).IsUnicode(false);
            builder.Property(x => x.TipoDoc).HasMaxLength(3);
            builder.Property(x => x.NroDoc).HasMaxLength(9).IsUnicode(false);
            builder.ToTable(nameof(Persona), "General");
            builder.HasQueryFilter(x => x.Status);

        }
    }
}
