using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioflash.Manager.DAL.EntityFramework.Mapping
{
    class NotificacionConfiguration : IEntityTypeConfiguration<Notificacion>
    {

        public void Configure(EntityTypeBuilder<Notificacion> builder)
        {
            builder.HasKey(pNotificacion => pNotificacion.ID);

            builder.Property(pNotificacion => pNotificacion.ID).ValueGeneratedOnAdd();

            builder.Property(pNotificacion => pNotificacion.Descripcion)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(pNotificacion => pNotificacion.Usuario);

            builder.HasOne(pNotificacion => pNotificacion.Prestamo);
        }
    }
}
