using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioflash.Manager.Domain
{
    public class Ejemplar
    {
        public Int64 ID { get; set; }
        public virtual Libro Libro { get; set; }
        public virtual List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        public bool EstaDisponible()
        {
            if (Prestamos.Count() != 0)
            {
                Prestamo lastPrestamo = Prestamos.Last();
                if (lastPrestamo.FechaRealDevolucion == null)
                { return false; }
                else { return true; } 
            }
            else
            {
                return true;
            }

        }
    }
}
