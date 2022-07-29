using Biblioflash.Manager.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestUnitario
{
    [TestClass]
    public class TestsPrestamo
    {
        [TestMethod]
        public void DiasAtrasados_UnDía_1()
        {
            var prestamo = new Prestamo();
            prestamo.FechaDevolucion = DateTime.Today.AddDays(-1);

            var result = prestamo.diasAtrasados();

            Assert.IsTrue(result == 1);
        }
        [TestMethod]
        public void DiasAtrasados_NoAtrasado_0()
        {
            var prestamo = new Prestamo();
            prestamo.FechaDevolucion = DateTime.Today.AddDays(1);

            var result = prestamo.diasAtrasados();

            Assert.IsTrue(result == 0);
        }
        [TestMethod]
        public void DiasAtrasados_FechaLimite_0()
        {
            var prestamo = new Prestamo();
            prestamo.FechaDevolucion = DateTime.Today;

            var result = prestamo.diasAtrasados();

            Assert.IsTrue(result == 0);
        }


        [TestMethod]
        public void RegistrarAtraso_5DiasBuenEstado_menos5()
        {
            var prestamo = new Prestamo();
            var usuario = new Usuario();
            usuario.Score = 0;
            prestamo.Usuario = usuario;
            prestamo.FechaDevolucion = DateTime.Today.AddDays(-5);
            prestamo.estadoPrestamo = "Bueno";

            prestamo.registrarAtraso();
            int result = prestamo.Usuario.Score;

            Assert.IsTrue(result == -5);
        }
        [TestMethod]
        public void RegistrarAtraso_5DiasMalEstado_menos20()
        {
            var prestamo = new Prestamo();
            var usuario = new Usuario();
            usuario.Score = 0;
            prestamo.Usuario = usuario;
            prestamo.FechaDevolucion = DateTime.Today.AddDays(-5);
            prestamo.estadoPrestamo = "Malo";

            prestamo.registrarAtraso();
            int result = prestamo.Usuario.Score;

            Assert.IsTrue(result == -20);
        }
        [TestMethod]
        public void RegistrarAtraso_SinAtrasoMalEstado_menos10()
        {
            var prestamo = new Prestamo();
            var usuario = new Usuario();
            usuario.Score = 0;
            prestamo.Usuario = usuario;
            prestamo.FechaDevolucion = DateTime.Today.AddDays(5);
            prestamo.estadoPrestamo = "Malo";

            prestamo.registrarAtraso();
            int result = prestamo.Usuario.Score;

            Assert.IsTrue(result == -10);
        }
        [TestMethod]
        public void RegistrarAtraso_SinAtrasoBuenEstado_mas5()
        {
            var prestamo = new Prestamo();
            var usuario = new Usuario();
            usuario.Score = 0;
            prestamo.Usuario = usuario;
            prestamo.FechaDevolucion = DateTime.Today.AddDays(5);
            prestamo.estadoPrestamo = "Bueno";

            prestamo.registrarAtraso();
            int result = prestamo.Usuario.Score;

            Assert.IsTrue(result == 5);
        }

    }
}