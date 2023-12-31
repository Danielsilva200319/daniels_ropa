using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
    {
        public void Configure(EntityTypeBuilder<Prenda> builder)
        {
            builder.ToTable("prenda");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(p => p.IdPrenda)
            .IsUnique();

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(20);

            builder.Property(p => p.ValorUnitCop)
            .HasColumnType("double");

            builder.Property(p => p.ValorUnitUsd)
            .HasColumnType("double");

            builder.HasOne(p => p.Estados)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdEstado);

            builder.HasOne(p => p.TipoProtecciones)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdTipoProteccion);

            builder.HasOne(p => p.Generos)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdGenero);
        }
    }
}