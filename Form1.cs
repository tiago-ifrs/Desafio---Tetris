using System;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public partial class Form1 : Form
    {
        private Peca at;
        private Peca prox;

        private Tabuleiro tabuleiro;
        private Panel janelaAtual;
        private Panel janelaProx;
        private Placar Placar;

        private int ytab;   // coordenada y do tabuleiro
        private int xtab;   // coordenada x do tabuleiro
        private bool pause = false;
        private void GeraProx()
        {
            if (this.prox != null)
            {
                this.prox.ap = janelaAtual;
                this.at = this.prox;
                at.AtualizaPeca();
            }
            this.prox = new Peca(tabuleiro, janelaProx);
        }
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
                Wait(1000);
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Up):
                    labelKey.Text = Char.ToString((char)0xe1);
                    tabuleiro.LimpaPeca(at, ytab, xtab); // precisa limpar o espaço da peça antes de rotacionar
                    if (at.Rot < 4)
                    {
                        at.Rot++;
                    }
                    else
                    {
                        at.Rot = 0;
                    }
                    tabuleiro.MoveY(at, ytab, xtab);
                    return true;
                case (Keys.Down):
                    labelKey.Text = Char.ToString((char)0xe2);
                    if (ytab < tabuleiro.nlin-at.QLinhas)
                    {
                        tabuleiro.LimpaPeca(at, ytab, xtab);//limpa o espaço da peça antes de alterar a variável
                        ytab++;
                        tabuleiro.MoveY(at, ytab, xtab); //verificar valor de ytab antes de mandar o parâmetro
                    }
                    return true;
                case (Keys.Left):
                    labelKey.Text = Char.ToString((char)0xdf);
                    if (xtab > 0)
                    {
                        tabuleiro.LimpaPeca(at, ytab, xtab);//limpa o espaço da peça antes de alterar a variável
                        xtab--;
                        tabuleiro.MoveY(at, ytab, xtab); //verificar valor de ytab antes de mandar o parâmetro
                    }
                    return true;
                case (Keys.Right):
                    labelKey.Text = Char.ToString((char)0xe0);
                    if (xtab < tabuleiro.ncol - at.QColunas(at.QLinhas - 1))
                    {
                        tabuleiro.LimpaPeca(at, ytab, xtab);//limpa o espaço da peça antes de alterar a variável
                        xtab++;
                        tabuleiro.MoveY(at, ytab, xtab); //verificar valor de ytab antes de mandar o parâmetro
                    }
                    return true;
            };
            // return the key to the base class if not used.
            //return base.ProcessDialogKey(keyData);
            return true;
        }

        public void Tetris(Panel janelaTabuleiro, Panel janelaAtual, Panel janelaProx, Label placar)
        {
            this.tabuleiro = new Tabuleiro(janelaTabuleiro);
            this.janelaAtual = janelaAtual;
            this.janelaProx = janelaProx;

            this.Placar = new Placar(placar, tabuleiro);
            
            this.at = new Peca(tabuleiro, janelaAtual);
            this.prox = null;

            //condições iniciais:
            bool over = false;
            

            while (!over)
            {
                GeraProx();
                xtab = tabuleiro.ncol / 2; // coordenada x inicial da queda de peças
                bool colisaoY = false;
                for (ytab = 0; ytab < tabuleiro.nlin && colisaoY==false; ytab++) // percorre as linhas do tabuleiro
                {
                    colisaoY = tabuleiro.ColisaoY(at, ytab, xtab);
                    if (!colisaoY)
                    {
                        tabuleiro.LimpaPeca(at, ytab-1, xtab);
                        tabuleiro.MoveY(at, ytab, xtab);                        
                    }//if !colisaoY
                    else
                    {
                        tabuleiro.MoveY(at, ytab-1, xtab);
                        
                        Placar.Atualiza(at, ytab);
                        if (ytab == 0) // colisão na 1ª linha
                        {
                            over = true;
                        }
                    }
                    Wait(1000);
                }//for ytab
            }//while !over
            MessageBox.Show("Game Over");
        } //construtor
        private void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
                Application.DoEvents();
        }
    }
}






