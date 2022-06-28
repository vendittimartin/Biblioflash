using System;
using System.Collections.Generic;

namespace Biblioflash.Manager.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity pEntity);
        public void Remove(TEntity pEntity);
        public TEntity Get(Int64 pId);
        public IEnumerable<TEntity> GetAll();
    }
}
