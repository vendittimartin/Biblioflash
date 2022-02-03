using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.API;
using Biblioflash.Manager.DTO;

namespace Biblioflash
{
    public class Fachada
    {
        public void pruebaConsulta()
        {
            consultaAPI consulta = new consultaAPI();
            List<LibroDTO> m = consulta.Consulta("the lord of the ring");
            LibroDTO last = m.Last();
            Console.WriteLine("titulo: {0} autor: {1} algo mas: {2}", last.Titulo, last.Autor,last.ISBN);
            Console.ReadKey();
        }
    }
}
