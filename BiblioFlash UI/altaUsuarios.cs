using Biblioflash;
using Biblioflash.Manager.Log;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class altaUsuarios : Form
    {
        Fachada fachada = new Fachada();
        Log oLog = new Log($@"{Directory.GetCurrentDirectory()}\Log");
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
            try
            {
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
                            if (fachada.BuscarUsuario(user) == null)
                            {
                                fachada.RegistrarUsuario(user, password, email);
                                var usuarios = new Usuarios();
                                usuarios.Show();
                                this.Close();
                            }
                            else
                            {
                                throw new Exception($"El nombre de usuario {user} ya se encuentra registrado.");
                            }
                        }
                        else
                        {
                            throw new Exception("El Email no posee un formato válido. Intentelo nuevamente");
                        }
                    }
                    else
                    {
                        throw new Exception("Las contraseñas no coinciden. Intentelo nuevamente");
                    }
                }
            }
            catch (Exception ex)
            {
                oLog.Add($"Se lanzó una excepción no controlada: {ex}");
                throw new Exception($"Se lanzó una excepción no controlada: {ex}");
            }
        }
    }
}
