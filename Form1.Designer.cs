
using System.Drawing;

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
            this.label2 = new System.Windows.Forms.Label();
            this.panelAtual = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelProx = new System.Windows.Forms.Panel();
            this.buttonNJ = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.labelKey = new System.Windows.Forms.Label();
            this.buttonTGD = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonPontuacao = new System.Windows.Forms.Button();
            this.trackBarNivel = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.labelTBNivel = new System.Windows.Forms.Label();
            scorePlaceHolderPanel = new System.Windows.Forms.Panel();
            this.pausePlaceHolderPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNivel)).BeginInit();
            this.SuspendLayout();
            /*TGD*/
            //
            // pausePlaceHolderPanel 
            //
            pausePlaceHolderPanel.Location = new System.Drawing.Point(439, 618);
            pausePlaceHolderPanel.Name = "pausePlaceHolderPanel";
            pausePlaceHolderPanel.Size = new System.Drawing.Size(87, 61);
            pausePlaceHolderPanel.TabIndex = 29;
            
            // 
            // scorePlaceHolderPanel
            // 
            scorePlaceHolderPanel.Location = new System.Drawing.Point(616, 13);
            scorePlaceHolderPanel.Name = "scorePlaceHolderPanel";
            scorePlaceHolderPanel.Size = new System.Drawing.Size(300, 150);
            scorePlaceHolderPanel.TabIndex = 29;
            /*TGD*/
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(900, 668);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 0;
            // 
            // panelTabuleiro
            // 
            this.panelTabuleiro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTabuleiro.Location = new System.Drawing.Point(13, 13);
            this.panelTabuleiro.Name = "panelTabuleiro";
            this.panelTabuleiro.Size = new System.Drawing.Size(420, 680);
            this.panelTabuleiro.TabIndex = 3;
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
            this.panelAtual.Size = new System.Drawing.Size(170, 170);
            this.panelAtual.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Próxima";
            // 
            // panelProx
            // 
            this.panelProx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelProx.Location = new System.Drawing.Point(439, 242);
            this.panelProx.Name = "panelProx";
            this.panelProx.Size = new System.Drawing.Size(170, 170);
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
            this.buttonNJ.Click += new System.EventHandler(this.ButtonNJ_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Enabled = false;
            this.buttonPause.Location = new System.Drawing.Point(557, 578);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(112, 34);
            this.buttonPause.TabIndex = 9;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.ButtonPause_Click);
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
            // buttonTGD
            // 
            this.buttonTGD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTGD.Location = new System.Drawing.Point(878, 663);
            this.buttonTGD.Name = "buttonTGD";
            this.buttonTGD.Size = new System.Drawing.Size(112, 34);
            this.buttonTGD.TabIndex = 13;
            this.buttonTGD.Text = "TGD 2021";
            this.buttonTGD.UseVisualStyleBackColor = true;
            this.buttonTGD.Click += new System.EventHandler(this.ButtonTGD_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(676, 577);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(112, 34);
            this.buttonPrint.TabIndex = 20;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // buttonPontuacao
            // 
            this.buttonPontuacao.Location = new System.Drawing.Point(795, 577);
            this.buttonPontuacao.Name = "buttonPontuacao";
            this.buttonPontuacao.Size = new System.Drawing.Size(112, 34);
            this.buttonPontuacao.TabIndex = 25;
            this.buttonPontuacao.Text = "Pontuação";
            this.buttonPontuacao.UseVisualStyleBackColor = true;
            this.buttonPontuacao.Visible = false;
            this.buttonPontuacao.Click += new System.EventHandler(this.ButtonPontuacao_Click);
            // 
            // trackBarNivel
            // 
            this.trackBarNivel.Location = new System.Drawing.Point(439, 418);
            this.trackBarNivel.Maximum = 20;
            this.trackBarNivel.Name = "trackBarNivel";
            this.trackBarNivel.Size = new System.Drawing.Size(551, 69);
            this.trackBarNivel.TabIndex = 26;
            this.trackBarNivel.ValueChanged += new System.EventHandler(this.TrackBarNivel_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(440, 494);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 25);
            this.label9.TabIndex = 27;
            this.label9.Text = "Nível Inicial";
            // 
            // labelTBNivel
            // 
            this.labelTBNivel.AutoSize = true;
            this.labelTBNivel.Location = new System.Drawing.Point(547, 494);
            this.labelTBNivel.Name = "labelTBNivel";
            this.labelTBNivel.Size = new System.Drawing.Size(22, 25);
            this.labelTBNivel.TabIndex = 28;
            this.labelTBNivel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 712);
            this.Controls.Add(this.labelTBNivel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trackBarNivel);
            this.Controls.Add(this.buttonPontuacao);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonTGD);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonNJ);
            this.Controls.Add(this.panelProx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelAtual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelTabuleiro);
            this.Controls.Add(this.label1);
            this.Controls.Add(pausePlaceHolderPanel);
            this.Controls.Add(scorePlaceHolderPanel);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Form1";
            this.Text = "Tetris";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNivel)).EndInit();
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
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Button buttonTGD;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonPontuacao;
        private System.Windows.Forms.TrackBar trackBarNivel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelTBNivel;
        public System.Windows.Forms.Panel pausePlaceHolderPanel { get; set; }
        public System.Windows.Forms.Panel scorePlaceHolderPanel { get; set; }
    }
}

