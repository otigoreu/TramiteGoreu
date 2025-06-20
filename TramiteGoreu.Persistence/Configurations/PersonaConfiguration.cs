using Goreu.Tramite.Entities.Pide;
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
            builder.Property(x => x.ApellidoPat).HasMaxLength(50);
            builder.Property(x => x.ApellidoMat).HasMaxLength(50);

            builder.Property(x => x.FechaNac)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Email).HasMaxLength(50).IsUnicode(false);

            builder
               .HasOne(e => e.TipoDocumento)
               .WithMany(c => c.Personas)
               .HasForeignKey(x => x.IdTipoDoc);

            builder.Property(x => x.NroDoc).HasMaxLength(9).IsUnicode(false);
            builder.ToTable(nameof(Persona), "General");
            builder.HasQueryFilter(x => x.Status);

            builder
               .HasOne(c => c.CredencialesReniec)
               .WithOne(t => t.Persona)
               .HasForeignKey<CredencialReniec>(t => t.PersonaID);
        }
    }
}
