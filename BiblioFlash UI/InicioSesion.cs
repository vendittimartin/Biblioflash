using System;
using System.Windows.Forms;
using Biblioflash;
using Biblioflash.Manager.DTO;
using Biblioflash.Manager.Domain;

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
            if (password != "" || user != "")
            {
                UsuarioDTO usuario = fachada.buscarUsuario(user);
                if (usuario != null)
                {
                    if (usuario.Contraseña == password)
                    {
                        if (usuario.RangoUsuario == Rango.Admin)
                        {
                            this.Hide();
                            var admin = new PantallaAdmin();
                            admin.Show();
                        }
                        else
                        {
                            this.Hide();
                            var cliente = new Form3(usuario);
                            cliente.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecta, intentelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Campos vacíos. Intentelo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
