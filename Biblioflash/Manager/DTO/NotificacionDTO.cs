using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DTO
{
    public class NotificacionDTO
    {
        public Int64 ID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public Prestamo Prestamo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Asunto { get; set; }
    }
}
