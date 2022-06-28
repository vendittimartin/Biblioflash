using Biblioflash.Manager.Domain;
using System;

namespace Biblioflash.Manager.DAL
{
    public interface INotificacionRepository : IRepository<Notificacion>
    {
        public Notificacion BuscarNotificacion(Int64 pID);
    }
}
