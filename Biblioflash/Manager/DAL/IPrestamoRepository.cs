using Biblioflash.Manager.Domain;
using System;
using System.Collections.Generic;

namespace Biblioflash.Manager.DAL
{
    public interface IPrestamoRepository : IRepository<Prestamo>
    {
        public Prestamo BuscarPrestamo(Int64 pID);
        public List<Prestamo> PrestamosAVencerse();
    }
}
