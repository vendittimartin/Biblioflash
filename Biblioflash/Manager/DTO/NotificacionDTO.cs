using Biblioflash.Manager.Domain;
using System;

namespace Biblioflash.Manager.DTO
{
    public class NotificacionDTO
    {
        public Int64 ID { get; set; }
        public virtual UsuarioDTO Usuario { get; set; }
        public PrestamoDTO Prestamo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Asunto { get; set; }
    }
}
