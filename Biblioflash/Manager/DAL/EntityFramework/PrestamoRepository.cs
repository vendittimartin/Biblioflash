using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

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

        public List<Prestamo> PrestamosAVencerse()
        {
            IEnumerable<Prestamo> listPrestamos = GetAll();
            List<Prestamo> proximosAVencer = new List<Prestamo>();
            foreach (var prestamo in listPrestamos)
            {
                if (prestamo.FechaRealDevolucion == null)
                {
                    if (prestamo.FechaDevolucion < DateTime.Now.AddDays(2))
                    {
                        proximosAVencer.Add(prestamo);
                    }
                }
            }
            return proximosAVencer;
        }
    }
}
