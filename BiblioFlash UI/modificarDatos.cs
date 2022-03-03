using System;
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
            UsuarioDTO user = fachada.buscarUsuario(textUsuario.Text);
            var cliente = new Form3(user);
            cliente.Show();
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
                        UsuarioDTO usuario = fachada.buscarUsuario(user);
                        var cliente = new Form3(usuario);
                        cliente.Show();
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
