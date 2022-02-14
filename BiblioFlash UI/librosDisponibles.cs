using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            InitializeComponent(); listaLibros.Rows.Clear();
            List<Libro> listLibros = fachada.consultaLibrosDisponibles();
            foreach (var obj in listLibros)
            {
                listaLibros.Rows.Add(obj.Titulo, obj.Autor, obj.Isbn);
            }
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string titulo = textBoxTituloLibro.Text;
            if (titulo != "")
            {
                listaLibros.Rows.Clear();
                LibroDTO libro = fachada.buscarLibro(titulo);
                listaLibros.Rows.Add(libro.Titulo, libro.Autor, libro.ISBN);
            }
        }
    }
}
