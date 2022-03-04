
namespace BiblioFlash_UI
{
    partial class extenderPrestamo
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaIDEjemplar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombreLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaFechaPrestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaFechaDevolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(147, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Nombre de usuario";
            this.textBox1.Size = new System.Drawing.Size(272, 29);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(513, 52);
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
            this.ColumnaFechaDevolucion});
            this.dataGridView1.Location = new System.Drawing.Point(-11, 117);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(900, 304);
            this.dataGridView1.TabIndex = 7;
            // 
            // ColumnaID
            // 
            this.ColumnaID.HeaderText = "ID";
            this.ColumnaID.MinimumWidth = 6;
            this.ColumnaID.Name = "ColumnaID";
            this.ColumnaID.ReadOnly = true;
            this.ColumnaID.Width = 80;
            // 
            // ColumnaIDEjemplar
            // 
            this.ColumnaIDEjemplar.HeaderText = "ID Ejemplar";
            this.ColumnaIDEjemplar.MinimumWidth = 6;
            this.ColumnaIDEjemplar.Name = "ColumnaIDEjemplar";
            this.ColumnaIDEjemplar.ReadOnly = true;
            this.ColumnaIDEjemplar.Width = 125;
            // 
            // ColumnaNombreLibro
            // 
            this.ColumnaNombreLibro.HeaderText = "Libro";
            this.ColumnaNombreLibro.MinimumWidth = 6;
            this.ColumnaNombreLibro.Name = "ColumnaNombreLibro";
            this.ColumnaNombreLibro.ReadOnly = true;
            this.ColumnaNombreLibro.Width = 180;
            // 
            // ColumnaNombreUsuario
            // 
            this.ColumnaNombreUsuario.HeaderText = "Usuario";
            this.ColumnaNombreUsuario.MinimumWidth = 6;
            this.ColumnaNombreUsuario.Name = "ColumnaNombreUsuario";
            this.ColumnaNombreUsuario.ReadOnly = true;
            this.ColumnaNombreUsuario.Width = 150;
            // 
            // ColumnaFechaPrestamo
            // 
            this.ColumnaFechaPrestamo.HeaderText = "Fecha Prestamo";
            this.ColumnaFechaPrestamo.MinimumWidth = 6;
            this.ColumnaFechaPrestamo.Name = "ColumnaFechaPrestamo";
            this.ColumnaFechaPrestamo.ReadOnly = true;
            this.ColumnaFechaPrestamo.Width = 145;
            // 
            // ColumnaFechaDevolucion
            // 
            this.ColumnaFechaDevolucion.HeaderText = "Fecha Devolucion";
            this.ColumnaFechaDevolucion.MinimumWidth = 6;
            this.ColumnaFechaDevolucion.Name = "ColumnaFechaDevolucion";
            this.ColumnaFechaDevolucion.ReadOnly = true;
            this.ColumnaFechaDevolucion.Width = 145;
            // 
            // button2
            // 
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(389, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Extender";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.extender_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(656, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericUpDown1.Location = new System.Drawing.Point(439, 38);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(150, 29);
            this.numericUpDown1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(255, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cantidad de días";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(-11, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 116);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(-11, 427);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 172);
            this.panel2.TabIndex = 13;
            // 
            // extenderPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 593);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "extenderPrestamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prestamos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaIDEjemplar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombreLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFechaPrestamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFechaDevolucion;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}