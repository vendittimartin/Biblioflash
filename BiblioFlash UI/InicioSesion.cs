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
    public partial class Form1 : Form
    {
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
            bool valor = verficarUsuario();
            if (valor == true)
            { 
            this.Close();
                //var form2 = new Form2();
                // Form2.Show();
                //Crear la pantalla inicio
            }
        }

        private bool verficarUsuario()
        {
            string user = textUsuario.Text;
            string password = textContraseña.Text;
            if ("admin" == user)
            {
                if ("admin" == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
