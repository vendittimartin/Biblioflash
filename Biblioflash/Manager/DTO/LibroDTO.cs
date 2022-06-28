using Biblioflash.Manager.Domain;
using System;
using System.Collections.Generic;

namespace Biblioflash.Manager.DTO
{
    public class LibroDTO
    {
        public Int64 ISBN { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }
        public List<Ejemplar> Ejemplares { get; set; }
    }
}
