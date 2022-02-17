using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioflash.Manager.DTO;

namespace BiblioFlash_UI
{
    public partial class Form3 : Form
    {
        public Form3(UsuarioDTO pUsuario)
        {
            UsuarioDTO user = pUsuario;
            InitializeComponent(user.NombreUsuario);
        }
        public void modificarUsuario(object sender, EventArgs e)
        {
            string pUsername = Convert.ToString(label1.Text);
            this.Hide();
            var datosuser = new modificarDatos(pUsername);
            datosuser.Show();
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
            libros.Show();
        }
        public void mostrarLibros(object sender, EventArgs e)
        {
            var libros = new librosDisponibles();
            libros.Show();
        }
    }
}
