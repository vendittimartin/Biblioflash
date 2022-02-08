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
    public partial class PantallaLibros : Form
    {
        public PantallaLibros()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var libros = new Libros();
            libros.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var volver = new PantallaAdmin();
            volver.Show();
        }
    }
}
