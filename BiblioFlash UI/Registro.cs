using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace BiblioFlash_UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void volver_Click(object sender, EventArgs e)
        {
            var inicio = new Form1();
            inicio.Show();
            this.Close();
        }
        private void confirmar_Click(object sender, EventArgs e)
        {
            string valor = validarRegistro();
            if (valor == "true")
            {
                var inicio = new Form1();
                inicio.Show();
                this.Close();
            }
            else
            {
                if (valor == "pwDistintas")
                {
                    MessageBox.Show("contraseñas distintas");
                }
                else
                {
                    MessageBox.Show("formato de mail no valido");
                }
            }

        }
        private void iniciar_Click(object sender, EventArgs e)
        {
        }

        private string validarRegistro()
        {
            string user = textUsuario.Text;
            string password = textContraseña.Text;
            string password2 = textContraseña2.Text;
            string email = textMail.Text;
            if (password == password2)
            {
                if (new EmailAddressAttribute().IsValid(email))
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "pwDistintas";
            }
        }
    }
}
