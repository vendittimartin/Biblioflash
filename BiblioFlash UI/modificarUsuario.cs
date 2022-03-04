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
using Biblioflash.Manager.DTO;

namespace BiblioFlash_UI
{
    public partial class modificarUsuario : Form
    {
        Fachada fachada = new Fachada();
        public modificarUsuario(string pNombreUsuario)
        {
            UsuarioDTO user = fachada.buscarUsuario(pNombreUsuario);
            InitializeComponent(user);
            
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
            string password2 = textScore.Text;
            string email = textMail.Text;
            int score = int.Parse(textScore.Text);

            if (user == "" || password == "" || password2 == "" || email == "" || score == -1)
            {
                MessageBox.Show("Complete todos los campos por favor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (comboBox1.SelectedItem != null)
                {
                    if (new EmailAddressAttribute().IsValid(email))
                    {
                        if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Admin")
                        {
                            Biblioflash.Manager.Domain.Rango rango2 = Biblioflash.Manager.Domain.Rango.Admin;
                            fachada.modificarUsuario(user, password, email, score, rango2);
                            var usuarios = new Usuarios();
                            usuarios.Show();
                            this.Close();
                        }
                        else
                        {
                            Biblioflash.Manager.Domain.Rango rango2 = Biblioflash.Manager.Domain.Rango.Cliente;
                            fachada.modificarUsuario(user, password, email, score, rango2);
                            var usuarios = new Usuarios();
                            usuarios.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Email no posee un formato válido. Intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un rango.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
