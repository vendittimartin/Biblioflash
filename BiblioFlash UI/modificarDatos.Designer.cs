using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.DTO;

namespace BiblioFlash_UI
{
    partial class modificarDatos
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
        private void InitializeComponent(UsuarioDTO user)
        {
            this.label1 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.Label();
            this.contraseña = new System.Windows.Forms.Label();
            this.Confirmar = new System.Windows.Forms.Button();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.textContraseña = new System.Windows.Forms.TextBox();
            this.Volver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textScore = new System.Windows.Forms.TextBox();
            this.textMail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(316, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro";
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.BackColor = System.Drawing.SystemColors.Window;
            this.usuario.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usuario.ForeColor = System.Drawing.Color.Brown;
            this.usuario.Location = new System.Drawing.Point(192, 140);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(74, 21);
            this.usuario.TabIndex = 1;
            this.usuario.Text = "Usuario";
            // 
            // contraseña
            // 
            this.contraseña.AutoSize = true;
            this.contraseña.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contraseña.ForeColor = System.Drawing.Color.Brown;
            this.contraseña.Location = new System.Drawing.Point(165, 183);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(101, 21);
            this.contraseña.TabIndex = 2;
            this.contraseña.Text = "Contraseña";
            // 
            // Confirmar
            // 
            this.Confirmar.BackColor = System.Drawing.Color.White;
            this.Confirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Confirmar.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.Confirmar.FlatAppearance.BorderSize = 2;
            this.Confirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Confirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Confirmar.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Confirmar.ForeColor = System.Drawing.Color.Brown;
            this.Confirmar.Location = new System.Drawing.Point(275, 391);
            this.Confirmar.Name = "Confirmar";
            this.Confirmar.Size = new System.Drawing.Size(101, 29);
            this.Confirmar.TabIndex = 3;
            this.Confirmar.Text = "Confirmar";
            this.Confirmar.UseVisualStyleBackColor = false;
            this.Confirmar.Click += new System.EventHandler(this.confirmar_Click);
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(316, 138);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(232, 27);
            this.textUsuario.TabIndex = 7;
            this.textUsuario.ReadOnly = true;
            this.textUsuario.Text = user.NombreUsuario;
            // 
            // textContraseña
            // 
            this.textContraseña.Location = new System.Drawing.Point(316, 181);
            this.textContraseña.Name = "textContraseña";
            this.textContraseña.PasswordChar = '*';
            this.textContraseña.Size = new System.Drawing.Size(232, 27);
            this.textContraseña.TabIndex = 8;
            this.textContraseña.Text = user.Contraseña;
            // 
            // Volver
            // 
            this.Volver.BackColor = System.Drawing.Color.White;
            this.Volver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Volver.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.Volver.FlatAppearance.BorderSize = 2;
            this.Volver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Volver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Volver.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Volver.ForeColor = System.Drawing.Color.Brown;
            this.Volver.Location = new System.Drawing.Point(454, 391);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(94, 29);
            this.Volver.TabIndex = 9;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = false;
            this.Volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(207, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(204, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email";
            // 
            // textScore
            // 
            this.textScore.Location = new System.Drawing.Point(316, 226);
            this.textScore.Name = "textScore";
            this.textScore.Size = new System.Drawing.Size(232, 27);
            this.textScore.TabIndex = 12;
            this.textScore.Text = Convert.ToString(user.Score);
            this.textScore.ReadOnly = true;
            // 
            // textMail
            // 
            this.textMail.Location = new System.Drawing.Point(316, 278);
            this.textMail.Name = "textMail";
            this.textMail.Size = new System.Drawing.Size(232, 27);
            this.textMail.TabIndex = 13;
            this.textMail.Text = user.Mail;
            // 
            // modificarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textMail);
            this.Controls.Add(this.textScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.textContraseña);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.Confirmar);
            this.Controls.Add(this.contraseña);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.label1);
            this.Name = "modificarUsuario";
            this.Text = "Iniciar Sesion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label usuario;
        private System.Windows.Forms.Label contraseña;
        private System.Windows.Forms.Button Confirmar;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.TextBox textContraseña;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textScore;
        private System.Windows.Forms.TextBox textMail;
    }
}

