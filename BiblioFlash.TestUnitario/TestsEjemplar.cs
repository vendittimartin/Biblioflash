using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BiblioFlash.TestUnitario
{
    [TestClass]
    public class TestsEjemplar
    {
        [TestMethod]
        public void EstaDisponible_PrestamoNoDevuelto_Falso()
        {
            //Arange
            var ejemplar = new Ejemplar();
            ejemplar.ID = 1;
            var prestamo = new Prestamo();
            prestamo.fechaRealDevolucion = null;
            prestamo.Ejemplar = ejemplar;
            var List<Prestamo> prestamos  = new List<Prestamo>();
            prestamos.add(prestamo);
            ejemplar.prestamos = prestamos;

            //Act
            var result = ejemplar.EstaDisponible();

            //Assert
            Assert.IsFalse(result);
        }
    }
}
