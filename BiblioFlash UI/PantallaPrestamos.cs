using System;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class PantallaPrestamos : Form
    {
        public PantallaPrestamos()
        {
            InitializeComponent();
        }
        public void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            var admin = new PantallaAdmin();
            admin.Show();
        }
        public void listaPrestamos_Click(object sender, EventArgs e)
        {
            var prestamos = new Prestamos();
            prestamos.ShowDialog();
        }
        public void registrarPrestamo_Click(object sender, EventArgs e)
        {
            this.Hide();
            var prestamos = new registrarPrestamo();
            prestamos.ShowDialog();
        }
        public void extenderPrestamo_Click(object sender, EventArgs e)
        {
            var prestamos = new extenderPrestamo();
            prestamos.ShowDialog();
        }
        public void registrarDevolucion_Click(object sender, EventArgs e)
        {
            var prestamos = new registrarDevolucion();
            prestamos.ShowDialog();
        }
    }
}
