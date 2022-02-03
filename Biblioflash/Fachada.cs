using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.API;

namespace Biblioflash
{
    public class Fachada
    {
        public void pruebaConsulta()
        {
            consultaAPI consulta = new consultaAPI();
            dynamic m = consulta.Consulta("the lord of the ring");
            foreach (var i in m)
            {
                string titulo = i.Title;
                string autor = i.author_name;
                Console.WriteLine(titulo, autor); 
            }
        }
    }
}
