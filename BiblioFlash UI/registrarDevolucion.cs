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
    public partial class registrarDevolucion : Form
    {
        Fachada fachada = new Fachada();
        public registrarDevolucion()
        {
            InitializeComponent();
            List<PrestamoDTO> listaPrestamos = new List<PrestamoDTO>();
            dataGridView1.Rows.Clear();
            listaPrestamos = fachada.listaPrestamos();
            foreach (var obj in listaPrestamos)
            {
                if (obj.FechaRealDevolucion == null)
                { 
                    dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion);
                }
            }
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<PrestamoDTO> listaPrestamos = fachada.listaPrestamos();
            foreach (var obj in listaPrestamos)
            {
                if (obj.FechaRealDevolucion == null)
                {
                    dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion);
                }
            }
        }
        private void devolver_Click(object sender, EventArgs e)
        {
            string estado = Convert.ToString(comboBox1.Text);
            DataGridViewSelectedRowCollection fila = dataGridView1.SelectedRows;
            DataGridViewCellCollection columnas = fila[0].Cells;
            PrestamoDTO prestamo = fachada.prestamosPorID(Int64.Parse(columnas[0].Value.ToString()));
            fachada.registrarDevolucion(prestamo.ID,estado);
            MessageBox.Show("Devolución realizada correctamente.");
            this.Close();
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text;
            if (busqueda != "")
            {
                dataGridView1.Rows.Clear();
                List<UsuarioDTO> user = fachada.buscarUsuarioSimilitud(busqueda);
                foreach (var usuario in user) 
                { 
                List<PrestamoDTO> listaPrestamos = fachada.prestamosPorUsuarioX(usuario.NombreUsuario);
                    foreach (var obj in listaPrestamos)
                    {
                        if (obj.FechaRealDevolucion == null)
                        {
                            dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion);
                        }    
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos.");
            }
        }

    }
}
