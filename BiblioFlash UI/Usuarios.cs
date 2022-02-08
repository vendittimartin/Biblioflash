using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioflash.Manager.DTO;
using Biblioflash;

namespace BiblioFlash_UI
{
    public partial class Usuarios : Form
    {
        Fachada fachada = new Fachada();
        public Usuarios()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var admin = new PantallaAdmin();
            admin.Show();
        }
        private void altaUsuarios(object sender, EventArgs e)
        {
            this.Hide();
            var altausers = new altaUsuarios();
            altausers.Show();
        }
        private void modificarUsuarios(object sender, EventArgs e)
        {
            string pUsuario = textUsuario.Text;
            if (pUsuario != "")
            {
                if (fachada.buscarUsuario(pUsuario) != null)
                {
                    this.Hide();
                    var altausers = new modificarUsuario(pUsuario);
                    altausers.Show();
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                }
            }
            else 
            {
                MessageBox.Show("Debe ingresar un nombre de usuario para realizar modificaciones.");
            }
        }
        private void buscarUsuario(object sender, EventArgs e)
        {
            string pUsuario = textUsuario.Text;
            if (pUsuario != "")
            {
                if (fachada.buscarUsuario(pUsuario) != null)
                {
                    this.Hide();
                    var busquedausers = new buscarUsuario(pUsuario);
                    busquedausers.Show();
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre de usuario para realizar la busqueda.");
            }
        }
    }
}
