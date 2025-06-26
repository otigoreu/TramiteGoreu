namespace Goreu.Tramite.Persistence.Configurations
{
    public class UnidadOrganicaConfiguration : IEntityTypeConfiguration<UnidadOrganica>
    {
        public void Configure(EntityTypeBuilder<UnidadOrganica> builder)
        {
            builder.ToTable(nameof(UnidadOrganica), "General");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion).HasMaxLength(50);
            
            builder.HasQueryFilter(x => x.Estado);

            builder
                .HasOne(ua => ua.Entidad)
                .WithMany(u => u.UnidadOrganicas)
                .HasForeignKey(ua => ua.IdEntidad);

            // Relación recursiva: Padre -> Hijas
            builder
                .HasOne(ua => ua.Dependencia)
                .WithMany(ua => ua.Hijos)
                .HasForeignKey(ua => ua.IdDependencia)
                .OnDelete(DeleteBehavior.Restrict); // Para evitar eliminación en cascada recursiva
        }
    }
}
