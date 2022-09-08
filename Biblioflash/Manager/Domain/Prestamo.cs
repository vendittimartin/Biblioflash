using System;

namespace Biblioflash.Manager.Domain
{
    public class Prestamo
    {
        public Int64 ID { get; set; }
        public DateTime? FechaRealDevolucion { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Ejemplar Ejemplar { get; set; }
        public string estadoPrestamo { get; set; }

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

        public int diasAtrasados()
        {
            if (DateTime.Today > FechaDevolucion)
            {
                return Convert.ToInt32((DateTime.Today - FechaDevolucion).TotalDays);
            }
            else
            {
                return 0;
            }
        }

        public void registrarAtraso() 
        {
            int diasAtrasado = diasAtrasados();
            if (diasAtrasado != 0)
            {
                Usuario.Score -= ( 2 * diasAtrasado);
            }
            if (estadoPrestamo == "Malo")
            {
                Usuario.Score -= 10;
            }
            else
            {
                Usuario.Score += 5;
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
