using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioflash.Manager.Domain
{
    public class Prestamo
    {
        public DateTime? FechaRealDevolucion { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public Usuario Usuario { get; set; }
        public Ejemplar Ejemplar { get; set; }
        public Int64 ID { get; set; }

        public void registrarDevolucion()
        {
            FechaRealDevolucion = DateTime.Now;
        }

        public bool estaDevuelto()
        {
            if (FechaRealDevolucion == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool prestamoAtrasado()
        {
            if (DateTime.Today > FechaDevolucion)
            {
                if (estaDevuelto() == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
    }
}
