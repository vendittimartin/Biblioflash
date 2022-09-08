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
        public void EncryptAndDecrypt_Msg_True()
        {
            string encrpyt = "";
            List<string> listOfStrings = new List<string>() {
                "joelb", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
            };
            List<string> listOfStrings2 = new List<string>();
            string[] array2 = new string[] { };
            for (int i = 0; i < 22; i++) {
                encrpyt = Encriptador.GetSHA256(listOfStrings[i]);
                listOfStrings2.Add(encrpyt);
            }

            Assert.AreEqual("hola", listOfStrings2);
        }
    }
}
