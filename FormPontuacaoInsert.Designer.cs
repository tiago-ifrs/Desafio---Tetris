
namespace Desafio___Tetris
{
    partial class FormPontuacaoInsert
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancela = new System.Windows.Forms.Button();
            this.pictureBoxTabuleiro = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTabuleiro)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(12, 367);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(232, 31);
            this.textBoxNome.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 404);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(112, 34);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // buttonCancela
            // 
            this.buttonCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancela.Location = new System.Drawing.Point(130, 404);
            this.buttonCancela.Name = "buttonCancela";
            this.buttonCancela.Size = new System.Drawing.Size(112, 34);
            this.buttonCancela.TabIndex = 3;
            this.buttonCancela.Text = "Cancela";
            this.buttonCancela.UseVisualStyleBackColor = true;
            this.buttonCancela.Click += new System.EventHandler(this.ButtonCancela_Click);
            // 
            // pictureBoxTabuleiro
            // 
            this.pictureBoxTabuleiro.Location = new System.Drawing.Point(12, 13);
            this.pictureBoxTabuleiro.Name = "pictureBoxTabuleiro";
            this.pictureBoxTabuleiro.Size = new System.Drawing.Size(232, 323);
            this.pictureBoxTabuleiro.TabIndex = 4;
            this.pictureBoxTabuleiro.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(251, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 150);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // FormPontuacaoInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBoxTabuleiro);
            this.Controls.Add(this.buttonCancela);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPontuacaoInsert";
            this.Text = "Salvar Pontuação";
            this.Load += new System.EventHandler(this.FormPontuacaoInsert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTabuleiro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancela;
        private System.Windows.Forms.PictureBox pictureBoxTabuleiro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}