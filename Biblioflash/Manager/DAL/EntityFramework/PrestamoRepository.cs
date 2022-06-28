using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class PrestamoRepository : Repository<Prestamo, AccountManagerDbContext>, IPrestamoRepository
    {
        private readonly DbContext iDbContext;
        public PrestamoRepository(AccountManagerDbContext pContext) : base(pContext)
        {
            iDbContext = pContext;
        }
        public Prestamo BuscarPrestamo(Int64 pID)
        {
            return this.iDbContext.Set<Prestamo>().FirstOrDefault(prestamo => prestamo.ID == pID);
        }
    }
}
