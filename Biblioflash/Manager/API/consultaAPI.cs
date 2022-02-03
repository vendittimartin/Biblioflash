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
    public class consultaAPI
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
                        //Creamos el DTO
                        LibroDTO LibroDTO = new LibroDTO();

                        // De esta manera se accede a los componentes de cada item
                        var bResponseItem = mResponseJSON.docs[i];

                        // Se decodifican algunos elementos HTML
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

            foreach (var i in m)
            {
                string titulo = i.tittle;
                string autor = i.author_name;
                Console.WriteLine(titulo, autor);
            }
            LibroDTO libroDTO = new LibroDTO();
            List<LibroDTO> libroDTOs = new List<LibroDTO>();
            return libroDTOs;
             
        }
    }
}
