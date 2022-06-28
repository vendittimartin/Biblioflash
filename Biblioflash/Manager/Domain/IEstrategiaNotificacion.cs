using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DAL
{
    public interface IEstrategiaNotificacion
    {
        public void NotificarUsuario(Notificacion notif);
    }
}
