using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class LibroRepository : Repository<Libro, AccountManagerDbContext>, ILibroRepository
    {
        private readonly DbContext iDbContext;

        public LibroRepository(AccountManagerDbContext pContext) : base(pContext)
        {
            iDbContext = pContext;
        }

        public Libro BuscarISBN(Int64 pLibroISBN)
        {
            return this.iDbContext.Set<Libro>().FirstOrDefault(libro => libro.Isbn == pLibroISBN);
        }
        public Libro BuscarTitulo(string pLibroTitulo)
        {
            return this.iDbContext.Set<Libro>().FirstOrDefault(libro => libro.Titulo == pLibroTitulo);
        }
        public List<Libro> ListaLibros()
        {
            var queryHighScores =
                from libro in iDbContext.Set<Libro>()
                select new { libro.Isbn, libro.Titulo, libro.Autor, libro.Ejemplares };

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

        public List<Libro> BuscarLibroSimilitud(string pTitulo) {
            var queryHighScores =
                from libro in iDbContext.Set<Libro>()
                where libro.Titulo.ToUpper().Contains(pTitulo.ToUpper())
                select new { libro.Isbn, libro.Titulo, libro.Autor, libro.Ejemplares };

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
