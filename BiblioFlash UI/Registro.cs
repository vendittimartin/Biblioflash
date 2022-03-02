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
using Biblioflash;


namespace BiblioFlash_UI
{
    public partial class Form2 : Form
    {
        Fachada fachada = new Fachada();
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
            string user = textUsuario.Text;
            string password = textContraseña.Text;
            string password2 = textContraseña2.Text;
            string email = textMail.Text;
            if (user == "" || password == "" || password2 == "" || email == "")
            {
                MessageBox.Show("Complete todos los campos por favor.");
            }
            else { 
                if (password == password2)
                {
                    if (new EmailAddressAttribute().IsValid(email))
                    {
                        fachada.registrarUsuario(user, password, email);
                        var inicio = new Form1();
                        MessageBox.Show("Se registró al usuario correctamente.");
                        inicio.Show();
                        this.Close();
                    }
                    else 
                    {
                        MessageBox.Show("El Email no posee un formato válido. Intentelo nuevamente");
                    }
                }
                else {
                    MessageBox.Show("Las contraseñas no coinciden. Intentelo nuevamente");
                }
            }
        }
    }
}
