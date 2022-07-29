using Biblioflash.Manager.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestUnitario
{
    [TestClass]
    public class TestsEjemplar
    {
        [TestMethod]
        public void EstaDisponible_PrestamoNoDevuelto_Falso()
        {
            var ejemplar = new Ejemplar();
            ejemplar.ID = 1;
            var prestamo = new Prestamo();
            prestamo.FechaRealDevolucion = null;
            prestamo.Ejemplar = ejemplar;
            var prestamos = new List<Prestamo>();
            prestamos.Add(prestamo);
            ejemplar.Prestamos = prestamos;

            var result = ejemplar.EstaDisponible();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EstaDisponible_PrestamoDevuelto_Verdadero()
        {
            var ejemplar = new Ejemplar();
            ejemplar.ID = 1;
            var prestamo = new Prestamo();
            prestamo.FechaRealDevolucion = System.DateTime.Today;
            prestamo.Ejemplar = ejemplar;
            var prestamos = new List<Prestamo>();
            prestamos.Add(prestamo);
            ejemplar.Prestamos = prestamos;

            var result = ejemplar.EstaDisponible();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EstaDisponible_SinPrestamos_Verdadero()
        {
            var ejemplar = new Ejemplar();
            ejemplar.ID = 1;
           
            var result = ejemplar.EstaDisponible();

            Assert.IsTrue(result);
        }
    }
}
