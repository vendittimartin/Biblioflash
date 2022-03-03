
namespace BiblioFlash_UI
{
    partial class PrestamosCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaIDEjemplar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombreLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaFechaPrestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaFechaDevolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaFechaRealDevolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(883, 322);
            this.dataGridView1.TabIndex = 7;
            // 
            // ColumnaID
            // 
            this.ColumnaID.HeaderText = "ID";
            this.ColumnaID.MinimumWidth = 6;
            this.ColumnaID.Name = "ColumnaID";
            this.ColumnaID.ReadOnly = true;
            this.ColumnaID.Width = 50;
            // 
            // ColumnaIDEjemplar
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ColumnaIDEjemplar.DefaultCellStyle = dataGridViewCellStyle1;
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
            this.ColumnaNombreLibro.Width = 150;
            // 
            // ColumnaNombreUsuario
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ColumnaNombreUsuario.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnaNombreUsuario.HeaderText = "Usuario";
            this.ColumnaNombreUsuario.MinimumWidth = 6;
            this.ColumnaNombreUsuario.Name = "ColumnaNombreUsuario";
            this.ColumnaNombreUsuario.ReadOnly = true;
            this.ColumnaNombreUsuario.Width = 130;
            // 
            // ColumnaFechaPrestamo
            // 
            this.ColumnaFechaPrestamo.HeaderText = "Fecha Prestamo";
            this.ColumnaFechaPrestamo.MinimumWidth = 6;
            this.ColumnaFechaPrestamo.Name = "ColumnaFechaPrestamo";
            this.ColumnaFechaPrestamo.ReadOnly = true;
            this.ColumnaFechaPrestamo.Width = 125;
            // 
            // ColumnaFechaDevolucion
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ColumnaFechaDevolucion.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnaFechaDevolucion.HeaderText = "Fecha Devolucion";
            this.ColumnaFechaDevolucion.MinimumWidth = 6;
            this.ColumnaFechaDevolucion.Name = "ColumnaFechaDevolucion";
            this.ColumnaFechaDevolucion.ReadOnly = true;
            this.ColumnaFechaDevolucion.Width = 125;
            // 
            // ColumnaFechaRealDevolucion
            // 
            this.ColumnaFechaRealDevolucion.HeaderText = "Fecha real de devolución";
            this.ColumnaFechaRealDevolucion.MinimumWidth = 6;
            this.ColumnaFechaRealDevolucion.Name = "ColumnaFechaRealDevolucion";
            this.ColumnaFechaRealDevolucion.ReadOnly = true;
            this.ColumnaFechaRealDevolucion.Width = 125;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            this.button2.Location = new System.Drawing.Point(395, 356);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PrestamosCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(46)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(883, 407);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PrestamosCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prestamos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaIDEjemplar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombreLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFechaPrestamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFechaDevolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaFechaRealDevolucion;
    }
}