
namespace Desafio___Tetris
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTabuleiro = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAtual = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelProx = new System.Windows.Forms.Panel();
            this.buttonNJ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(693, 882);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "TGD 2021";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 882);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(28, 33);
            this.panel1.TabIndex = 2;
            // 
            // panelTabuleiro
            // 
            this.panelTabuleiro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTabuleiro.Location = new System.Drawing.Point(13, 13);
            this.panelTabuleiro.Name = "panelTabuleiro";
            this.panelTabuleiro.Size = new System.Drawing.Size(770, 863);
            this.panelTabuleiro.TabIndex = 3;
            this.panelTabuleiro.Paint += new System.Windows.Forms.PaintEventHandler(this.LayoutPanel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(789, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Atual";
            // 
            // panelAtual
            // 
            this.panelAtual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAtual.Location = new System.Drawing.Point(790, 37);
            this.panelAtual.Name = "panelAtual";
            this.panelAtual.Size = new System.Drawing.Size(250, 250);
            this.panelAtual.TabIndex = 5;
            this.panelAtual.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAtual_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(790, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Próxima";
            // 
            // panelProx
            // 
            this.panelProx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelProx.Location = new System.Drawing.Point(790, 318);
            this.panelProx.Name = "panelProx";
            this.panelProx.Size = new System.Drawing.Size(250, 250);
            this.panelProx.TabIndex = 7;
            // 
            // buttonNJ
            // 
            this.buttonNJ.Location = new System.Drawing.Point(789, 575);
            this.buttonNJ.Name = "buttonNJ";
            this.buttonNJ.Size = new System.Drawing.Size(112, 34);
            this.buttonNJ.TabIndex = 8;
            this.buttonNJ.Text = "Novo Jogo";
            this.buttonNJ.UseVisualStyleBackColor = true;
            this.buttonNJ.Click += new System.EventHandler(this.buttonNJ_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 951);
            this.Controls.Add(this.buttonNJ);
            this.Controls.Add(this.panelProx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelAtual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelTabuleiro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelTabuleiro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelAtual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelProx;
        private System.Windows.Forms.Button buttonNJ;
    }
}

