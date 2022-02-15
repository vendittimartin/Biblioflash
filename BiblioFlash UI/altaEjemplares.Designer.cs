
namespace BiblioFlash_UI
{
    partial class altaEjemplares
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listaLibros = new System.Windows.Forms.DataGridView();
            this.ColumnaTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaAutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxTituloLibro = new System.Windows.Forms.TextBox();
            this.cantEjemplares = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listaLibros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantEjemplares)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 596);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(470, 596);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 537);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cantidad de ejemplares";
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
            // cantEjemplares
            // 
            this.cantEjemplares.Location = new System.Drawing.Point(299, 535);
            this.cantEjemplares.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.cantEjemplares.Name = "cantEjemplares";
            this.cantEjemplares.Size = new System.Drawing.Size(150, 27);
            this.cantEjemplares.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(587, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 29);
            this.button4.TabIndex = 8;
            this.button4.Text = "Limpiar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // altaEjemplares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 637);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cantEjemplares);
            this.Controls.Add(this.textBoxTituloLibro);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listaLibros);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "altaEjemplares";
            this.Text = "altaEjemplares";
            ((System.ComponentModel.ISupportInitialize)(this.listaLibros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantEjemplares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView listaLibros;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaAutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaISBN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxTituloLibro;
        private System.Windows.Forms.NumericUpDown cantEjemplares;
        private System.Windows.Forms.Button button4;
    }
}