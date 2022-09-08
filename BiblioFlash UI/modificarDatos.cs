using Biblioflash;
using Biblioflash.Manager.DTO;
using Biblioflash.Manager.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class modificarDatos : Form
    {
        Fachada fachada = new Fachada();
        public modificarDatos(string pNombreUsuario)
        {
            UsuarioDTO user = fachada.BuscarUsuario(pNombreUsuario);
            InitializeComponent(user);

        }
        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            UsuarioDTO user = fachada.BuscarUsuario(textUsuario.Text);
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
                    fachada.ModificarUsuario(user, password, email, score, Biblioflash.Manager.Domain.Rango.Cliente);
                    this.Close();
                    UsuarioDTO usuario = fachada.BuscarUsuario(user);
                    var cliente = new Form3(usuario);
                    cliente.Show();
                }
                else
                {
                    MessageBox.Show("El Email no posee un formato válido. Intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos por favor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
