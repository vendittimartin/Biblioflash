using Biblioflash.Manager.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestUnitario
{
    [TestClass]
    public class TestsConsultaAPI
    {
        [TestMethod]
        public void DiasAtrasados_UnDía_1()
        {
            var prestamo = new Prestamo();
            prestamo.FechaDevolucion = DateTime.Today.AddDays(-1);

            var result = prestamo.diasAtrasados();

            Assert.IsTrue(result == 1);
        }

    }
}