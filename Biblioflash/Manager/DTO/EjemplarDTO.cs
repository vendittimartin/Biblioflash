using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioflash.Manager.DTO
{
    public class EjemplarDTO
    {
        public Int64 ISBN { get; set; }

        public Int64 ID { get; set; }

        public bool Disponible { get; set; }
    }
}
