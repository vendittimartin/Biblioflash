using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DAL.EntityFramework.Mapping
{
    class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.HasKey(pLibro => pLibro.ID);

            builder.Property(pLibro => pLibro.ID).ValueGeneratedOnAdd();

            builder.HasAlternateKey(pLibro => pLibro.Isbn);

            builder.Property(pLibro => pLibro.Isbn)
                   .IsRequired();

            builder.Property(pLibro => pLibro.Titulo)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(pLibro => pLibro.Autor)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasMany(pLibro => pLibro.Ejemplares);
        }
    }
}
