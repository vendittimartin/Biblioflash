using Biblioflash;
using Biblioflash.Manager.Log;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class Form2 : Form
    {
        Log oLog = new Log($@"{Directory.GetCurrentDirectory()}\Log");
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
            try
            {
                if (password == password2)
                {
                    if (new EmailAddressAttribute().IsValid(email))
                    {
                        if (fachada.BuscarUsuario(user) == null)
                        {
                            fachada.RegistrarUsuario(user, password, email);
                            var inicio = new Form1();
                            MessageBox.Show("Se registró al usuario correctamente.");
                            inicio.Show();
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
            catch (Exception ex)
            {
                oLog.Add($"Se lanzo una excepción no controlada: {ex}");
                throw new Exception("Ha ocurrido un error en el registro. Intentelo nuevamente");
            }
        }
    }
}
