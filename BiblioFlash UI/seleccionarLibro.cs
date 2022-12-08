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
            List<LibroDTO> listLibros = fachada.ConsultaLibrosDisponibles();
            foreach (var obj in listLibros)
            {
                if (obj.Ejemplares.Count != 0)
                {
                    listaLibros.Rows.Add(obj.Titulo, obj.Autor, obj.ISBN);
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
            List<EjemplarDTO> listaEjemplares = fachada.ListaEjemplaresDisponibles(libro.Titulo);
            var listEjemplares = new listaEjemplares(listaEjemplares);
            listEjemplares.Show();
            this.Close();
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            listaLibros.Rows.Clear();
            List<LibroDTO> listLibros = fachada.ConsultaLibrosDisponibles();
            foreach (var obj in listLibros)
            {
                if (obj.Ejemplares.Count != 0)
                {
                    listaLibros.Rows.Add(obj.Titulo, obj.Autor, obj.ISBN, obj.Ejemplares.Count);
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
                    if (libro.Ejemplares.Count != 0)
                    {
                        listaLibros.Rows.Add(libro.Titulo, libro.Autor, libro.ISBN, libro.Ejemplares.Count);
                    }
                }
            }
        }
    }
}
