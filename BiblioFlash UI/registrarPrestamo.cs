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
            int ejemplar = Convert.ToInt32(textBox2.Text);
            if (fachada.buscarUsuario(usuario) != null)
            {
                    if (usuario != "" && ejemplar >= 0)
                    {
                        fachada.registrarPrestamo(usuario, ejemplar);
                        MessageBox.Show("Prestamo registrado exitosamente.");
                        this.Hide();
                        var prestamos = new PantallaPrestamos();
                        prestamos.Show();
                }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos.");
                    }
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.");
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
