using Biblioflash;
using Biblioflash.Manager.DTO;
using Biblioflash.Manager.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class extenderPrestamo : Form
    {
        Log oLog = new Log($@"{Directory.GetCurrentDirectory()}\Log");
        Fachada fachada = new Fachada();
        public extenderPrestamo()
        {
            InitializeComponent();
            List<PrestamoDTO> listaPrestamos = new List<PrestamoDTO>();
            dataGridView1.Rows.Clear();
            listaPrestamos = fachada.ListaPrestamos();
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
            List<PrestamoDTO> listaPrestamos = fachada.ListaPrestamos();
            foreach (var obj in listaPrestamos)
            {
                if (obj.FechaRealDevolucion == null)
                {
                    dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion);
                }
            }
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text;
            if (busqueda != "")
            {
                dataGridView1.Rows.Clear();
                List<UsuarioDTO> users = fachada.BuscarUsuarioSimilitud(busqueda);
                foreach (var usuario in users)
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
                MessageBox.Show("Complete todos los campos por favor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void extender_Click(object sender, EventArgs e)
        {
            int cant = Convert.ToInt32(numericUpDown1.Value);
            try
            {
                if (cant > 0 && cant < 16)
                {
                    DataGridViewSelectedRowCollection fila = dataGridView1.SelectedRows;
                    DataGridViewCellCollection columnas = fila[0].Cells;
                    PrestamoDTO prestamo = fachada.PrestamosPorID(Int64.Parse(columnas[0].Value.ToString()));
                    bool extendio = fachada.ExtenderPrestamo(prestamo.ID, prestamo.Usuario.NombreUsuario, cant);
                    if (extendio)
                    {
                        MessageBox.Show("La fecha de devolución se extendió correctamente", "Devolución", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El usuario no posee el score suficiente para extender el prestamo.");
                    }
                }
                else
                {
                    MessageBox.Show("No se puede extender dicha cantidad de días (1-15).");
                }
            }
            catch (Exception ex)
            {
                oLog.Add($"Se lanzo una excepción no controlada: {ex}");
                throw new Exception("Se produjo un error al extender el prestamo. Intentelo nuevamente.");
            }
        }
    }
}
