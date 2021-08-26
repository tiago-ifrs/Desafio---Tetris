using Desafio___Tetris.Presenter;
using System;
using System.Windows.Forms;
using Desafio___Tetris.Model.Pecas;

namespace Desafio___Tetris
{
    public class Game
    {
        private int Ytab { get; set; }   // coordenada y do tabuleiro
        private int Xtab { get; set; }   // coordenada x do tabuleiro
        public Piece CurrentPiece { get; set; }
        public Piece NextPiece { get; set; }
        public Placar Placar { get; set; }
        public Tabuleiro Tabuleiro { get; set; }
        private int Yoffset { get; set; }
        private Timer TimerJogo { get; }
        private PausePresenter PausePresenter { get; }
        private PiecePresenter CurrentPiecePresenter { get; set; }
        private PiecePresenter NextPiecePresenter { get; set; }
        public bool Over
        {
            get => PausePresenter.Over;
            set => PausePresenter.Over = value;
        }
        public void AcionaRelogio()
        {
            PausePresenter.Stopwatch.Start();
            TimerJogo.Start();
        }
        public void ParaRelogio()
        {
            PausePresenter.Stopwatch.Stop();
            TimerJogo.Stop();
        }
        internal void TimerJogo_Tick(object sender, EventArgs e)
        {
            Placar.TimeSpan = PausePresenter.Stopwatch.Elapsed;
        }
        public void Pause()
        {
            if (PausePresenter.Paused == false)
            {
                ParaRelogio();
                PausePresenter.Paused = true;
            }
            else
            {
                AcionaRelogio();
                PausePresenter.Paused = false;
            }
        }
        public Game(Tabuleiro tabuleiro, Placar placar, Control pausePlaceHolderPanel, Panel currentPiecePanel, Panel nextPiecePanel)
        {
            this.PausePresenter = new PausePresenter(pausePlaceHolderPanel);
            
            this.Over = false;

            this.TimerJogo = new Timer();
            this.TimerJogo.Tick += this.TimerJogo_Tick;

            this.Tabuleiro = tabuleiro;
            this.Placar = placar;

            this.CurrentPiece = new Piece();
            this.NextPiece = null;

            this.CurrentPiecePresenter = new PiecePresenter(currentPiecePanel)
            {
                Piece = CurrentPiece,
                Tabuleiro = tabuleiro
            };

            this.NextPiecePresenter = new PiecePresenter(nextPiecePanel)
            {
                Piece = NextPiece,
                Tabuleiro = tabuleiro
            };

            this.AcionaRelogio();
        }
        public void RotacionaPeca()
        {
            int ulAnt = CurrentPiece.LineCount - 1;
            int ucAnt = CurrentPiece.ColumnCount(ulAnt);
            int rotAnt = CurrentPiece.Rot;
            Tabuleiro.LimpaPeca(CurrentPiece, Ytab + Yoffset, Xtab); // precisa limpar o espaço da peça antes de rotacionar
            if (CurrentPiece.Rot < 4)
            {
                CurrentPiece.Rot++;
            }
            else
            {
                CurrentPiece.Rot = 0;
            }
            /* 
         * DETECTAR COLISÃO HORIZONTAL ANTES DE DESENHAR
         * AS COLISÕES PODEM ACONTECEM NO LADO DIREITO, POIS XTAB É O PONTO DE ORIGEM DO DESENHO DA PEÇA
         */
            int ulPos = CurrentPiece.LineCount - 1;
            int ucPos = CurrentPiece.ColumnCount(ulPos);
            if (Xtab + ucPos >= Tabuleiro.Ncol)
            {
                //Direita = new ColisaoX(Tabuleiro, At, Ytab + Yoffset, Xtab, Xtab - ucPos - ucAnt); //detectar colisão uma linha abaixo?
                ColisaoX direita = new ColisaoX(Tabuleiro, CurrentPiece, Ytab + Yoffset, Xtab, Xtab - ucPos + ucAnt);
                if (direita.Xcoli == -1)//não houve colisão
                {
                    //mantém a rotação
                    //move a peça para a esquerda
                    Xtab -= ucPos - ucAnt;
                }
                else
                {
                    CurrentPiece.Rot = rotAnt; //recupera a rotação anterior, impedindo o movimento
                }
            }
            /* DESENHA QUALQUER UMA DAS DUAS */
            Tabuleiro.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);
        }
        public void MoveAbaixo()
        {
            if ((Ytab + Yoffset) < Tabuleiro.Nlin - 1)
            {
                Tabuleiro.LimpaPeca(CurrentPiece, Ytab + Yoffset, Xtab);
                ColisaoY baixo = new ColisaoY(Tabuleiro, CurrentPiece, Ytab + Yoffset, Ytab + Yoffset + 1, Xtab);

                if (baixo.Ycoli == -1)//não houve colisão
                {
                    Yoffset++;
                }
                Tabuleiro.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);
            }
        }
        public void MoveEsquerda()
        {
            if (Xtab > 0)
            {
                /* Colisão X não vai limpar a peça 
             * precisa limpar para fazer o teste 
             */
                Tabuleiro.LimpaPeca(CurrentPiece, Ytab + Yoffset, Xtab);
                ColisaoX esquerda = new ColisaoX(Tabuleiro, CurrentPiece, Ytab + Yoffset, Xtab, Xtab - 1);

                if (esquerda.Xcoli == -1)//não houve colisão
                {
                    Xtab--;
                }
                Tabuleiro.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);
            }
        }
        public void MoveDireita()
        {
            int ul = CurrentPiece.LineCount - 1;
            int uc = CurrentPiece.ColumnCount(ul);

            if (Xtab + uc < Tabuleiro.Ncol)
            {
                /* Colisão X não vai limpar a peça 
             *  precisa limpar para fazer o teste 
             */
                Tabuleiro.LimpaPeca(CurrentPiece, Ytab + Yoffset, Xtab);
                ColisaoX direita = new ColisaoX(Tabuleiro, CurrentPiece, Ytab + Yoffset, Xtab, Xtab + uc);

                if (direita.Xcoli == -1)//não houve colisão
                {
                    Xtab++;
                }
                Tabuleiro.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);
            }
        }
        private void GeraProx()
        {
            if (NextPiece != null)
            {
                //NextPiece.Ap = panelAtual;
                CurrentPiece = NextPiece;
                //CurrentPiece.AtualizaPeca();
            }
            NextPiece = new Piece();
        }
        public void Percorre()
        {
            GeraProx();
            //condições iniciais:
            Yoffset = 0;

            Xtab = (Tabuleiro.Ncol - CurrentPiece.ColumnCount(CurrentPiece.LineCount - 1)) / 2; // Centraliza a peça
            Placar.Atualiza();
            Placar.QtdPecas++;

            for (Ytab = 0; (Ytab + Yoffset) < Tabuleiro.Nlin; Ytab++) // percorre as linhas do tabuleiro. precisa testar a colisão a cada entrada no loop
            {
                /*
             * NO LOOP PRINCIPAL, O PONTO DE COLISÃO É O PRÓPRIO PONTO A SER DESENHADO
             * NO CASO DE SETA ABAIXO, O YTAB FOI INCREMENTADO FORA DO LOOP
             *
             * CASO DO LOOP FOR:
             * PEÇA JÁ ESTÁ DESENHADA NA LINHA ANTERIOR, PODE IR PARA A ATUAL?
             */
                Tabuleiro.LimpaPeca(CurrentPiece, Ytab - 1 + Yoffset, Xtab); //precisa limpar A ANTERIOR para fazer o teste
                ColisaoY colisaoY = new ColisaoY(Tabuleiro, CurrentPiece, Ytab + Yoffset, Ytab + Yoffset, Xtab);

                if (colisaoY.Ycoli == -1)//não houve colisão
                {
                    Tabuleiro.LimpaPeca(CurrentPiece, Ytab + Yoffset - 1, Xtab);
                    Tabuleiro.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);

                } 
                else
                {
                    Tabuleiro.LimpaPeca(CurrentPiece, Ytab + Yoffset - 1, Xtab);
                    Tabuleiro.DesenhaY(CurrentPiece, Ytab + Yoffset - 1, Xtab);
                    if (colisaoY.Ycoli < CurrentPiece.LineCount-1)
                    {
                        this.Over = true;
                        this.ParaRelogio();
                    }
                    break;
                }
                PausePresenter.Wait((int)Placar.Velo);
            }
            //return false;
        }
    }
}
