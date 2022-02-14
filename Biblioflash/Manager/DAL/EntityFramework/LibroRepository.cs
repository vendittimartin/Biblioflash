using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;
using Biblioflash.Manager.DAL.EntityFramework;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class LibroRepository : Repository<Libro, AccountManagerDbContext>, ILibroRepository
    {
        private readonly DbContext iDbContext;

        public LibroRepository(AccountManagerDbContext pContext) : base(pContext)
        {
            iDbContext = pContext;
        }

        public Libro buscarISBN(Int64 pLibroISBN)
        {
            return this.iDbContext.Set<Libro>().FirstOrDefault(libro => libro.Isbn == pLibroISBN);
        }
        public Libro buscarTitulo(string pLibroTitulo)
        {
            return this.iDbContext.Set<Libro>().FirstOrDefault(libro => libro.Titulo == pLibroTitulo);
        }
        public List<Libro> listaLibros()
        {
            var queryHighScores =
                from libro in iDbContext.Set<Libro>()
                select new { libro.Isbn, libro.Titulo, libro.Autor, libro.Ejemplares};

            List<Libro> listLibros = new List<Libro>();
            foreach (var obj in queryHighScores)
            {
                Libro libro = new Libro
                {
                    Isbn = obj.Isbn,
                    Autor = obj.Autor,
                    Titulo = obj.Titulo,
                    Ejemplares = obj.Ejemplares
                };
                listLibros.Add(libro);
            }
            return listLibros;
        }
    }
}
