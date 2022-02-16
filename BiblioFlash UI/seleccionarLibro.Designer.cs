
namespace BiblioFlash_UI
{
    partial class seleccionarLibro
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
            this.ColumnaCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxTituloLibro = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.ColumnaISBN,
            this.ColumnaCantidad});
            this.listaLibros.Location = new System.Drawing.Point(14, 105);
            this.listaLibros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listaLibros.MultiSelect = false;
            this.listaLibros.Name = "listaLibros";
            this.listaLibros.ReadOnly = true;
            this.listaLibros.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.listaLibros.RowHeadersWidth = 51;
            this.listaLibros.RowTemplate.Height = 25;
            this.listaLibros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaLibros.Size = new System.Drawing.Size(766, 412);
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
            // ColumnaCantidad
            // 
            this.ColumnaCantidad.HeaderText = "Disponibles";
            this.ColumnaCantidad.MinimumWidth = 6;
            this.ColumnaCantidad.Name = "ColumnaCantidad";
            this.ColumnaCantidad.ReadOnly = true;
            this.ColumnaCantidad.Width = 150;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(470, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 4;
            this.button3.Text = "Buscar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // textBoxTituloLibro
            // 
            this.textBoxTituloLibro.Location = new System.Drawing.Point(208, 39);
            this.textBoxTituloLibro.Name = "textBoxTituloLibro";
            this.textBoxTituloLibro.PlaceholderText = "Título del libro";
            this.textBoxTituloLibro.Size = new System.Drawing.Size(223, 27);
            this.textBoxTituloLibro.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(592, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(294, 547);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "Buscar ejemplares";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // seleccionarLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 612);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxTituloLibro);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listaLibros);
            this.Name = "seleccionarLibro";
            this.Text = "librosDisponibles";
            ((System.ComponentModel.ISupportInitialize)(this.listaLibros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView listaLibros;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaAutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaCantidad;
        private System.Windows.Forms.TextBox textBoxTituloLibro;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}