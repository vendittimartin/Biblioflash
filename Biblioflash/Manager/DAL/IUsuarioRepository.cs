using Biblioflash.Manager.Domain;
using System.Collections.Generic;

namespace Biblioflash.Manager.DAL
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {

        public Usuario BuscarUsuario(string pNombreUsuario);
        public List<Usuario> BuscarUsuarioSimilitud(string pNombreUsuario);

    }
}
