namespace Goreu.Tramite.Persistence.Configurations
{
    public class HistorialConfiguration : IEntityTypeConfiguration<Historial>
    {
        public void Configure(EntityTypeBuilder<Historial> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable(nameof(Historial), "Seguridad");

            builder
              .HasOne(ua => ua.IndiceTabla)
              .WithMany(u => u.Historials)
              .HasForeignKey(ua => ua.idIndiceTabla);

            builder
              .HasOne(ua => ua.Usuario)
              .WithMany(u => u.Historials)
              .HasForeignKey(ua => ua.idUsuario);
        }
    }
}
