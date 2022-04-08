using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioflash;
using Biblioflash.Manager.DTO;
using Biblioflash.Manager.Domain;

namespace BiblioFlash_UI
{
    public partial class librosDisponibles : Form
    {
        Fachada fachada = new Fachada();
        public librosDisponibles()
        {
            InitializeComponent();
            starterRows();
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            starterRows();
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string titulo = textBoxTituloLibro.Text;
                listaLibros.Rows.Clear();
                List<LibroDTO> libros = fachada.buscarLibroSimilitud(titulo);
                foreach (var libro in libros)
                {
                    listaLibros.Rows.Add(libro.Titulo, libro.Autor, libro.ISBN);
                }
        }
        private void starterRows()
        {
            listaLibros.Rows.Clear();
            List<Libro> listLibros = fachada.consultaLibrosDisponibles();
            foreach (var obj in listLibros)
            {
                listaLibros.Rows.Add(obj.Titulo, obj.Autor, obj.Isbn);
            }
        }
    }
}
