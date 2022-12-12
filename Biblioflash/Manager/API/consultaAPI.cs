using Biblioflash.Manager.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Biblioflash.Manager.API
{
    public class ConsultaAPI : IconsultaAPI
    {
        public dynamic ConsultarApi(string pTituloLibro)
        {

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var url = "http://openlibrary.org/search.json?title=" + pTituloLibro.Replace(" ", "+");
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse mResponse = Request.GetResponse();
                using Stream responseStream = mResponse.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());
                return (mResponseJSON.docs);
            }
            catch (WebException ex)
            {
                WebResponse mErrorResponse = ex.Response;
                using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                {
                    StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                    String mErrorText = mReader.ReadToEnd();

                    throw new Exception("Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
