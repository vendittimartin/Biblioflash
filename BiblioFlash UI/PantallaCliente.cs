using System;
using System.Windows.Forms;
using Biblioflash.Manager.DTO;

namespace BiblioFlash_UI
{
    public partial class Form3 : Form
    {
        public Form3(UsuarioDTO pUsuario)
        {
            InitializeComponent(pUsuario.NombreUsuario);
        }
        public void modificarUsuario(object sender, EventArgs e)
        {
            string pUsername = Convert.ToString(label1.Text);
            var datosuser = new modificarDatos(pUsername);
            datosuser.ShowDialog();
        }
        public void cerrarSesion(object sender, EventArgs e)
        {
            this.Hide();
            var inicio = new Form1();
            inicio.Show();
        }
        public void PrestamosCliente(object sender, EventArgs e)
        {
            string pUsername = Convert.ToString(label1.Text);
            var libros = new PrestamosCliente(pUsername);
            libros.ShowDialog();
        }
        public void mostrarLibros(object sender, EventArgs e)
        {
            var libros = new librosDisponibles();
            libros.ShowDialog();
        }
    }
}
