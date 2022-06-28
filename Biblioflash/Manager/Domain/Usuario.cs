using System;
using System.Collections.Generic;

namespace Biblioflash.Manager.Domain
{
    public class Usuario
    {
        public Int64 ID { get; set; }
        public int Score { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }
        public Rango RangoUsuario { get; set; }
        public virtual List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}
