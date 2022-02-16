using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            prestamos.Show();
        }
        public void registrarPrestamo_Click(object sender, EventArgs e)
        {
            var prestamos = new registrarPrestamo();
            prestamos.Show();
        }
        public void extenderPrestamo_Click(object sender, EventArgs e)
        {
            var prestamos = new extenderPrestamo();
            prestamos.Show();
        }
        public void registrarDevolucion_Click(object sender, EventArgs e)
        {
            var prestamos = new registrarDevolucion();
            prestamos.Show();
        }
    }
}
