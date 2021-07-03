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
            //TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            //Tela tel = new Tela(tableLayoutPanel);
            Tela tt = new Tela(panelTabuleiro);
            Tela ta = new Tela(panelAtual);
            Tela tp = new Tela(panelProx);
            Tabuleiro tab = new Tabuleiro(tt);
            
            new Jogo(tab, ta, tp);

        }

        private void panelAtual_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
