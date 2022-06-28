using System;

namespace Biblioflash.Manager.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        public void Complete();

        public IUsuarioRepository UsuarioRepository { get; }
        public IPrestamoRepository PrestamoRepository { get; }
        public ILibroRepository LibroRepository { get; }
        public IEjemplarRepository EjemplarRepository { get; }
        public INotificacionRepository NotificacionRepository { get; }
    }
}
