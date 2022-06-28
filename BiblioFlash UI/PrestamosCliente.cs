using Biblioflash;
using Biblioflash.Manager.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BiblioFlash_UI
{
    public partial class PrestamosCliente : Form
    {
        Fachada fachada = new Fachada();
        public PrestamosCliente(string pUsuario)
        {
            InitializeComponent();
            _ = new List<PrestamoDTO>();
            List<PrestamoDTO> listaPrestamos = fachada.PrestamosPorUsuarioX(pUsuario);
            if (listaPrestamos != null)
            {
                foreach (var obj in listaPrestamos)
                {
                    dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion, obj.FechaRealDevolucion);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            string value = dataGridView1.Rows[0].Cells[3].Value.ToString();
            UsuarioDTO user = fachada.BuscarUsuario(value);
            var cliente = new Form3(user);
            cliente.Show();
        }
    }
}
