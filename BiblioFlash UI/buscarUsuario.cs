using Biblioflash;
using Biblioflash.Manager.DTO;
using System;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class buscarUsuario : Form
    {
        Fachada fachada = new Fachada();
        public buscarUsuario(string pNombreUsuario)
        {
            UsuarioDTO user = fachada.BuscarUsuario(pNombreUsuario);
            if (user.RangoUsuario == Biblioflash.Manager.Domain.Rango.Admin)
            {
                InitializeComponent(user, "Admin");
            }
            else
            {
                InitializeComponent(user, "Cliente");
            }

        }
        private void volver_Click(object sender, EventArgs e)
        {
            var usuarios = new Usuarios();
            usuarios.Show();
            this.Close();
        }
    }
}
