using Biblioflash.Manager.Domain;
using System;
using System.Collections.Generic;

namespace Biblioflash.Manager.DAL
{
    public interface ILibroRepository : IRepository<Libro>
    {
        public Libro BuscarISBN(Int64 pLibroISBN);
        public Libro BuscarTitulo(string pLibroTitulo);
        public List<Libro> ListaLibros();
        public List<Libro> BuscarLibroSimilitud(string pLibroTitulo);
    }
}
