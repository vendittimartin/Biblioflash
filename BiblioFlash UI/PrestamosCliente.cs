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
    public partial class PrestamosCliente : Form
    {
        Fachada fachada = new Fachada();
        public PrestamosCliente(string pUsuario)
        {
            InitializeComponent();
            List<PrestamoDTO> listaPrestamos = new List<PrestamoDTO>();
            dataGridView1.Rows.Clear();
            listaPrestamos = fachada.prestamosPorUsuario(pUsuario);
            if (listaPrestamos != null)
            {
                foreach (var obj in listaPrestamos)
                {
                    dataGridView1.Rows.Add(obj.ID, obj.IDEjemplar, obj.Libro.Titulo, obj.Usuario.NombreUsuario, obj.FechaPrestamo, obj.FechaDevolucion, obj.FechaRealDevolucion);
                }
            }
            else
            {
                MessageBox.Show("El usuario no posee prestamos");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
