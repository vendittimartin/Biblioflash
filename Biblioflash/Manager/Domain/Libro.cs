﻿using System;
using System.Collections.Generic;

namespace Biblioflash.Manager.Domain
{
    public class Libro
    {
        public Int64 ID { get; set; }
        public Int64 Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public virtual List<Ejemplar> Ejemplares { get; set; } = new List<Ejemplar>();

    }
}
