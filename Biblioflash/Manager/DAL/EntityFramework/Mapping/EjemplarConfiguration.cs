using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
