using System;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class PantallaLibros : Form
    {
        public PantallaLibros()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var libros = new Libros();
            libros.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var ejemplares = new altaEjemplares();
            ejemplares.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var volver = new PantallaAdmin();
            volver.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var volver = new librosDisponibles();
            volver.ShowDialog();
        }
    }
}
