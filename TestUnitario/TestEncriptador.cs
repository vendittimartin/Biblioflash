using Biblioflash.Manager.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Biblioflash.Manager.Services;

namespace TestUnitario
{
    [TestClass]
    public class TestEncriptador
    {
        [TestMethod]
        public void Encrypt_Msg_True()
        {
            string msg = "h";
            IEncriptador encriptador = new EncriptadorAES();
            string encrpyt = encriptador.Encriptar(msg);
            string decrypt = encriptador.Desencriptar(encrpyt);

            Assert.AreEqual("h", decrypt);
        }
    }
}
