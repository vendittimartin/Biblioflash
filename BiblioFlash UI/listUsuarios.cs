using Biblioflash;
using Biblioflash.Manager.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class listUsuarios : Form
    {
        Fachada fachada = new Fachada();
        public listUsuarios()
        {
            InitializeComponent();
            listaLibros.Rows.Clear();
            List<UsuarioDTO> listLUsuarios = fachada.ListaUsuarios();
            foreach (var obj in listLUsuarios)
            {
                listaLibros.Rows.Add(obj.NombreUsuario, obj.Mail, obj.Score, obj.RangoUsuario);
            }
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            listaLibros.Rows.Clear();
            List<UsuarioDTO> listLUsuarios = fachada.ListaUsuarios();
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
                List<UsuarioDTO> usuarios = fachada.BuscarUsuarioSimilitud(titulo);
                foreach (var obj in usuarios)
                {
                    listaLibros.Rows.Add(obj.NombreUsuario, obj.Mail, obj.Score, obj.RangoUsuario);
                }
            }
        }
    }
}
