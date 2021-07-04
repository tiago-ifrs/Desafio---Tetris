using System;
using System.Drawing;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void LayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panelAtual_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void buttonNJ_Click(object sender, EventArgs e)
        {
            Tabuleiro tab = new Tabuleiro(panelTabuleiro);
            new Jogo(tab, panelAtual, panelProx);
        }
    }
}
