using System;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class PantallaAdmin : Form
    {
        public PantallaAdmin()
        {
            InitializeComponent();
        }

        public void cerrarSesion(object sender, EventArgs e)
        {
            this.Hide();
            var inicio = new Form1();
            inicio.Show();
        }
        public void usuarios(object sender, EventArgs e)
        {
            this.Hide();
            var users = new Usuarios();
            users.ShowDialog();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var libros = new PantallaLibros();
            libros.ShowDialog();
        }
        private void prestamos_Click(object sender, EventArgs e)
        {
            this.Hide();
            var prestamos = new PantallaPrestamos();
            prestamos.ShowDialog();
        }
    }
}
