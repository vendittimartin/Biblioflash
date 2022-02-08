
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
            this.registro = new System.Windows.Forms.LinkLabel();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.textContraseña = new System.Windows.Forms.TextBox();
            this.cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(248, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Iniciar Sesión";
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.BackColor = System.Drawing.SystemColors.Window;
            this.usuario.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usuario.ForeColor = System.Drawing.Color.Brown;
            this.usuario.Location = new System.Drawing.Point(174, 130);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(57, 16);
            this.usuario.TabIndex = 1;
            this.usuario.Text = "Usuario";
            // 
            // contraseña
            // 
            this.contraseña.AutoSize = true;
            this.contraseña.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contraseña.ForeColor = System.Drawing.Color.Brown;
            this.contraseña.Location = new System.Drawing.Point(150, 176);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(78, 16);
            this.contraseña.TabIndex = 2;
            this.contraseña.Text = "Contraseña";
            // 
            // Iniciar
            // 
            this.Iniciar.BackColor = System.Drawing.Color.White;
            this.Iniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Iniciar.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.Iniciar.FlatAppearance.BorderSize = 2;
            this.Iniciar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Iniciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Iniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Iniciar.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Iniciar.ForeColor = System.Drawing.Color.Brown;
            this.Iniciar.Location = new System.Drawing.Point(238, 222);
            this.Iniciar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Iniciar.Name = "Iniciar";
            this.Iniciar.Size = new System.Drawing.Size(82, 22);
            this.Iniciar.TabIndex = 3;
            this.Iniciar.Text = "Iniciar";
            this.Iniciar.UseVisualStyleBackColor = false;
            this.Iniciar.Click += new System.EventHandler(this.iniciar_Click);
            // 
            // registro
            // 
            this.registro.AutoSize = true;
            this.registro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registro.Location = new System.Drawing.Point(257, 270);
            this.registro.Name = "registro";
            this.registro.Size = new System.Drawing.Size(162, 15);
            this.registro.TabIndex = 6;
            this.registro.TabStop = true;
            this.registro.Text = "¿No posee cuenta? Regístrese";
            this.registro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registro_LinkClicked);
            this.registro.Click += new System.EventHandler(this.registro_Click);
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(257, 129);
            this.textUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(204, 23);
            this.textUsuario.TabIndex = 7;
            // 
            // textContraseña
            // 
            this.textContraseña.Location = new System.Drawing.Point(257, 174);
            this.textContraseña.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textContraseña.Name = "textContraseña";
            this.textContraseña.PasswordChar = '*';
            this.textContraseña.Size = new System.Drawing.Size(204, 23);
            this.textContraseña.TabIndex = 8;
            // 
            // cancelar
            // 
            this.cancelar.BackColor = System.Drawing.Color.White;
            this.cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelar.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.cancelar.FlatAppearance.BorderSize = 2;
            this.cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelar.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelar.ForeColor = System.Drawing.Color.Brown;
            this.cancelar.Location = new System.Drawing.Point(378, 222);
            this.cancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(82, 22);
            this.cancelar.TabIndex = 9;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = false;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.textContraseña);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.registro);
            this.Controls.Add(this.Iniciar);
            this.Controls.Add(this.contraseña);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.LinkLabel registro;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.TextBox textContraseña;
        private System.Windows.Forms.Button cancelar;
    }
}

