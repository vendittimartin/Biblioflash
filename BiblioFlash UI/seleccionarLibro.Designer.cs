
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
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxTituloLibro = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.listaLibros)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.listaLibros.Location = new System.Drawing.Point(0, 105);
            this.listaLibros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listaLibros.MultiSelect = false;
            this.listaLibros.Name = "listaLibros";
            this.listaLibros.ReadOnly = true;
            this.listaLibros.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.listaLibros.RowHeadersWidth = 51;
            this.listaLibros.RowTemplate.Height = 25;
            this.listaLibros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaLibros.Size = new System.Drawing.Size(808, 412);
            this.listaLibros.TabIndex = 0;
            // 
            // ColumnaTitulo
            // 
            this.ColumnaTitulo.HeaderText = "Titulo";
            this.ColumnaTitulo.MinimumWidth = 6;
            this.ColumnaTitulo.Name = "ColumnaTitulo";
            this.ColumnaTitulo.ReadOnly = true;
            this.ColumnaTitulo.Width = 260;
            // 
            // ColumnaAutor
            // 
            this.ColumnaAutor.HeaderText = "Autor";
            this.ColumnaAutor.MinimumWidth = 6;
            this.ColumnaAutor.Name = "ColumnaAutor";
            this.ColumnaAutor.ReadOnly = true;
            this.ColumnaAutor.Width = 250;
            // 
            // ColumnaISBN
            // 
            this.ColumnaISBN.HeaderText = "ISBN";
            this.ColumnaISBN.MinimumWidth = 6;
            this.ColumnaISBN.Name = "ColumnaISBN";
            this.ColumnaISBN.ReadOnly = true;
            this.ColumnaISBN.Width = 230;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.button3.Location = new System.Drawing.Point(436, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 4;
            this.button3.Text = "Buscar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // textBoxTituloLibro
            // 
            this.textBoxTituloLibro.BackColor = System.Drawing.Color.White;
            this.textBoxTituloLibro.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxTituloLibro.Location = new System.Drawing.Point(153, 38);
            this.textBoxTituloLibro.Name = "textBoxTituloLibro";
            this.textBoxTituloLibro.PlaceholderText = "Título del libro";
            this.textBoxTituloLibro.Size = new System.Drawing.Size(244, 29);
            this.textBoxTituloLibro.TabIndex = 5;
            this.textBoxTituloLibro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.button1.Location = new System.Drawing.Point(558, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.button2.Location = new System.Drawing.Point(328, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "Buscar ejemplares";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.textBoxTituloLibro);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-3, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 101);
            this.panel1.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.button4.Location = new System.Drawing.Point(358, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 29);
            this.button4.TabIndex = 9;
            this.button4.Text = "Cerrar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.botonCerrar);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(-3, 524);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(808, 126);
            this.panel2.TabIndex = 10;
            // 
            // seleccionarLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 629);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listaLibros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "seleccionarLibro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "librosDisponibles";
            ((System.ComponentModel.ISupportInitialize)(this.listaLibros)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView listaLibros;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaAutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaISBN;
        private System.Windows.Forms.TextBox textBoxTituloLibro;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
    }
}