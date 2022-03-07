using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class PrestamoRepository : Repository<Prestamo, AccountManagerDbContext>, IPrestamoRepository
    {
        private readonly DbContext iDbContext;
        public PrestamoRepository(AccountManagerDbContext pContext) : base(pContext)
        {
            iDbContext = pContext;
        }
        public Prestamo buscarPrestamo(Int64 pID)
        {
            return this.iDbContext.Set<Prestamo>().FirstOrDefault(prestamo => prestamo.ID == pID);
        }
    }
}
