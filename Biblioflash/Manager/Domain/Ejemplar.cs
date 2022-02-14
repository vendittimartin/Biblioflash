using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioflash.Manager.Domain
{
    public class Ejemplar
    {
        public Int64 ID { get; set; }
        public virtual Libro Libro { get; set; }
        public virtual List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        public bool estaDisponible()
        {
            //PARCHEAR
            if (true)
            {
                //Prestamo lastPrestamo = Prestamos.Last();
                return true; //lastPrestamo.estaDevuelto();
            }
            else 
            {
                return true;
            }
        }
    }
}
