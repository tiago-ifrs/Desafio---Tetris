using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public partial class FormPontuacaoInsert : Form
    {
        public PictureBox pictureBox { get; }
        public string nome { get; set; }
        public FormPontuacaoInsert()
        {
            InitializeComponent();
            this.pictureBox = pictureBoxTabuleiro;
        }
        public void Executa()
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.nome = textBoxNome.Text;
            //this.DialogResult = buttonOK.DialogResult;
            this.Close();
        }

        private void buttonCancela_Click(object sender, EventArgs e)
        {
            this.nome = null;
            //this.DialogResult = buttonCancela.DialogResult;
            this.Close();
        }
    }

}
