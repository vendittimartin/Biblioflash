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
using Microsoft.VisualBasic;

namespace BiblioFlash_UI
{
    public partial class Libros : Form
    {
        private Fachada fachada = new Fachada();
        public Libros()
        {
            InitializeComponent();
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxTituloLibro.Text != "")
            {

                listaLibros.Rows.Clear();
                List<LibroDTO> listaLibrosDTO = fachada.consultaLibro(textBoxTituloLibro.Text);
                foreach (var libroDTO in listaLibrosDTO)
                {
                    listaLibros.Rows.Add(libroDTO.Titulo, libroDTO.Autor, libroDTO.ISBN);
                }
                botonAgregarSeleccion.Enabled = true;
            }
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            listaLibros.Rows.Clear();
        }
        private void botonAgregarSeleccion_Click(object sender, EventArgs e)
        {
            //try
            //{
                DataGridViewSelectedRowCollection fila = listaLibros.SelectedRows;
                DataGridViewCellCollection columnas = fila[0].Cells;
                LibroDTO libroDTO = new LibroDTO
                {
                    Titulo = columnas[0].Value.ToString(),
                    Autor = columnas[1].Value.ToString(),
                    ISBN = Int64.Parse(columnas[2].Value.ToString())
                };
                fachada.agregarLibro(libroDTO);
                MessageBox.Show("Su libro se agrego con exito");

            //}
            /*catch (EFDatabaseUpdateException exc)
            {
                MessageBox.Show("Libro existente");
            }*/

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var admin = new PantallaAdmin();
            admin.Show();
        }
    }
}
