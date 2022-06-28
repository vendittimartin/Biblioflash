using Biblioflash;
using Biblioflash.Manager.Domain;
using Biblioflash.Manager.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class seleccionarLibro : Form
    {
        Fachada fachada = new Fachada();
        public seleccionarLibro()
        {
            InitializeComponent(); listaLibros.Rows.Clear();
            List<Libro> listLibros = fachada.ConsultaLibrosDisponibles();
            foreach (var obj in listLibros)
            {
                int cant = fachada.CantEjemplaresDisponibles(obj.Titulo);
                if (cant != 0)
                {
                    listaLibros.Rows.Add(obj.Titulo, obj.Autor, obj.Isbn, cant);
                }
            }
        }
        private void seleccionar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection fila = listaLibros.SelectedRows;
            DataGridViewCellCollection columnas = fila[0].Cells;
            LibroDTO libroDTO = new LibroDTO
            {
                Titulo = columnas[0].Value.ToString(),
                Autor = columnas[1].Value.ToString(),
                ISBN = Int64.Parse(columnas[2].Value.ToString())
            };
            LibroDTO libro = fachada.BuscarLibro(libroDTO.Titulo);
            List<Ejemplar> listaEjemplares = fachada.ListaEjemplaresDisponibles(libro);
            var listEjemplares = new listaEjemplares(listaEjemplares);
            listEjemplares.Show();
            this.Close();
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            listaLibros.Rows.Clear();
            List<Libro> listLibros = fachada.ConsultaLibrosDisponibles();
            foreach (var obj in listLibros)
            {
                int cant = fachada.CantEjemplaresDisponibles(obj.Titulo);
                if (cant != 0)
                {
                    listaLibros.Rows.Add(obj.Titulo, obj.Autor, obj.Isbn, cant);
                }
            }
        }
        private void botonCerrar(object sender, EventArgs e)
        {
            this.Close();
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string titulo = textBoxTituloLibro.Text;
            if (titulo != "")
            {
                listaLibros.Rows.Clear();
                List<LibroDTO> libros = fachada.BuscarLibroSimilitud(titulo);
                foreach (var libro in libros)
                {
                    int cant = fachada.CantEjemplaresDisponibles(libro.Titulo);
                    if (cant != 0)
                    {
                        listaLibros.Rows.Add(libro.Titulo, libro.Autor, libro.ISBN, cant);
                    }
                }
            }
        }
    }
}
