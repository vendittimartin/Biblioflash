using Biblioflash;
using Biblioflash.Manager.Log;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Biblioflash.Manager.DTO;

namespace BiblioFlash_UI
{
    public partial class registrarPrestamo : Form
    {
        Log oLog = new Log($@"{Directory.GetCurrentDirectory()}\Log");
        Fachada fachada = new Fachada();
        public registrarPrestamo()
        {
            InitializeComponent();
        }
        private void aceptar_Click(object sender, EventArgs e)
        {

            string usuario = Convert.ToString(textBox1.Text);
            string ejemplar = Convert.ToString(textBox2.Text);
            try
            {
                if (usuario == "" || ejemplar == "")
                {
                    MessageBox.Show("Complete todos los campos por favor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!Regex.IsMatch(ejemplar, @"^[0-9]+$"))
                    {
                        MessageBox.Show("El ID ejemplar debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (fachada.BuscarUsuario(usuario) != null)
                        {
                            int ejemplar2 = Convert.ToInt32(textBox2.Text);
                            if (ejemplar2 >= 0)
                            {
                                EjemplarDTO ejem = fachada.BuscarEjemplarDisponible(ejemplar2);
                                if (ejem != null)
                                {
                                    if (fachada.BuscarPrestamoEjemplar(ejem.ID))
                                    {
                                        fachada.RegistrarPrestamo(usuario, ejemplar2);
                                        MessageBox.Show("Prestamo registrado exitosamente.");
                                        this.Hide();
                                        var prestamos = new PantallaPrestamos();
                                        prestamos.Show();
                                    }
                                    else
                                    {
                                        throw new Exception("El ejemplar no se encuentra disponible.");
                                    }
                                }
                                else
                                {
                                    throw new Exception("El ejemplar no se encuentra.");
                                }
                            }
                            else
                            {
                                throw new Exception("El ID debe ser mayor o igual a 0.");
                            }
                        }
                        else
                        {
                            throw new Exception("Usuario no encontrado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLog.Add($"Se lanzo una excepción no controlada: {ex}");
                throw new Exception("Error al registrar el prestamo. Intentelo nuevamente.");
            }
        }
        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            var prestamos = new PantallaPrestamos();
            prestamos.Show();
        }
        private void listaEjemplares_Click(object sender, EventArgs e)
        {
            var listaEjemplares = new seleccionarLibro();
            listaEjemplares.Show();
        }
        private void listaUsuarios_Click(object sender, EventArgs e)
        {
            var listaUsuarios = new listUsuarios();
            listaUsuarios.Show();
        }
    }
}
