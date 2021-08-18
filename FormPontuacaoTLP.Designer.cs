
namespace Desafio___Tetris
{
    partial class FormPontuacaoTlp
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scoreCaptionLabel = new System.Windows.Forms.Label();
            this.levelCaptionLabel = new System.Windows.Forms.Label();
            this.gameTimerCaptionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.scoreCaptionLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.levelCaptionLabel, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.gameTimerCaptionLabel, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(443, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nível";
            // 
            // scoreCaptionLabel
            // 
            this.scoreCaptionLabel.AutoSize = true;
            this.scoreCaptionLabel.Location = new System.Drawing.Point(189, 0);
            this.scoreCaptionLabel.Name = "scoreCaptionLabel";
            this.scoreCaptionLabel.Size = new System.Drawing.Size(135, 25);
            this.scoreCaptionLabel.TabIndex = 3;
            this.scoreCaptionLabel.Text = "Tempo de Jogo";
            // 
            // levelCaptionLabel
            // 
            this.levelCaptionLabel.AutoSize = true;
            this.levelCaptionLabel.Location = new System.Drawing.Point(330, 0);
            this.levelCaptionLabel.Name = "levelCaptionLabel";
            this.levelCaptionLabel.Size = new System.Drawing.Size(55, 25);
            this.levelCaptionLabel.TabIndex = 4;
            this.levelCaptionLabel.Text = "Peças";
            // 
            // gameTimerCaptionLabel
            // 
            this.gameTimerCaptionLabel.AutoSize = true;
            this.gameTimerCaptionLabel.Location = new System.Drawing.Point(391, 0);
            this.gameTimerCaptionLabel.Name = "gameTimerCaptionLabel";
            this.gameTimerCaptionLabel.Size = new System.Drawing.Size(49, 25);
            this.gameTimerCaptionLabel.TabIndex = 5;
            this.gameTimerCaptionLabel.Text = "Data";
            // 
            // FormPontuacaoTLP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormPontuacaoTlp";
            this.Text = "Pontuação";
            this.Load += new System.EventHandler(this.FormPontuacaoTLP_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label scoreCaptionLabel;
        private System.Windows.Forms.Label levelCaptionLabel;
        private System.Windows.Forms.Label gameTimerCaptionLabel;
    }
}