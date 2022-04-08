using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Biblioflash;
using Biblioflash.Manager.DTO;
using System.Text.RegularExpressions;
using Biblioflash.Manager.Log;
using System.IO;

namespace BiblioFlash_UI
{
    public partial class Prestamos : Form
    {
        Log oLog = new Log($@"{Directory.GetCurrentDirectory()}\Log");
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
            try
            {
                if (busqueda != "" && comboBox1.SelectedItem != null)
                {
                    if (Convert.ToString(comboBox1.SelectedItem) == "Usuario")
                    {
                        dataGridView1.Rows.Clear();
                        List<UsuarioDTO> users = fachada.buscarUsuarioSimilitud(busqueda);
                        foreach (var usuario in users)
                        {
                            List<PrestamoDTO> listaPrestamos = fachada.prestamosPorUsuarioX(usuario.NombreUsuario);
                            if (listaPrestamos != null)
                            {
                                foreach (var obj in listaPrestamos)
                                {
                                    dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion, obj.FechaRealDevolucion);
                                }
                                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                            }
                        }
                    }
                    else
                    {
                        if (!Regex.IsMatch(busqueda, @"^[0-9]+$"))
                        {
                            MessageBox.Show("Debe ingresar un número para buscar por ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                MessageBox.Show("El ejemplar no posee prestamos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                oLog.Add($"Se lanzo una excepción no controlada: {ex}");
                throw new Exception("Error al realizar el prestamo. Intentelo nuevamente.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
