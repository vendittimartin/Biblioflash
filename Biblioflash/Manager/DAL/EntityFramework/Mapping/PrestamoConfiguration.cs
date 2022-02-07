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
    class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.HasKey(pPrestamo => pPrestamo.ID);

            builder.Property(pPrestamo => pPrestamo.ID).ValueGeneratedOnAdd();

            builder.Property(pPrestamo => pPrestamo.FechaPrestamo).IsRequired();

            builder.Property(pPrestamo => pPrestamo.FechaDevolucion).IsRequired();

            builder.Property(pPrestamo => pPrestamo.FechaRealDevolucion);

            builder.HasOne(pPrestamo => pPrestamo.Ejemplar);

            builder.HasOne(pPrestamo => pPrestamo.Usuario);
        }
    }
}
