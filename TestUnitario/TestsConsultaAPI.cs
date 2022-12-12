using Biblioflash.Manager.API;
using Biblioflash.Manager.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestUnitario
{
    [TestClass]
    public class TestsConsultaAPI
    {
        [TestMethod]
        public void ConsultarAPI_Titulo_NotNull()
        {
            ConsultaAPI consultaAPI = new ConsultaAPI();
            string titulo = "Juego de tronos";

            dynamic result = consultaAPI.ConsultarApi(titulo);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ConsultarAPI_CadenaVacia_Null()
        {
            try
            {
                ConsultaAPI consultaAPI = new ConsultaAPI();
                string titulo = "";

                dynamic result = consultaAPI.ConsultarApi(titulo);

                Assert.Fail();
            }
            catch (Exception){ }
        }

        [TestMethod]
        public void ConsultarAPI_CadenaDeEspacios_Null()
        {
            try
            {
                ConsultaAPI consultaAPI = new ConsultaAPI();
                string titulo = "           ";

                dynamic result = consultaAPI.ConsultarApi(titulo);

                Assert.Fail();
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void ConsultarAPI_CadenaEntreEspacios_NotNull()
        {
            ConsultaAPI consultaAPI = new ConsultaAPI();
            string titulo = "     123      ";

            dynamic result = consultaAPI.ConsultarApi(titulo);

            Assert.IsNotNull(result);
        }
    }
}