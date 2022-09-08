using System.Text;
using System.Security.Cryptography;
using System;

namespace Biblioflash.Manager.Services
{
    public class Encriptador
    {
        public static string GetSHA256(string str)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(str);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public static String Decrypt(String value)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(value);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
