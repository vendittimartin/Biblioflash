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
    public partial class Prestamos : Form
    {
        Fachada fachada = new Fachada();
        public Prestamos()
        {
            InitializeComponent();
            List<PrestamoDTO> listaPrestamos = new List<PrestamoDTO>();
            dataGridView1.Rows.Clear();
            listaPrestamos = fachada.listaPrestamos();
            foreach (var obj in listaPrestamos)
            {
                dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion,obj.FechaRealDevolucion);
            }
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<PrestamoDTO> listaPrestamos = fachada.listaPrestamos();
            foreach (var obj in listaPrestamos)
            {
                dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion,obj.FechaRealDevolucion);
            }
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text;
            if (busqueda != "" && comboBox1.SelectedItem != null)
            {
                if (Convert.ToString(comboBox1.SelectedItem) == "Usuario")
                {
                    dataGridView1.Rows.Clear();
                    List<PrestamoDTO> listaPrestamos = fachada.prestamosPorUsuarioX(busqueda);
                    if (listaPrestamos != null)
                    {
                        foreach (var obj in listaPrestamos)
                        {
                            dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion, obj.FechaRealDevolucion);
                        }
                        dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                    }
                    else
                    {
                        MessageBox.Show("El usuario no posee prestamos.");
                    }
                }
                else
                {
                    int busq = Convert.ToInt32(busqueda);
                    dataGridView1.Rows.Clear();
                    List<PrestamoDTO> listaPrestamos = fachada.prestamosPorEjemplar(busq);
                    if (listaPrestamos != null)
                    {
                        foreach (var obj in listaPrestamos)
                        {
                            dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion, obj.FechaRealDevolucion);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El ejemplar no posee prestamos.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
