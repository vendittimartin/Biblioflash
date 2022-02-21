using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioflash.Manager.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        public void Complete();

        public IUsuarioRepository UsuarioRepository { get; }
        public IPrestamoRepository PrestamoRepository { get; }
        public ILibroRepository LibroRepository { get; }
        public IEjemplarRepository EjemplarRepository { get; }
    }
}
