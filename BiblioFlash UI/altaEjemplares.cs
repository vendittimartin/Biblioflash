﻿using Biblioflash;
using Biblioflash.Manager.Domain;
using Biblioflash.Manager.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class altaEjemplares : Form
    {
        private Fachada fachada = new Fachada();
        public altaEjemplares()
        {
            InitializeComponent();
            listaLibros.Rows.Clear();
            List<LibroDTO> listLibros = fachada.ConsultaLibrosDisponibles();
            foreach (var obj in listLibros)
            {
                listaLibros.Rows.Add(obj.Titulo, obj.Autor, obj.ISBN);
            }
            button1.Enabled = true;
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            listaLibros.Rows.Clear();
            List<LibroDTO> listLibros = fachada.ConsultaLibrosDisponibles();
            foreach (var obj in listLibros)
            {
                listaLibros.Rows.Add(obj.Titulo, obj.Autor, obj.ISBN);
            }
            button1.Enabled = true;
        }
        private void botonAgregar_Click(object sender, EventArgs e)
        {
            int cant = Convert.ToInt32(cantEjemplares.Value);
            if (cant > 0 && cant < 51)
            {
                DataGridViewSelectedRowCollection fila = listaLibros.SelectedRows;
                DataGridViewCellCollection columnas = fila[0].Cells;
                LibroDTO pLibro = new LibroDTO
                {
                    Titulo = columnas[0].Value.ToString(),
                    Autor = columnas[1].Value.ToString(),
                    ISBN = Int64.Parse(columnas[2].Value.ToString())
                };
                for (int i = 0; i < cant; i++)
                {
                    EjemplarDTO ejemplarDTO = new EjemplarDTO
                    {
                        Libro = pLibro,
                        Prestamos = null
                    };
                    fachada.AgregarEjemplar(ejemplarDTO.Libro.ISBN);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No se puede agregar dicha cantidad de ejemplares.");
            }
        }
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            string titulo = textBoxTituloLibro.Text;
            if (titulo != "")
            {
                listaLibros.Rows.Clear();
                List<LibroDTO> libros = fachada.BuscarLibroSimilitud(titulo);
                foreach (var libro in libros)
                {
                    listaLibros.Rows.Add(libro.Titulo, libro.Autor, libro.ISBN);
                    button1.Enabled = true;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
