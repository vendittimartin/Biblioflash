using System;
using System.Windows.Forms;
using Biblioflash;
using System.ComponentModel.DataAnnotations;
using Biblioflash.Manager.DTO;
using Biblioflash.Manager.Log;
using System.IO;

namespace BiblioFlash_UI
{
    public partial class modificarUsuario : Form
    {
        Log oLog = new Log($@"{Directory.GetCurrentDirectory()}\Log");
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
            try
            {
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
                            throw new Exception("El Email no posee un formato válido. Intentelo nuevamente");
                        }
                    }
                    else
                    {
                        throw new Exception("Debe seleccionar un rango.");
                    }
                }
            }
            catch (Exception ex)
            {
                oLog.Add($"Se lanzo una excepción no controlada: {ex}");
                throw new Exception("Error al modificar un usuario. Intentelo nuevamente.");
            }
        }
    }
}
