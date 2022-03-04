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
using System.ComponentModel.DataAnnotations;

namespace BiblioFlash_UI
{
    public partial class altaUsuarios : Form
    {
        Fachada fachada = new Fachada();
        public altaUsuarios()
        {
            InitializeComponent();
        }
        private void volver_Click(object sender, EventArgs e)
        {
            var usuarios = new Usuarios();
            usuarios.Show();
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
                MessageBox.Show("Complete todos los campos por favor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (password == password2)
                {
                    if (new EmailAddressAttribute().IsValid(email))
                    {
                        if (fachada.buscarUsuario(user) == null)
                        {
                            fachada.registrarUsuario(user, password, email);
                            var usuarios = new Usuarios();
                            usuarios.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"El nombre de usuario {user} ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Email no posee un formato válido. Intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden. Intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
