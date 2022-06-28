using Biblioflash.Manager.Domain;
using System;
using System.Collections.Generic;

namespace Biblioflash.Manager.DTO
{
    public class EjemplarDTO
    {
        public Int64 ID { get; set; }
        public virtual LibroDTO Libro { get; set; }
        public virtual List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}
