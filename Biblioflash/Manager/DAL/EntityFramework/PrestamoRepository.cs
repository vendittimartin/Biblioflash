using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class PrestamoRepository : Repository<Prestamo, AccountManagerDbContext>, IPrestamoRepository
    {
        public PrestamoRepository(AccountManagerDbContext pContext) : base(pContext)
        {

        }

        public List<Prestamo> prestamosADevolverEn(int pDias)
        {
            List<Prestamo> listaDevolver = new List<Prestamo>();
            IEnumerable<Prestamo> listaPrestamos = this.GetAll();
            foreach (var prestamo in listaPrestamos)
            {
                double resta = (prestamo.FechaDevolucion - DateTime.Today).TotalDays;
                if ((resta > 0) & (resta <= pDias) & (!prestamo.estaDevuelto()))
                {
                    listaDevolver.Add(prestamo);
                }
            };
            return listaDevolver;
        }
    }
}
