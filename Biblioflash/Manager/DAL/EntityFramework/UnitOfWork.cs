using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccountManagerDbContext iDbContext;

        private bool iDisposedValue = false;

        public IUsuarioRepository UsuarioRepository { get; private set; }
        public IPrestamoRepository PrestamoRepository { get; private set; }
        public ILibroRepository LibroRepository { get; private set; }
        public IEjemplarRepository EjemplarRepository { get; private set; }
        public INotificacionRepository NotificacionRepository { get; private set; }


        public UnitOfWork(AccountManagerDbContext pContext)
        {
            if (pContext == null)
            {
                throw new NotImplementedException();
            }

            iDbContext = pContext;
            this.UsuarioRepository = new UsuarioRepository(pContext);
            this.PrestamoRepository = new PrestamoRepository(pContext);
            this.LibroRepository = new LibroRepository(pContext);
            this.EjemplarRepository = new EjemplarRepository(pContext);
            this.NotificacionRepository = new NotificacionRepository(pContext);
        }
        public void Complete()
        {
           try
            {
                iDbContext.SaveChanges();
            }
            catch (DbUpdateException exc)
            {
                throw new UpdateFailException(exc.InnerException.Message);
            }
        }

        protected virtual void Dispose(bool pDisposing)
        {
            if (!this.iDisposedValue)
            {
                if (pDisposing)
                {
                    this.iDbContext.Dispose();
                }

                this.iDisposedValue = true;
            }
        }

        public void Dispose()
        {
            iDbContext.Dispose();
        }

    }
}
