using System;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public partial class Form1 : Form
    {
        private Jogo Jogo { get; set; }
        private bool Pause { get; set; }
        private Tabuleiro Tabuleiro { get; set; }
        public Form1()
        {
            InitializeComponent();
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
            this.Pause = false;
            Tetris();
        }
        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (Pause == false)
            {
                //labelPause.Text = "PAUSE";
                labelPause.Text = Char.ToString((char)0x3b);
                //labelPause.Visible = true;
                Pause = true;
            }
            else
            {
                //labelPause.Visible = false;
                //labelPause.Text = "Tetris";
                labelPause.Text = Char.ToString((char)0x34);
                Pause = false;
            }
            labelPause.Refresh();
            while (Pause) 
            {
                Jogo.Espera();
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Up):
                    labelKey.Text = Char.ToString((char)0xe1);
                    Jogo.RotacionaPeca();
                    
                    return true;
                case (Keys.Down):
                    labelKey.Text = Char.ToString((char)0xe2);
                    Jogo.MoveAbaixo();
                    
                    return true;
                case (Keys.Left):
                    labelKey.Text = Char.ToString((char)0xdf);
                    Jogo.MoveEsquerda();

                    return true;
                case (Keys.Right):
                    labelKey.Text = Char.ToString((char)0xe0);
                    Jogo.MoveDireita();
                                        
                    return true;
            };
            // return the key to the base class if not used.
            //return base.ProcessDialogKey(keyData);
            return true;
        }
        public void Tetris()
        {           
            this.Tabuleiro = Tabuleiro.GetInstance(panelTabuleiro);
            this.Tabuleiro.Inicia();
            
            this.Jogo = new Jogo(Tabuleiro, labelPlacar);

            bool over = false;
            Jogo.At = new Peca(Tabuleiro, panelAtual);
            Jogo.Prox = null;
            while (!over)
            {
                GeraProx();
                over = Jogo.Percorre();   
            }
            MessageBox.Show("Game Over");
        }
        private void GeraProx()
        {
            if (Jogo.Prox != null)
            {
                Jogo.Prox.ap = panelAtual;
                Jogo.At = Jogo.Prox;
                Jogo.At.AtualizaPeca();
            }
            Jogo.Prox = new Peca(Tabuleiro, panelProx);
        }
    }
}






