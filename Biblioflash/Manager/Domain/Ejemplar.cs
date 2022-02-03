﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioflash.Manager.Domain
{
    public class Ejemplar
    {
        public Int64 ID { get; set; }
        public Libro Libro { get; set; }
        public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        public bool estaDisponible()
        {
            if (Prestamos.Count == 0)
            {
                return true;
            }
            else 
            {
                Prestamo lastPrestamo = Prestamos.Last();
                return lastPrestamo.estaDevuelto();
            }
        }
    }
}
