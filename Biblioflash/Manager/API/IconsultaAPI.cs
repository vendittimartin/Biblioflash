using Biblioflash.Manager.DTO;
using System.Collections.Generic;

namespace Biblioflash.Manager.API
{
    interface IconsultaAPI
    {
        public List<LibroDTO> Consulta(string pTitulo);
    }
}
