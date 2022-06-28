using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class NotificacionRepository : Repository<Notificacion, AccountManagerDbContext>, INotificacionRepository
    {
        private readonly DbContext iDbContext;
        public NotificacionRepository(AccountManagerDbContext pContext) : base(pContext)
        {
            iDbContext = pContext;
        }
        public Notificacion BuscarNotificacion(Int64 pID)
        {
            return this.iDbContext.Set<Notificacion>().FirstOrDefault(notificacion => notificacion.Prestamo.ID == pID);
        }
    }
}
