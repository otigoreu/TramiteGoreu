using Goreu.Tramite.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TramiteGoreu.Entities;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class EntidadConfiguration : IEntityTypeConfiguration<Entidad>
    {

        public void Configure(EntityTypeBuilder<Entidad> builder) 
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion).HasMaxLength(50);
            builder.ToTable(nameof(Entidad), "Administrador");
            builder.HasQueryFilter(x => x.Estado);


        }


    }
}
