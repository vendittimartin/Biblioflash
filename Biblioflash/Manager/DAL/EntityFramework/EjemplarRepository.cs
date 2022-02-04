﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
