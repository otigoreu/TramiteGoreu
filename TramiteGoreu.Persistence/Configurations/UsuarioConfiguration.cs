using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));
            builder.Property(x => x.UserName).IsUnicode(false);
            builder.Property(x => x.Email).IsUnicode(false);

            builder.HasOne(ua => ua.Persona)
                   .WithMany(u => u.Usuarios)
                   .HasForeignKey(ua => ua.IdPersona);

        }
    }
}
