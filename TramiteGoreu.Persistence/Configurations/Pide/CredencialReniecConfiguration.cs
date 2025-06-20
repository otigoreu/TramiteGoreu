using Goreu.Tramite.Entities.Pide;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class CredencialReniecConfiguration : IEntityTypeConfiguration<CredencialReniec>
    {
        public void Configure(EntityTypeBuilder<CredencialReniec> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(CredencialReniec), "Pide");
        }
    }
}
