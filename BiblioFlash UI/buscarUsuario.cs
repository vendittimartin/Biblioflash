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
using Biblioflash.Manager.DTO;

namespace BiblioFlash_UI
{
    public partial class buscarUsuario : Form
    {
        Fachada fachada = new Fachada();
        public buscarUsuario(string pNombreUsuario)
        {
            UsuarioDTO user = fachada.buscarUsuario(pNombreUsuario);
            if (user.RangoUsuario == Biblioflash.Manager.Domain.Rango.Admin)
            {
                InitializeComponent(user,"Admin");
            }
            else
            {
                InitializeComponent(user,"Cliente");
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
