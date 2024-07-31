using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;

namespace TramiteGoreu.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x=>x.nombres).HasMaxLength(50);
            builder.Property(x=>x.apellidos).HasMaxLength(50);
            builder.Property(x => x.fechaNac)
                .HasColumnType("date")
                .HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.direccion).HasMaxLength(100); 
            builder.Property(x => x.referencia).HasMaxLength(200);
            builder.Property(x => x.email).HasMaxLength(50);
            builder.Property(x => x.tipoDoc).HasMaxLength(3);
            builder.Property(x => x.nroDoc).HasMaxLength(9);
            builder.ToTable(nameof(Person), "Administrador");
            builder.HasQueryFilter(x=>x.Status);

        }
    }
}
