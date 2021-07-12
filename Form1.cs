using System;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public partial class Form1 : Form
    {
        private Jogo Jogo { get; set; }
        private bool pause { get; set; }

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
            this.pause = false;
            Tetris(panelTabuleiro, panelAtual, panelProx, labelPlacar);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (pause == false)
            {
                labelPause.Text = "PAUSE";
                //labelPause.Visible = true;
                pause = true;
            }
            else
            {
                //labelPause.Visible = false;
                labelPause.Text = "Tetris";
                pause = false;
            }
            labelPause.Refresh();
            while (pause) 
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

        public void Tetris(Panel janelaTabuleiro, Panel janelaAtual, Panel janelaProx, Label lbplacar)
        {           
            Tabuleiro tabuleiro = Tabuleiro.GetInstance(janelaTabuleiro);
            tabuleiro.Inicia();
            
            this.Jogo = new Jogo(tabuleiro, janelaAtual, janelaProx, lbplacar);

            bool over = false;
            Jogo.At = new Peca(tabuleiro, janelaAtual);
            Jogo.Prox = null;
            while (!over)
            {    
                over = Jogo.Percorre();   
            }
            MessageBox.Show("Game Over");
        } 
    }
}






