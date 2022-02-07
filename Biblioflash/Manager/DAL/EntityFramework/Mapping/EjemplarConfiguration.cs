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
    class EjemplarConfiguration : IEntityTypeConfiguration<Ejemplar>
    {
        public void Configure(EntityTypeBuilder<Ejemplar> builder)
        {
            builder.HasKey(pEjemplar => pEjemplar.ID);

            builder.Property(pEjemplar => pEjemplar.ID).ValueGeneratedOnAdd();

            builder.HasOne(pEjemplar => pEjemplar.Libro);

            builder.HasMany(pEjemplar => pEjemplar.Prestamos);
        }
    }
}
