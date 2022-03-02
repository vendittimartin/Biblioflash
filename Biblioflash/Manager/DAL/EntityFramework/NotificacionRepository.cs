using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class NotificacionRepository : Repository<Notificacion, AccountManagerDbContext>, INotificacionRepository
    {
        public NotificacionRepository(AccountManagerDbContext pContext) : base(pContext)
        {

        }
    }
}
