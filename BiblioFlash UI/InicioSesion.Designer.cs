
namespace BiblioFlash_UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.Label();
            this.contraseña = new System.Windows.Forms.Label();
            this.Iniciar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.registro = new System.Windows.Forms.LinkLabel();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.textContraseña = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Iniciar Sesión";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.Location = new System.Drawing.Point(199, 168);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(59, 20);
            this.usuario.TabIndex = 1;
            this.usuario.Text = "Usuario";
            // 
            // contraseña
            // 
            this.contraseña.AutoSize = true;
            this.contraseña.Location = new System.Drawing.Point(175, 235);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(83, 20);
            this.contraseña.TabIndex = 2;
            this.contraseña.Text = "Contraseña";
            this.contraseña.Click += new System.EventHandler(this.contraseña_Click);
            // 
            // Iniciar
            // 
            this.Iniciar.Location = new System.Drawing.Point(272, 292);
            this.Iniciar.Name = "Iniciar";
            this.Iniciar.Size = new System.Drawing.Size(94, 29);
            this.Iniciar.TabIndex = 3;
            this.Iniciar.Text = "Iniciar";
            this.Iniciar.UseVisualStyleBackColor = true;
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(423, 292);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(94, 29);
            this.Cancelar.TabIndex = 4;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // registro
            // 
            this.registro.AutoSize = true;
            this.registro.Location = new System.Drawing.Point(294, 356);
            this.registro.Name = "registro";
            this.registro.Size = new System.Drawing.Size(207, 20);
            this.registro.TabIndex = 6;
            this.registro.TabStop = true;
            this.registro.Text = "¿No posee cuenta? Regístrese";
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(294, 168);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(223, 27);
            this.textUsuario.TabIndex = 7;
            // 
            // textContraseña
            // 
            this.textContraseña.Location = new System.Drawing.Point(294, 228);
            this.textContraseña.Name = "textContraseña";
            this.textContraseña.Size = new System.Drawing.Size(223, 27);
            this.textContraseña.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textContraseña);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.registro);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Iniciar);
            this.Controls.Add(this.contraseña);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Iniciar Sesion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label usuario;
        private System.Windows.Forms.Label contraseña;
        private System.Windows.Forms.Button Iniciar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.LinkLabel registro;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.TextBox textContraseña;
    }
}

