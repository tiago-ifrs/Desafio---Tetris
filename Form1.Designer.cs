
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
            this.components = new System.ComponentModel.Container();
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
            this.buttonTGD = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTimerJogo = new System.Windows.Forms.Label();
            this.timerJogo = new System.Windows.Forms.Timer(this.components);
            this.buttonPrint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.labelQtdPeca = new System.Windows.Forms.Label();
            this.labelSQL = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.panelTabuleiro.Paint += new System.Windows.Forms.PaintEventHandler(this.LayoutPanel1_Paint);
            // 
            // labelPause
            // 
            this.labelPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelPause.AutoSize = true;
            this.labelPause.BackColor = System.Drawing.Color.Transparent;
            this.labelPause.Font = new System.Drawing.Font("Webdings", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPause.Location = new System.Drawing.Point(439, 632);
            this.labelPause.Name = "labelPause";
            this.labelPause.Size = new System.Drawing.Size(87, 61);
            this.labelPause.TabIndex = 0;
            this.labelPause.Text = "<";
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
            this.panelAtual.Size = new System.Drawing.Size(170, 170);
            this.panelAtual.TabIndex = 5;
            this.panelAtual.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelAtual_Paint);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(615, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Score";
            // 
            // labelPlacar
            // 
            this.labelPlacar.AutoSize = true;
            this.labelPlacar.Location = new System.Drawing.Point(615, 41);
            this.labelPlacar.Name = "labelPlacar";
            this.labelPlacar.Size = new System.Drawing.Size(22, 25);
            this.labelPlacar.TabIndex = 12;
            this.labelPlacar.Text = "0";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(615, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Nível";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(615, 91);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(22, 25);
            this.labelLevel.TabIndex = 15;
            this.labelLevel.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(615, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Velocidade";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(615, 141);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(22, 25);
            this.labelSpeed.TabIndex = 17;
            this.labelSpeed.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(532, 632);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Tempo de Jogo";
            // 
            // labelTimerJogo
            // 
            this.labelTimerJogo.AutoSize = true;
            this.labelTimerJogo.Location = new System.Drawing.Point(532, 661);
            this.labelTimerJogo.Name = "labelTimerJogo";
            this.labelTimerJogo.Size = new System.Drawing.Size(22, 25);
            this.labelTimerJogo.TabIndex = 19;
            this.labelTimerJogo.Text = "0";
            // 
            // timerJogo
            // 
            this.timerJogo.Tick += new System.EventHandler(this.TimerJogo_Tick);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(615, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Peças";
            // 
            // labelQtdPeca
            // 
            this.labelQtdPeca.AutoSize = true;
            this.labelQtdPeca.Location = new System.Drawing.Point(615, 191);
            this.labelQtdPeca.Name = "labelQtdPeca";
            this.labelQtdPeca.Size = new System.Drawing.Size(22, 25);
            this.labelQtdPeca.TabIndex = 22;
            this.labelQtdPeca.Text = "0";
            // 
            // labelSQL
            // 
            this.labelSQL.AutoSize = true;
            this.labelSQL.Location = new System.Drawing.Point(878, 619);
            this.labelSQL.Name = "labelSQL";
            this.labelSQL.Size = new System.Drawing.Size(44, 25);
            this.labelSQL.TabIndex = 23;
            this.labelSQL.Text = "SQL";
            this.labelSQL.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 712);
            this.Controls.Add(this.labelSQL);
            this.Controls.Add(this.labelQtdPeca);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.labelTimerJogo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonTGD);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
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
        private System.Windows.Forms.Button buttonTGD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTimerJogo;
        private System.Windows.Forms.Timer timerJogo;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelQtdPeca;
        private System.Windows.Forms.Label labelSQL;
    }
}

