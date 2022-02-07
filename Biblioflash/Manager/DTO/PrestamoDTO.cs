using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DTO
{
    public class PrestamoDTO
    {
        public Int64 ID { get; set; }
        public Int64 IDEjemplar { get; set; }
        public Libro Libro { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaDevolucion { get; set; }

        public DateTime? FechaRealDevolucion { get; set; }
        public string estadoDevolucion { get; set; }
    }
}
