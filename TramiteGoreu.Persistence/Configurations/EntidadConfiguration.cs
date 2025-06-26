namespace Goreu.Tramite.Persistence.Configurations
{
    public class EntidadConfiguration : IEntityTypeConfiguration<Entidad>
    {

        public void Configure(EntityTypeBuilder<Entidad> builder) 
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion).HasMaxLength(50);
            builder.ToTable(nameof(Entidad), "Administrador");
            //builder.HasQueryFilter(x => x.Estado);
        }
    }
}
