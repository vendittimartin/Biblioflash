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
            ConsultaAPI consultaAPI = new ConsultaAPI();
            string titulo = "";

            dynamic result = consultaAPI.ConsultarApi(titulo);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConsultarAPI_CadenaDeEspacios_Null()
        {
            ConsultaAPI consultaAPI = new ConsultaAPI();
            string titulo = "           ";

            dynamic result = consultaAPI.ConsultarApi(titulo);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConsultarAPI_CadenaEntreEspacios_NotNull()
        {
            ConsultaAPI consultaAPI = new ConsultaAPI();
            string titulo = "     123      ";

            dynamic result = consultaAPI.ConsultarApi(titulo);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListarLibrosDTO_10_True()
        {
            ConsultaAPI consultaAPI = new ConsultaAPI();
            dynamic archivoJson = consultaAPI.ConsultarApi("juego de tronos");

            List<LibroDTO> result = consultaAPI.ListarLibrosDTO(archivoJson);

            Assert.AreEqual(result.Count, 10);
        }

        [TestMethod]
        public void ListarLibrosDTO_2_True()
        {
            ConsultaAPI consultaAPI = new ConsultaAPI();
            dynamic archivoJson = consultaAPI.ConsultarApi("El arte de Juegos de Tronos");

            List<LibroDTO> result = consultaAPI.ListarLibrosDTO(archivoJson);

            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        public void ListarLibrosDTO_0_True()
        {
            ConsultaAPI consultaAPI = new ConsultaAPI();
            dynamic archivoJson = consultaAPI.ConsultarApi("El amanecer del mañana");

            List<LibroDTO> result = consultaAPI.ListarLibrosDTO(archivoJson);

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void ListarLibrosDTO_Null_IsNull()
        {
            ConsultaAPI consultaAPI = new ConsultaAPI();

            List<LibroDTO> result = consultaAPI.ListarLibrosDTO(null);

            Assert.IsNull(result);
        }
    }

}