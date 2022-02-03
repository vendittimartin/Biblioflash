using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioflash.Manager.DTO
{
    public class LibroDTO
    {
        public Int64 ISBN { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }
        public List<EjemplarDTO> Ejemplares { get; set; }
    }
}
