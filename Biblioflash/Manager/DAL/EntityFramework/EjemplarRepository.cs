using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    class EjemplarRepository : Repository<Ejemplar, AccountManagerDbContext>, IEjemplarRepository
    {
        public EjemplarRepository(AccountManagerDbContext pContext) : base(pContext)
        {

        }
    }
}
