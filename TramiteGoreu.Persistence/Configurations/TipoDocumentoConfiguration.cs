﻿using Goreu.Tramite.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Goreu.Tramite.Persistence.Configurations
{
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descripcion).HasMaxLength(200);
            builder.Property(x => x.Abrev).HasMaxLength(50);
            builder.ToTable(nameof(TipoDocumento), "Administrador");
            builder.HasQueryFilter(x => x.Status);
        }
    }
}
