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

namespace BiblioFlash_UI
{
    public partial class Prestamos : Form
    {
        Fachada fachada = new Fachada();
        public Prestamos()
        {
            InitializeComponent();
        }
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<PrestamoDTO> listaPrestamos = fachada.listaPrestamos();
            foreach (var obj in listaPrestamos)
            {
                dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro, obj.Usuario, obj.FechaPrestamo, obj.FechaDevolucion);
            }
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text;
            if (busqueda != "" && comboBox1.SelectedItem != null)
            {
                if (Convert.ToString(comboBox1.SelectedItem) == "Usuario")
                {
                    dataGridView1.Rows.Clear();
                    List<PrestamoDTO> listaPrestamos = fachada.prestamosPorUsuario(busqueda);
                    if (listaPrestamos != null)
                    {
                        foreach (var obj in listaPrestamos)
                        {
                            dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro, obj.Usuario, obj.FechaPrestamo, obj.FechaDevolucion);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario no posee prestamos.");
                    }
                }
                else
                {
                    int busq = Convert.ToInt32(busqueda);
                    dataGridView1.Rows.Clear();
                    List<PrestamoDTO> listaPrestamos = fachada.prestamosPorEjemplar(busq);
                    if (listaPrestamos != null)
                    {
                        foreach (var obj in listaPrestamos)
                        {
                            dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro, obj.Usuario, obj.FechaPrestamo, obj.FechaDevolucion);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El ejemplar no posee prestamos.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var prestamos = new PantallaPrestamos();
            prestamos.Show();
        }
    }
}
