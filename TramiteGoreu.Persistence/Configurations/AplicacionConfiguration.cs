namespace Goreu.Tramite.Persistence.Configurations
{
    public class AplicacionConfiguration : IEntityTypeConfiguration<Aplicacion>
    {
        public void Configure(EntityTypeBuilder<Aplicacion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion).HasMaxLength(50);
            builder.ToTable(nameof(Aplicacion), "Administrador");
            builder.HasQueryFilter(x => x.Estado);

            
        }
    }
}
