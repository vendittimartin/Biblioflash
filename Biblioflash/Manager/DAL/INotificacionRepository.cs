using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DAL
{
    public interface INotificacionRepository : IRepository<Notificacion>
    {
        public Notificacion buscarNotificacion(Int64 pID);
    }
}
