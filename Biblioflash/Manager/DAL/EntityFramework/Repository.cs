using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public abstract class Repository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : class where TDbContext : DbContext
    {
        private readonly TDbContext iDbContext;

        /// <summary>
        /// Crea y añade un <paramref name="pContext"> al Repositorio
        public Repository(TDbContext pContext)
        {
            if (pContext == null)
            {
                throw new ArgumentNullException(nameof(pContext));
            }

            iDbContext = pContext;
        }

        public void Add(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Add(pEntity);
        }

        public TEntity Get(Int64 pId)
        {
            return this.iDbContext.Set<TEntity>().Find(pId);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.iDbContext.Set<TEntity>();
        }

        public void Remove(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Remove(pEntity);
        }
    }
}
