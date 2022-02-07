using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.DTO;

namespace Biblioflash.Manager.API
{
    interface IconsultaAPI
    {
        public List<LibroDTO> Consulta(string pTitulo);
    }
}
