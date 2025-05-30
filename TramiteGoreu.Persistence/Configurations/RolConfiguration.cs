using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.ToTable(nameof(Role));
        }
    }
}
