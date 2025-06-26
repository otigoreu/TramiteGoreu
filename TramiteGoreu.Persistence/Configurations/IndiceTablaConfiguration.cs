namespace Goreu.Tramite.Persistence.Configurations
{
    public class IndiceTablaConfiguration : IEntityTypeConfiguration<IndiceTabla>
    {
        public void Configure(EntityTypeBuilder<IndiceTabla> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion).HasMaxLength(50);
            builder.ToTable(nameof(IndiceTabla), "Seguridad");
        }
    }
}
