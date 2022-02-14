using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DTO
{
    public class EjemplarDTO
    {
        public Int64 ID { get; set; }
        public virtual LibroDTO Libro { get; set; }
        public virtual List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}
