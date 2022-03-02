using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class NotificacionRepository : Repository<Notificacion, AccountManagerDbContext>, INotificacionRepository
    {
        private readonly DbContext iDbContext;
        public NotificacionRepository(AccountManagerDbContext pContext) : base(pContext)
        {
            iDbContext = pContext;
        }
        public Notificacion buscarNotificacion(Int64 pID)
        {
            return this.iDbContext.Set<Notificacion>().FirstOrDefault(notificacion => notificacion.Prestamo.ID == pID);
        }
    }
}
