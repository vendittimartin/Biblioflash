using Biblioflash.Manager.Domain;
using System.Collections.Generic;
using System.Windows.Forms;

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
