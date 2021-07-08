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
                    tabuleiro.PoePeca(at, ytab-1, xtab);
                    return true;
                case (Keys.Down):
                    labelKey.Text = Char.ToString((char)0xe2);
                    if (xtab < tabuleiro.nlin - at.QLinhas) 
                    {
                        tabuleiro.LimpaPeca(at, ytab, xtab);//limpa o espaço da peça antes de alterar a variável
                        ytab++;
                        tabuleiro.PoePeca(at, ytab-1, xtab);
                        /*
                        tabuleiro.LimpaAcima(at, ytab, ytab);
                        tabuleiro.MoveY(at, ytab, xtab);
                        */
                    }
                    return true;
                case (Keys.Left):
                    labelKey.Text = Char.ToString((char)0xdf);
                    if (xtab > 0)
                    {
                        tabuleiro.LimpaPeca(at, ytab, xtab);//limpa o espaço da peça antes de alterar a variável
                        xtab--;
                        //tabuleiro.DireitaLimpa(at, ytab, xtab);
                        //tabuleiro.XMove(at, ytab - 1, xtab);
                        
                        tabuleiro.PoePeca(at, ytab - 1, xtab);
                        
                    }
                    return true;
                case (Keys.Right):
                    labelKey.Text = Char.ToString((char)0xe0);
                    if (xtab < tabuleiro.ncol - at.QColunas(at.QLinhas - 1))
                    {
                        tabuleiro.LimpaPeca(at, ytab, xtab);//limpa o espaço da peça antes de alterar a variável
                        xtab++;
                        //tabuleiro.EsquerdaLimpa(at, ytab, xtab);
                        //tabuleiro.XMove(at, ytab - 1, xtab);
                        
                        tabuleiro.PoePeca(at, ytab - 1, xtab);
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

            while (!over)
            {
                if (pecaNova)
                {
                    GeraProx();
                    xtab = tabuleiro.ncol/2; // coordenada x inicial da queda de peças
                    pecaNova = false;
                }
                bool colisao = false;

                for (ytab = 0; ytab < tabuleiro.nlin; ytab++) // percorre as linhas do tabuleiro
                {
                    if (!colisao)
                    {
                        Wait(1000);
                        while (pause)
                        {
                            Wait(1000);
                        }
                        if (ytab < at.QLinhas)
                        {
                            if (!tabuleiro.PoePeca(at, ytab, xtab))
                            {
                                over = true;
                            }
                        }
                        else
                        {
                            if (!over)
                            {
                                if (ytab < tabuleiro.nlin) //variável ytab pode ser incrementada nas funções de teclado
                                {
                                    if (!tabuleiro.MoveY(at, ytab, xtab))
                                    {
                                        //colisão, parar o movimento
                                        colisao = true;
                                    }
                                }
                            }
                        }
                    }//if !colisao 
                    pecaNova = true;
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






