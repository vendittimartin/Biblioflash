using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioflash.Manager.Domain
{
    public class Notificacion
    {
        public Int64 ID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Prestamo Prestamo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Asunto { get; set; }
    }
}
