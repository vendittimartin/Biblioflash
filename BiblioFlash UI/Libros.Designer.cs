
namespace BiblioFlash_UI
{
    partial class Libros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listaLibros = new System.Windows.Forms.DataGridView();
            this.ColumnaTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaAutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.textBoxTituloLibro = new System.Windows.Forms.TextBox();
            this.botonAgregarSeleccion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listaLibros)).BeginInit();
            this.SuspendLayout();
            // 
            // listaLibros
            // 
            this.listaLibros.AllowUserToAddRows = false;
            this.listaLibros.AllowUserToDeleteRows = false;
            this.listaLibros.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.listaLibros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listaLibros.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.listaLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaLibros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaTitulo,
            this.ColumnaAutor,
            this.ColumnaISBN});
            this.listaLibros.Location = new System.Drawing.Point(14, 105);
            this.listaLibros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listaLibros.MultiSelect = false;
            this.listaLibros.Name = "listaLibros";
            this.listaLibros.ReadOnly = true;
            this.listaLibros.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.listaLibros.RowHeadersWidth = 51;
            this.listaLibros.RowTemplate.Height = 25;
            this.listaLibros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaLibros.Size = new System.Drawing.Size(782, 412);
            this.listaLibros.TabIndex = 0;
            // 
            // ColumnaTitulo
            // 
            this.ColumnaTitulo.HeaderText = "Titulo";
            this.ColumnaTitulo.MinimumWidth = 6;
            this.ColumnaTitulo.Name = "ColumnaTitulo";
            this.ColumnaTitulo.ReadOnly = true;
            this.ColumnaTitulo.Width = 250;
            // 
            // ColumnaAutor
            // 
            this.ColumnaAutor.HeaderText = "Autor";
            this.ColumnaAutor.MinimumWidth = 6;
            this.ColumnaAutor.Name = "ColumnaAutor";
            this.ColumnaAutor.ReadOnly = true;
            this.ColumnaAutor.Width = 230;
            // 
            // ColumnaISBN
            // 
            this.ColumnaISBN.HeaderText = "ISBN";
            this.ColumnaISBN.MinimumWidth = 6;
            this.ColumnaISBN.Name = "ColumnaISBN";
            this.ColumnaISBN.ReadOnly = true;
            this.ColumnaISBN.Width = 150;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(323, 47);
            this.botonBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(86, 31);
            this.botonBuscar.TabIndex = 1;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // textBoxTituloLibro
            // 
            this.textBoxTituloLibro.AccessibleDescription = "";
            this.textBoxTituloLibro.Location = new System.Drawing.Point(14, 47);
            this.textBoxTituloLibro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTituloLibro.Name = "textBoxTituloLibro";
            this.textBoxTituloLibro.PlaceholderText = "Ingrese el titulo del libro a buscar";
            this.textBoxTituloLibro.Size = new System.Drawing.Size(301, 27);
            this.textBoxTituloLibro.TabIndex = 2;
            // 
            // botonAgregarSeleccion
            // 
            this.botonAgregarSeleccion.Enabled = false;
            this.botonAgregarSeleccion.Location = new System.Drawing.Point(647, 525);
            this.botonAgregarSeleccion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botonAgregarSeleccion.Name = "botonAgregarSeleccion";
            this.botonAgregarSeleccion.Size = new System.Drawing.Size(149, 44);
            this.botonAgregarSeleccion.TabIndex = 3;
            this.botonAgregarSeleccion.Text = "Agregar seleccion";
            this.botonAgregarSeleccion.UseVisualStyleBackColor = true;
            this.botonAgregarSeleccion.Click += new System.EventHandler(this.botonAgregarSeleccion_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // Libros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 585);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.botonAgregarSeleccion);
            this.Controls.Add(this.textBoxTituloLibro);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.listaLibros);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Libros";
            this.Text = "PantallaAltaLibros";
            ((System.ComponentModel.ISupportInitialize)(this.listaLibros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listaLibros;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaAutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaISBN;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.TextBox textBoxTituloLibro;
        private System.Windows.Forms.Button botonAgregarSeleccion;
        private System.Windows.Forms.Button button1;
    }
}