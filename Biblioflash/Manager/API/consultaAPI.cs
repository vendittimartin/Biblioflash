using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using Biblioflash.Manager.DTO;

namespace Biblioflash.Manager.API
{
    public class consultaAPI : IconsultaAPI
    {
        public List<LibroDTO> Consulta(string pTituloLibro) {

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var url = "http://openlibrary.org/search.json?title=" + pTituloLibro.Replace(" ", "+");
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
            try {
                WebResponse mResponse = Request.GetResponse();
                using (Stream responseStream = mResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());
                    List<LibroDTO> librosDTO = new List<LibroDTO>();
                    int i = 0;
                    int cantidad = mResponseJSON.docs.Count;
                    while ((i <= cantidad - 1) && (i < 10))
                    {
                        LibroDTO LibroDTO = new LibroDTO();
                        var bResponseItem = mResponseJSON.docs[i];
                        LibroDTO.Titulo = HttpUtility.HtmlDecode(bResponseItem.title.ToString());
                        if (bResponseItem.author_name != null)
                        {
                            LibroDTO.Autor = HttpUtility.HtmlDecode(bResponseItem.author_name[0].ToString());
                        }
                        else
                        {
                            LibroDTO.Autor = "Anonimo";
                        }
                        if (bResponseItem.isbn != null)
                        {
                            string isbn = HttpUtility.HtmlDecode(bResponseItem.isbn[0].ToString());
                            string isbnSinX = isbn.Replace("X", "");
                            LibroDTO.ISBN = Int64.Parse(isbnSinX);
                        }
                        else
                        {
                            LibroDTO.ISBN = 0;
                        }
                        librosDTO.Add(LibroDTO);
                        i++;
                    }
                    return librosDTO;
                }
            }
            catch (WebException ex)
            {
                WebResponse mErrorResponse = ex.Response;
                using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                {
                    StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                    String mErrorText = mReader.ReadToEnd();

                    System.Console.WriteLine("Error: {0}", mErrorText);
                }
                return new List<LibroDTO>();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: {0}", ex.Message);
                return new List<LibroDTO>();
            }
        }
    }
}
