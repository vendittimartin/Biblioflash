using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class LibroRepository : Repository<Libro, AccountManagerDbContext>, ILibroRepository
    {
        private readonly DbContext iDbContext;

        public LibroRepository(AccountManagerDbContext pContext) : base(pContext)
        {
            iDbContext = pContext;
        }

        public Libro buscarISBN(Int64 pLibroISBN)
        {
            return this.iDbContext.Set<Libro>().FirstOrDefault(libro => libro.Isbn == pLibroISBN);
        }
    }
}
