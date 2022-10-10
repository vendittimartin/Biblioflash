using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public List<Usuario> BuscarUsuarioSimilitud(string pTitulo)
        {
            var queryHighScores =
                from usuario in iDbContext.Set<Usuario>()
                where usuario.NombreUsuario.ToUpper().Contains(pTitulo.ToUpper())
                select new { usuario.NombreUsuario, usuario.ID, usuario.Mail, usuario.Prestamos, usuario.RangoUsuario, usuario.Score, usuario.Contraseña };

            List<Usuario> listUsuarios = new List<Usuario>();
            foreach (var obj in queryHighScores)
            {
                Usuario usuario = new Usuario
                {
                    NombreUsuario = obj.NombreUsuario,
                    ID = obj.ID,
                    Mail = obj.Mail,
                    Prestamos = obj.Prestamos,
                    RangoUsuario = obj.RangoUsuario,
                    Score = obj.Score,
                    Contraseña = obj.Contraseña
                };
                listUsuarios.Add(usuario);
            }
            return listUsuarios;
        }
    }
}

