using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.DTO;
using Biblioflash.Manager.Domain;

namespace BiblioFlash_UI
{
    partial class buscarUsuario
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
        private void InitializeComponent(UsuarioDTO user, string pRango)
        {
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.Label();
            this.textMail = new System.Windows.Forms.TextBox();
            this.textScore = new System.Windows.Forms.TextBox();
            this.textRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(206, 46);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.ReadOnly = true;
            this.textUsuario.Size = new System.Drawing.Size(257, 27);
            this.textUsuario.TabIndex = 0;
            this.textUsuario.Text = user.NombreUsuario;
            // 
            // textNombre
            // 
            this.textNombre.AutoSize = true;
            this.textNombre.Location = new System.Drawing.Point(93, 49);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(59, 20);
            this.textNombre.Text = "Usuario";
            this.textNombre.TabIndex = 1;
            // 
            // textMail
            // 
            this.textMail.Location = new System.Drawing.Point(206, 101);
            this.textMail.Name = "textMail";
            this.textMail.ReadOnly = true;
            this.textMail.Size = new System.Drawing.Size(257, 27);
            this.textMail.TabIndex = 2;
            this.textMail.Text = user.Mail;
            // 
            // textScore
            // 
            this.textScore.Location = new System.Drawing.Point(206, 161);
            this.textScore.Name = "textScore";
            this.textScore.ReadOnly = true;
            this.textScore.Size = new System.Drawing.Size(257, 27);
            this.textScore.TabIndex = 3;
            this.textScore.Text = Convert.ToString(user.Score);
            // 
            // textRol
            // 
            this.textRol.Location = new System.Drawing.Point(206, 224);
            this.textRol.Name = "textRol";
            this.textRol.ReadOnly = true;
            this.textRol.Size = new System.Drawing.Size(257, 27);
            this.textRol.TabIndex = 4;
            this.textRol.Text = pRango;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Score";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.volver_Click);
            // 
            // buscarUsuario
            // 
            this.ClientSize = new System.Drawing.Size(583, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textRol);
            this.Controls.Add(this.textScore);
            this.Controls.Add(this.textMail);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.textUsuario);
            this.Name = "buscarUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.Label textNombre;
        private System.Windows.Forms.TextBox textMail;
        private System.Windows.Forms.TextBox textScore;
        private System.Windows.Forms.TextBox textRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        
    }
}

