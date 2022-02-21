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
    public partial class seleccionarLibro : Form
    {
        Fachada fachada = new Fachada();
        public seleccionarLibro()
        {
            InitializeComponent(); listaLibros.Rows.Clear();
            List<Libro> listLibros = fachada.consultaLibrosDisponibles();
            foreach (var obj in listLibros)
            {
                int cant = fachada.cantEjemplaresDisponibles(obj.Titulo);
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
            LibroDTO libro = fachada.buscarLibro(libroDTO.Titulo);
            List<Ejemplar> listaEjemplares = fachada.listaEjemplaresDisponibles(libro);
            var listEjemplares = new listaEjemplares(listaEjemplares);
            listEjemplares.Show();
            this.Close();
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            listaLibros.Rows.Clear();
            List<Libro> listLibros = fachada.consultaLibrosDisponibles();
            foreach (var obj in listLibros)
            {
                int cant = fachada.cantEjemplaresDisponibles(obj.Titulo);
                if (cant != 0)
                { 
                listaLibros.Rows.Add(obj.Titulo, obj.Autor, obj.Isbn, cant);
                }
            }
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string titulo = textBoxTituloLibro.Text;
            if (titulo != "")
            {
                listaLibros.Rows.Clear();
                LibroDTO libro = fachada.buscarLibro(titulo);
                if (libro != null)
                {
                    int cant = fachada.cantEjemplaresDisponibles(titulo);
                    if (cant != 0)
                    { 
                        listaLibros.Rows.Add(libro.Titulo, libro.Autor, libro.ISBN, cant);
                    }
                }
                else
                {
                    MessageBox.Show("Libro no encontrado.");
                }
            }
        }
    }
}
