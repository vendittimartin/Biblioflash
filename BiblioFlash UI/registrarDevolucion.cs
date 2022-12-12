using Biblioflash;
using Biblioflash.Manager.DTO;
using Biblioflash.Manager.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class registrarDevolucion : Form
    {
        Log oLog = new Log($@"{Directory.GetCurrentDirectory()}\Log");
        Fachada fachada = new Fachada();
        public registrarDevolucion()
        {
            InitializeComponent();
            List<PrestamoDTO> listaPrestamos = new List<PrestamoDTO>();
            dataGridView1.Rows.Clear();
            listaPrestamos = fachada.ListaPrestamosNoDevueltos();
            foreach (var obj in listaPrestamos)
            {
                dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion);
            }
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<PrestamoDTO> listaPrestamos = fachada.ListaPrestamosNoDevueltos();
            foreach (var obj in listaPrestamos)
            {
                dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion);
            }
        }
        private void devolver_Click(object sender, EventArgs e)
        {
            try
            {
                string estado = Convert.ToString(comboBox1.Text);
                if (estado == "")
                {
                    MessageBox.Show("Debe ingresar el estado del libro.");
                }
                else
                {
                    DataGridViewSelectedRowCollection fila = dataGridView1.SelectedRows;
                    DataGridViewCellCollection columnas = fila[0].Cells;
                    PrestamoDTO prestamo = fachada.PrestamosPorID(Int64.Parse(columnas[0].Value.ToString()));
                    fachada.RegistrarDevolucion(prestamo.ID, estado);
                    MessageBox.Show("Devolución realizada correctamente.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                oLog.Add($"Se lanzo una excepción no controlada: {ex}");
                throw new Exception("Error al devolver el libro");
            }
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text;
            if (busqueda != "")
            {
                dataGridView1.Rows.Clear();
                List<UsuarioDTO> user = fachada.BuscarUsuarioSimilitud(busqueda);
                foreach (var usuario in user)
                {
                    List<PrestamoDTO> listaPrestamos = fachada.PrestamosPorUsuarioX(usuario.NombreUsuario);
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
                MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
