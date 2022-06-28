using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DAL
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {

        public Usuario BuscarUsuario(string pNombreUsuario);

    }
}
