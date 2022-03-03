using System;
using System.Windows.Forms;
using Biblioflash.Manager.DTO;
using Biblioflash;

namespace BiblioFlash_UI
{
    public partial class Form3 : Form
    {
        Fachada fachada = new Fachada();
        public Form3(UsuarioDTO pUsuario)
        {
            InitializeComponent(pUsuario.NombreUsuario, pUsuario.Score);    
        }
     
        public void modificarUsuario(object sender, EventArgs e)
        {
            string pUsername = Convert.ToString(nombreUsuario.Text);
            this.Hide();
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
            string pUsername = Convert.ToString(nombreUsuario.Text);
            this.Hide();
            var libros = new PrestamosCliente(pUsername);
            libros.ShowDialog();
        }
        public void mostrarLibros(object sender, EventArgs e)
        {
            var libros = new librosDisponibles();
            libros.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
