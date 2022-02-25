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
    public partial class modificarDatos : Form
    {
        Fachada fachada = new Fachada();
        public modificarDatos(string pNombreUsuario)
        {
            UsuarioDTO user = fachada.buscarUsuario(pNombreUsuario);
            InitializeComponent(user);

        }
        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void confirmar_Click(object sender, EventArgs e)
        {
            string user = textUsuario.Text;
            string password = textContraseña.Text;
            string email = textMail.Text;
            int score = int.Parse(textScore.Text);
            if (password != "" || email != "")
            {
                    if (new EmailAddressAttribute().IsValid(email))
                    {
                        fachada.modificarUsuario(user, password, email, score, Biblioflash.Manager.Domain.Rango.Cliente);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El Email no posee un formato válido. Intentelo nuevamente");
                    }
            }
            else
            {
                MessageBox.Show("Complete todos los campos por favor.");
            }
        }
    }
}
