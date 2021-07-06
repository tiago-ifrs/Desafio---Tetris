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
            Tetris(panelTabuleiro, panelAtual, panelProx);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (pause == false)
            {
                labelPause.Text = "PAUSE";
                labelPause.Visible = true;
                pause = true;
            }
            else
            {
                labelPause.Visible = false;
                labelPause.Text = "Tetris";
                pause = false;
            }
            labelPause.Refresh();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Up):
                    labelKey.Text = Char.ToString((char)0xe1);
                    return true;
                case (Keys.Down):
                    labelKey.Text = Char.ToString((char)0xe2);
                    return true;
                case (Keys.Left):
                    labelKey.Text = Char.ToString((char)0xdf);
                    return true;
                case (Keys.Right):
                    labelKey.Text = Char.ToString((char)0xe0);
                    if (xtab < tabuleiro.ncol)
                    {
                        xtab++;
                    }
                    return true;
            };
            // return the key to the base class if not used.
            //return base.ProcessDialogKey(keyData);
            return true;
        }

        public void Tetris(Panel janelaTabuleiro, Panel janelaAtual, Panel janelaProx)
        {
            this.tabuleiro = new Tabuleiro(janelaTabuleiro);
            this.janelaAtual = janelaAtual;
            this.janelaProx = janelaProx;

            this.at = new Peca(tabuleiro, janelaAtual);
            this.prox = null;

            //condições iniciais:
            bool over = false;
            bool pecaNova = true;

            int ypec = -1;
            int ul = -1;
            while (!over)
            {
                if (pecaNova)
                {
                    GeraProx();
                    pecaNova = false;
                }
                //atualiza o índice de peça após a geração de cada peça nova ou em condição inicial:
                ul = at.QLinhas - 1;
                ypec = ul;

                //condições atualizadas a cada nova peça
                bool colisaoX = false;
                bool colisaoY = false;
                bool tabXLivre = true;
                // bool terminaPeca = false;

                for (ytab = 0; ytab < tabuleiro.nlin - 1; ytab++) // percorre as linhas do tabuleiro
                {
                    if (!over)
                    {
                        while (pause)
                        {
                            Wait(1000);
                        }
                        if (tabXLivre == true) // os espaços inferiores estão vazios, peça cai
                        {
                            if (ypec >= 0)
                            {
                                tabuleiro.PoePeca(at, ypec);
                                ypec--;
                            }
                            else //ypec == -1
                            {
                                if (!pecaNova)
                                {
                                    //tabuleiro.PoePeca(at, ytab, ypec);
                                    //tabuleiro.TerminaPeca(at);
                                    pecaNova = true;
                                }
                            }
                            if (!colisaoY)
                            {
                                //for (int xtab = 0; xtab < at.QColunas(ul); xtab++)        // percorre as colunas do tabuleiro abaixo da peça
                                for (int xpec = 0; xpec < at.QColunas(ul); xpec++)        // percorre as colunas do tabuleiro abaixo da peça
                                {
                                    if (!colisaoY)
                                    {
                                        if (tabuleiro.Matrix[ytab + 1][xtab].Valor == 0) //local vazio no tabuleiro
                                        {
                                            colisaoY = false; //não há colisão
                                            tabXLivre = true; // posição livre
                                        }
                                        else // local ocupado no tabuleiro
                                        {
                                            tabXLivre = false;  // posição ocupada
                                                                // pode haver colisão se a peça for 1
                                            if (at.Ponto(ul, xpec) == 1) // peça está ocupando posição x
                                            {
                                                colisaoY = true;
                                                //empilhar peças
                                            }
                                        } //else local ocupado no tabuleiro			
                                    }
                                } //for xpec
                                if (!colisaoY)
                                {
                                    tabuleiro.MoveY(at, ytab, xtab);
                                    if (ypec == -1)
                                    {
                                        tabuleiro.LimpaAcima(at);
                                    }
                                    //Thread.Sleep(1000);
                                    Wait(1000);
                                }

                            }
                        } // fim if tabXlivre
                        else
                        {
                            if (colisaoY)
                            {
                                if (ytab < this.prox.QLinhas)
                                {
                                    MessageBox.Show("Game Over");
                                    over = true;
                                }
                            }
                        }
                    }//if !over
                } //for ytab

            }//while !over
        } //construtor
        private void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
                Application.DoEvents();
        }
    }

}






