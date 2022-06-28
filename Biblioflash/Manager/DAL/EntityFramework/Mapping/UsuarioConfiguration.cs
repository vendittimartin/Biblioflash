using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioflash.Manager.DAL.EntityFramework.Mapping
{
    class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(pClient => pClient.ID);

            builder.HasAlternateKey(pClient => pClient.NombreUsuario);

            builder.Property(pClient => pClient.NombreUsuario)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(pCliente => pCliente.RangoUsuario);

            builder.Property(pClient => pClient.ID).ValueGeneratedOnAdd();

            builder.Property(pClient => pClient.Contraseña)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(pCliente => pCliente.Mail)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(pClient => pClient.Prestamos);
        }
    }
}
