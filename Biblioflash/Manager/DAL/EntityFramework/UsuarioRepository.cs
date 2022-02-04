using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;


namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class UsuarioRepository : Repository<Usuario, AccountManagerDbContext>, IUsuarioRepository
    {
        private readonly DbContext iDbContext;

        public UsuarioRepository(AccountManagerDbContext pContext) : base(pContext)
        {
            iDbContext = pContext;
        }

        public Usuario buscarUsuario(string pNombreUsuario)
        {
            return this.iDbContext.Set<Usuario>().FirstOrDefault(usuario => usuario.NombreUsuario == pNombreUsuario);
        }
    }
}
