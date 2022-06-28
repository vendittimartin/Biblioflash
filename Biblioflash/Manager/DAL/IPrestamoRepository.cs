using Biblioflash.Manager.Domain;
using System;

namespace Biblioflash.Manager.DAL
{
    public interface IPrestamoRepository : IRepository<Prestamo>
    {
        public Prestamo BuscarPrestamo(Int64 pID);

    }
}
