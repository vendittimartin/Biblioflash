using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DTO
{
    public class UsuarioDTO
    {
        public string NombreUsuario { get; set; }

        public int Score { get; set; }

        public Rango RangoUsuario { get; set; }

        public string Mail { get; set; }
    }
}
