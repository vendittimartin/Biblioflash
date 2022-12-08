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

        public List<Prestamo> PrestamoUsuario(string pNombreUsuario)
        {
            var query =
                from prestamo in iDbContext.Set<Prestamo>()
                where prestamo.Usuario.NombreUsuario == pNombreUsuario
                select new { prestamo.Ejemplar, prestamo.estadoPrestamo, prestamo.FechaDevolucion, prestamo.FechaPrestamo, prestamo.FechaRealDevolucion, prestamo.ID, prestamo.Usuario };
            
            List<Prestamo> Prestamos = new List<Prestamo>();
            foreach (var obj in query)
            {
                Prestamo p = new Prestamo
                {
                    Ejemplar = obj.Ejemplar,
                    estadoPrestamo = obj.estadoPrestamo,
                    FechaRealDevolucion = obj.FechaRealDevolucion,
                    FechaDevolucion = obj.FechaDevolucion,
                    FechaPrestamo = obj.FechaPrestamo,
                    ID = obj.ID,
                    Usuario = obj.Usuario
                };
                Prestamos.Add(p);
            }
            return Prestamos;
        }

        public List<Prestamo> PrestamosNoDevueltos()
        {
            var queryHighScores =
                from prestamo in iDbContext.Set<Prestamo>()
                where prestamo.FechaRealDevolucion == null
                select new { prestamo.Ejemplar, prestamo.estadoPrestamo, prestamo.FechaDevolucion, prestamo.FechaPrestamo, prestamo.FechaRealDevolucion, prestamo.ID, prestamo.Usuario };
            
            List<Prestamo> Prestamos = new List<Prestamo>();
            foreach (var obj in queryHighScores)
            {
                Prestamo p = new Prestamo
                {
                    Ejemplar = obj.Ejemplar,
                    estadoPrestamo = obj.estadoPrestamo,
                    FechaRealDevolucion = obj.FechaRealDevolucion,
                    FechaDevolucion = obj.FechaDevolucion,
                    FechaPrestamo = obj.FechaPrestamo,
                    ID = obj.ID,
                    Usuario = obj.Usuario
                };
                Prestamos.Add(p);
            }
            return Prestamos;
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
