using Biblioflash.Manager.Domain;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioflash.Manager.DTO;

namespace BiblioFlash_UI
{
    public partial class listaEjemplares : Form
    {
        public listaEjemplares(List<EjemplarDTO> pListEjemplares)
        {
            InitializeComponent();
            listaLibros.Rows.Clear();
            foreach (var obj in pListEjemplares)
            {
                listaLibros.Rows.Add(obj.Libro.ISBN, obj.ID);
            }
        }
    }
}
