using Biblioflash;
using Biblioflash.Manager.Domain;
using Biblioflash.Manager.DTO;
using Biblioflash.Manager.Log;
using System;
using System.IO;
using System.Windows.Forms;
using Biblioflash.Manager.Services;

namespace BiblioFlash_UI
{
    public partial class Form1 : Form
    {
        Log oLog = new Log($@"{Directory.GetCurrentDirectory()}\Log");
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
            try
            {
                if (user == "" || password == "")
                {
                    MessageBox.Show("Por favor complete todos los campos.");
                }
                else
                { 
                    var usuario = fachada.IniciarSesion(password, user);
                    if (usuario != null) 
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
                        MessageBox.Show("Usuario o contraseña incorrecta.");
                    }
                }
            }
            catch (Exception ex)
            {
                oLog.Add($"Se lanzo una excepción no controlada: {ex}");
                throw new Exception("Error al iniciar sesión. Intentelo nuevamente.");
            }
        }
    }
}
