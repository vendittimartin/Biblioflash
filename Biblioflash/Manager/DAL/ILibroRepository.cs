using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DAL
{
    public interface ILibroRepository : IRepository<Libro>
    {
        public Libro buscarISBN(Int64 pLibroISBN);
        public Libro buscarTitulo(string pLibroTitulo);
        public List<Libro> listaLibros();
    }
}
