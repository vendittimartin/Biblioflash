﻿using Biblioflash;
using System;
using System.Windows.Forms;

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
            altausers.ShowDialog();
        }
        private void listaUsuarios(object sender, EventArgs e)
        {
            var listUsuarios = new listUsuarios();
            listUsuarios.ShowDialog();
        }
        private void modificarUsuarios(object sender, EventArgs e)
        {
            string pUsuario = textUsuario.Text;
            if (pUsuario != "")
            {
                if (fachada.BuscarUsuario(pUsuario) != null)
                {
                    this.Hide();
                    var altausers = new modificarUsuario(pUsuario);
                    altausers.ShowDialog();
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
                if (fachada.BuscarUsuario(pUsuario) != null)
                {
                    this.Hide();
                    var busquedausers = new buscarUsuario(pUsuario);
                    busquedausers.ShowDialog();
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
