
namespace BiblioFlash_UI
{
    partial class Prestamos
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaIDEjemplar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombreLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaFechaPrestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaFechaDevolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaFechaRealDevolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.textBox1.Location = new System.Drawing.Point(116, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(254, 29);
            this.textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Usuario",
            "ID Ejemplar"});
            this.comboBox1.Location = new System.Drawing.Point(419, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 30);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(633, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaID,
            this.ColumnaIDEjemplar,
            this.ColumnaNombreLibro,
            this.ColumnaNombreUsuario,
            this.ColumnaFechaPrestamo,
            this.ColumnaFechaDevolucion,
            this.ColumnaFechaRealDevolucion});
            this.dataGridView1.Location = new System.Drawing.Point(-4, 108);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(990, 416);
            this.dataGridView1.TabIndex = 7;
            // 
            // ColumnaID
            // 
            this.dataGridView1.Columns[0].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(191, 192, 192);
            this.ColumnaID.HeaderText = "ID";
            this.ColumnaID.MinimumWidth = 6;
            this.ColumnaID.Name = "ColumnaID";
            this.ColumnaID.ReadOnly = true;
            this.ColumnaID.Width = 50;
            // 
            // ColumnaIDEjemplar
            // 
            this.ColumnaIDEjemplar.HeaderText = "ID Ejemplar";
            this.ColumnaIDEjemplar.MinimumWidth = 6;
            this.ColumnaIDEjemplar.Name = "ColumnaIDEjemplar";
            this.ColumnaIDEjemplar.ReadOnly = true;
            this.ColumnaIDEjemplar.Width = 80;
            // 
            // ColumnaNombreLibro
            // 
            this.dataGridView1.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(191, 192, 192);
            this.ColumnaNombreLibro.HeaderText = "Libro";
            this.ColumnaNombreLibro.MinimumWidth = 6;
            this.ColumnaNombreLibro.Name = "ColumnaNombreLibro";
            this.ColumnaNombreLibro.ReadOnly = true;
            this.ColumnaNombreLibro.Width = 190;
            // 
            // ColumnaNombreUsuario
            // 
            this.ColumnaNombreUsuario.HeaderText = "Usuario";
            this.ColumnaNombreUsuario.MinimumWidth = 6;
            this.ColumnaNombreUsuario.Name = "ColumnaNombreUsuario";
            this.ColumnaNombreUsuario.ReadOnly = true;
            this.ColumnaNombreUsuario.Width = 160;
            // 
            // ColumnaFechaPrestamo
            // 
            this.dataGridView1.Columns[4].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(191, 192, 192);
            this.ColumnaFechaPrestamo.HeaderText = "Fecha Prestamo";
            this.ColumnaFechaPrestamo.MinimumWidth = 6;
            this.ColumnaFechaPrestamo.Name = "ColumnaFechaPrestamo";
            this.ColumnaFechaPrestamo.ReadOnly = true;
            this.ColumnaFechaPrestamo.Width = 150;
            // 
            // ColumnaFechaDevolucion
            // 
            this.ColumnaFechaDevolucion.HeaderText = "Fecha Devolucion";
            this.ColumnaFechaDevolucion.MinimumWidth = 6;
            this.ColumnaFechaDevolucion.Name = "ColumnaFechaDevolucion";
            this.ColumnaFechaDevolucion.ReadOnly = true;
            this.ColumnaFechaDevolucion.Width = 150;
            // 
            // ColumnaFechaRealDevolucion
            // 
            this.dataGridView1.Columns[6].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(191, 192, 192);
            this.ColumnaFechaRealDevolucion.HeaderText = "Fecha real de devolución";
            this.ColumnaFechaRealDevolucion.MinimumWidth = 6;
            this.ColumnaFechaRealDevolucion.Name = "ColumnaFechaRealDevolucion";
            this.ColumnaFechaRealDevolucion.ReadOnly = true;
            this.ColumnaFechaRealDevolucion.Width = 150;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(442, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(750, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(-4, 530);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 113);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(-4, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(990, 104);
            this.panel2.TabIndex = 10;
            // 
            // Prestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 638);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Prestamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prestamos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaIDEjemplar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombreLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFechaPrestamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFechaDevolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFechaRealDevolucion;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}