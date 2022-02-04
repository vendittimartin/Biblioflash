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

namespace BiblioFlash_UI
{
    public partial class Form1 : Form
    {
        Fachada fachada = new Fachada();
        public Form1()
        {
            InitializeComponent();
        }
        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void registro_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registro = new Form2();
            registro.Show();
        }
        private void iniciar_Click(object sender, EventArgs e)
        {
            string user = textUsuario.Text;
            string password = textContraseña.Text;
            if (fachada.iniciarSesion(user,password))
            {
                MessageBox.Show("Ta to gucci");
            }
            else 
            {
                MessageBox.Show("guccin't");
            }
        }
    }
}
