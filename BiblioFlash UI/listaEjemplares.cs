using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioflash.Manager.Domain;

namespace BiblioFlash_UI
{
    public partial class listaEjemplares : Form
    {
        public listaEjemplares(List<Ejemplar> pListEjemplares)
        {
            InitializeComponent(); 
            listaLibros.Rows.Clear();
            foreach (var obj in pListEjemplares)
            {
                listaLibros.Rows.Add(obj.Libro.ID, obj.ID);
            }
        }
    }
}
