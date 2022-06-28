using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class UsuarioRepository : Repository<Usuario, AccountManagerDbContext>, IUsuarioRepository
    {
        private readonly DbContext iDbContext;

        public UsuarioRepository(AccountManagerDbContext pContext) : base(pContext)
        {
            iDbContext = pContext;
        }

        public Usuario BuscarUsuario(string pNombreUsuario)
        {
            return this.iDbContext.Set<Usuario>().FirstOrDefault(usuario => usuario.NombreUsuario == pNombreUsuario);
        }
    }
}
