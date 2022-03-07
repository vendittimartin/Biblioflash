using System;
using System.Windows.Forms;
using Biblioflash;
using System.Text.RegularExpressions;
using Biblioflash.Manager.Domain;

namespace BiblioFlash_UI
{
    public partial class registrarPrestamo : Form
    {
        Fachada fachada = new Fachada();
        public registrarPrestamo()
        {
            InitializeComponent();
        }
        private void aceptar_Click(object sender, EventArgs e)
        {
            
            string usuario = Convert.ToString(textBox1.Text);
            string ejemplar = Convert.ToString(textBox2.Text);
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
                    if (fachada.buscarUsuario(usuario) != null)
                    {
                        int ejemplar2 = Convert.ToInt32(textBox2.Text);
                        if (ejemplar2 >= 0)
                        {
                            Ejemplar ejem = fachada.buscarEjemplarDisponible(ejemplar2);
                            if (ejem != null)
                            {
                                if (fachada.buscarPrestamoEjemplar(ejem))
                                {
                                    fachada.registrarPrestamo(usuario, ejemplar2);
                                    MessageBox.Show("Prestamo registrado exitosamente.");
                                    this.Hide();
                                    var prestamos = new PantallaPrestamos();
                                    prestamos.Show();
                                }
                                else
                                {
                                    MessageBox.Show("El ejemplar no se encuentra disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El ejemplar no se encuentra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El ID debe ser mayor o igual a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado.","Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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

        private void registrarPrestamo_Load(object sender, EventArgs e)
        {

        }
    }
}
