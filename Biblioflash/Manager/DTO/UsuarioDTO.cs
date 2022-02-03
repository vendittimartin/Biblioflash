using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;

namespace TP_Final.Manager.DTO
{
    public class UsuarioDTO
    {
        public string Nombre { get; set; }

        public int Puntos { get; set; }

        public Rango RangoUsuario { get; set; }

        public string Mail { get; set; }
    }
}
