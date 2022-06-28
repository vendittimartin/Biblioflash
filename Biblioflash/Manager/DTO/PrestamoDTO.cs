using Biblioflash.Manager.Domain;
using System;

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
