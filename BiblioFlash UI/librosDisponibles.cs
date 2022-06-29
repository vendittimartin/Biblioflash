using Biblioflash;
using Biblioflash.Manager.Domain;
using Biblioflash.Manager.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            List<LibroDTO> libros = fachada.BuscarLibroSimilitud(titulo);
            foreach (var libro in libros)
            {
                listaLibros.Rows.Add(libro.Titulo, libro.Autor, libro.ISBN);
            }
        }
        private void starterRows()
        {
            listaLibros.Rows.Clear();
            List<LibroDTO> listLibros = fachada.ConsultaLibrosDisponibles();
            foreach (var obj in listLibros)
            {
                listaLibros.Rows.Add(obj.Titulo, obj.Autor, obj.ISBN);
            }
        }
    }
}
