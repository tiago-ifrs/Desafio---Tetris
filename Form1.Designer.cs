﻿
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
            this.panelTabuleiro = new System.Windows.Forms.Panel();
            this.labelPause = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAtual = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelProx = new System.Windows.Forms.Panel();
            this.buttonNJ = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.labelKey = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPlacar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(900, 668);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "TGD 2021";
            // 
            // panelTabuleiro
            // 
            this.panelTabuleiro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTabuleiro.Location = new System.Drawing.Point(13, 13);
            this.panelTabuleiro.Name = "panelTabuleiro";
            this.panelTabuleiro.Size = new System.Drawing.Size(420, 680);
            this.panelTabuleiro.TabIndex = 3;
            this.panelTabuleiro.Paint += new System.Windows.Forms.PaintEventHandler(this.LayoutPanel1_Paint);
            // 
            // labelPause
            // 
            this.labelPause.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPause.AutoSize = true;
            this.labelPause.BackColor = System.Drawing.Color.White;
            this.labelPause.Location = new System.Drawing.Point(439, 668);
            this.labelPause.Name = "labelPause";
            this.labelPause.Size = new System.Drawing.Size(52, 25);
            this.labelPause.TabIndex = 0;
            this.labelPause.Text = "Tetris";
            this.labelPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Atual";
            // 
            // panelAtual
            // 
            this.panelAtual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAtual.Location = new System.Drawing.Point(439, 41);
            this.panelAtual.Name = "panelAtual";
            this.panelAtual.Size = new System.Drawing.Size(250, 250);
            this.panelAtual.TabIndex = 5;
            this.panelAtual.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAtual_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Próxima";
            // 
            // panelProx
            // 
            this.panelProx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelProx.Location = new System.Drawing.Point(439, 322);
            this.panelProx.Name = "panelProx";
            this.panelProx.Size = new System.Drawing.Size(250, 250);
            this.panelProx.TabIndex = 7;
            // 
            // buttonNJ
            // 
            this.buttonNJ.Location = new System.Drawing.Point(439, 578);
            this.buttonNJ.Name = "buttonNJ";
            this.buttonNJ.Size = new System.Drawing.Size(112, 34);
            this.buttonNJ.TabIndex = 8;
            this.buttonNJ.Text = "Novo Jogo";
            this.buttonNJ.UseVisualStyleBackColor = true;
            this.buttonNJ.Click += new System.EventHandler(this.buttonNJ_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(557, 578);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(112, 34);
            this.buttonPause.TabIndex = 9;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Font = new System.Drawing.Font("Wingdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelKey.Location = new System.Drawing.Point(557, 668);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(0, 20);
            this.labelKey.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(695, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Score";
            // 
            // labelPlacar
            // 
            this.labelPlacar.AutoSize = true;
            this.labelPlacar.Location = new System.Drawing.Point(696, 42);
            this.labelPlacar.Name = "labelPlacar";
            this.labelPlacar.Size = new System.Drawing.Size(59, 25);
            this.labelPlacar.TabIndex = 12;
            this.labelPlacar.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 712);
            this.Controls.Add(this.labelPlacar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.labelPause);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonNJ);
            this.Controls.Add(this.panelProx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelAtual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelTabuleiro);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Form1";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTabuleiro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelAtual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelProx;
        private System.Windows.Forms.Button buttonNJ;
        private System.Windows.Forms.Label labelPause;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelPlacar;
    }
}

