using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace TramiteGoreu.Persistence.Configurations
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

            builder.HasOne(ua => ua.Sede)
                   .WithMany(a => a.Users)
                   .HasForeignKey(ua => ua.IdSede);
        }
    }
}
