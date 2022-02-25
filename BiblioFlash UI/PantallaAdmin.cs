﻿using System;
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
    public partial class PantallaAdmin : Form
    {
        public PantallaAdmin()
        {
            InitializeComponent();
        }

        public void cerrarSesion(object sender, EventArgs e)
        {
            this.Hide();
            var inicio = new Form1();
            inicio.Show();
        }
        public void usuarios(object sender, EventArgs e)
        {
            this.Hide();
            var users = new Usuarios();
            users.ShowDialog();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var libros = new PantallaLibros();
            libros.ShowDialog();
        }
        private void prestamos_Click(object sender, EventArgs e)
        {
            this.Hide();
            var prestamos = new PantallaPrestamos();
            prestamos.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var prestamos = new Prestamos();
            prestamos.ShowDialog();
        }
    }
}
