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
using Biblioflash.Manager.Domain;

namespace BiblioFlash_UI
{
    public partial class listUsuarios : Form
    {
        Fachada fachada = new Fachada();
        public listUsuarios()
        {
            InitializeComponent();
            listaLibros.Rows.Clear();
            List<UsuarioDTO> listLUsuarios = fachada.listaUsuarios();
            foreach (var obj in listLUsuarios)
            {
                listaLibros.Rows.Add(obj.NombreUsuario, obj.Mail, obj.Score, obj.RangoUsuario);
            }
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            listaLibros.Rows.Clear();
            List<UsuarioDTO> listLUsuarios = fachada.listaUsuarios();
            foreach (var obj in listLUsuarios)
            {
                listaLibros.Rows.Add(obj.NombreUsuario, obj.Mail, obj.Score, obj.RangoUsuario);
            }
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string titulo = textBoxTituloLibro.Text;
            if (titulo != "")
            {
                listaLibros.Rows.Clear();
                List<UsuarioDTO> usuarios = fachada.buscarUsuarioSimilitud(titulo);
                foreach (var obj in usuarios)
                {
                    listaLibros.Rows.Add(obj.NombreUsuario, obj.Mail, obj.Score, obj.RangoUsuario);
                }
            }
        }
    }
}
