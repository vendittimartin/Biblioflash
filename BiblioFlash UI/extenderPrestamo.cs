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

namespace BiblioFlash_UI
{
    public partial class extenderPrestamo : Form
    {
        Fachada fachada = new Fachada();
        public extenderPrestamo()
        {
            InitializeComponent();
            List<PrestamoDTO> listaPrestamos = new List<PrestamoDTO>();
            dataGridView1.Rows.Clear();
            listaPrestamos = fachada.listaPrestamos();
            foreach (var obj in listaPrestamos)
            {
                dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion);
            }
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<PrestamoDTO> listaPrestamos = fachada.listaPrestamos();
            foreach (var obj in listaPrestamos)
            {
                dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion);
            }
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text;
            if (busqueda != "")
            {
                    dataGridView1.Rows.Clear();
                    List<PrestamoDTO> listaPrestamos = fachada.prestamosPorUsuario(busqueda);
                    if (listaPrestamos != null)
                    {
                        foreach (var obj in listaPrestamos)
                        {
                            dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario no posee prestamos.");
                    }
            }
            else
            {
                MessageBox.Show("Complete todos los campos.");
            }
        }
        private void extender_Click(object sender, EventArgs e)
        {
            int cant = Convert.ToInt32(numericUpDown1.Value);
            if (cant > 0 && cant < 16)
            {
                DataGridViewSelectedRowCollection fila = dataGridView1.SelectedRows;
                DataGridViewCellCollection columnas = fila[0].Cells;
                PrestamoDTO prestamo = fachada.prestamosPorID(Int64.Parse(columnas[0].Value.ToString()));
                bool extendio = fachada.extenderPrestamo(prestamo,cant);
                if (extendio)
                {
                    MessageBox.Show("La fecha de devolución se extendió correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El usuario no posee el score suficiente.");
                }
            }
            else
            {
                MessageBox.Show("No se puede extender dicha cantidad de días (1-15).");
            }
        }
    }
}
