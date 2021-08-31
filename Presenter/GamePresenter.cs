using Desafio___Tetris.Colisao;
using Desafio___Tetris.Model;
using Desafio___Tetris.Model.Pecas;
using Desafio___Tetris.View;
using System;
using System.Collections.Generic;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace Desafio___Tetris.Presenter
{
    class GamePresenter
    {
        private int Ytab { get; set; }   // coordenada y do tabuleiro
        private int Xtab { get; set; }   // coordenada x do tabuleiro
        private int Yoffset { get; set; }
        private BoardPresenter BoardPresenter { get; set; }
        public GameView GameView { get; set; }
        private PausePresenter PausePresenter { get; }
        private PiecePresenter CurrentPiecePresenter { get; }
        private PiecePresenter NextPiecePresenter { get; }
        private ScorePresenter ScorePresenter { get; set; }
        private Board Board { get { return BoardPresenter.Board; } set { BoardPresenter.Board = value; } }
        private Score Score { get { return ScorePresenter.Score; } set { ScorePresenter.Score = value; } }
        public Piece CurrentPiece
        {
            get => CurrentPiecePresenter.Piece;
            set => CurrentPiecePresenter.Piece = value;
        }
        public Piece NextPiece
        {
            get => NextPiecePresenter.Piece;
            set => NextPiecePresenter.Piece = value;
        }
        public bool Over
        {
            get => PausePresenter.Over;
            set => PausePresenter.Over = value;
        }
        private Timer TimerJogo { get; }
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
            ScorePresenter.TimeSpan = PausePresenter.Stopwatch.Elapsed;
        }
        public bool Paused
        {
            get => PausePresenter.Paused;
            set => PausePresenter.Paused = value;
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
        public Game Game { get; set; }
        public GamePresenter(Board board, int startLevel)
        {
            this.PausePresenter = new PausePresenter();
            this.BoardPresenter = new BoardPresenter();
            this.Board = board;
            this.ScorePresenter = new ScorePresenter(startLevel);
            this.CurrentPiecePresenter = new PiecePresenter();
            //currentPiecePanel
            this.NextPiecePresenter = new PiecePresenter();
            //nextPiecePanel

            this.TimerJogo.Tick += this.TimerJogo_Tick;
            this.AcionaRelogio();
        }
        public void RotacionaPeca()
        {
            int ulAnt = CurrentPiece.LineCount - 1;
            int ucAnt = CurrentPiece.ColumnCount(ulAnt);
            int rotAnt = CurrentPiece.Rot;
            BoardPresenter.LimpaPeca(CurrentPiece, Ytab + Yoffset, Xtab); // precisa limpar o espaço da peça antes de rotacionar
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
            if (Xtab + ucPos >= Board.ColumnCount)
            {
                //Direita = new ColisaoX(Tabuleiro, At, Ytab + Yoffset, Xtab, Xtab - ucPos - ucAnt); //detectar colisão uma linha abaixo?
                ColisaoX direita = new ColisaoX(Board, CurrentPiece, Ytab + Yoffset, Xtab, Xtab - ucPos + ucAnt);
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
            BoardPresenter.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);
        }
        public void MoveAbaixo()
        {
            if ((Ytab + Yoffset) < Board.LineCount - 1)
            {
                BoardPresenter.LimpaPeca(CurrentPiece, Ytab + Yoffset, Xtab);
                ColisaoY baixo = new ColisaoY(Board, CurrentPiece, Ytab + Yoffset, Ytab + Yoffset + 1, Xtab);

                if (baixo.Ycoli == -1)//não houve colisão
                {
                    Yoffset++;
                }
                BoardPresenter.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);
            }
        }
        public void MoveEsquerda()
        {
            if (Xtab > 0)
            {
                /* Colisão X não vai limpar a peça 
             * precisa limpar para fazer o teste 
             */
                BoardPresenter.LimpaPeca(CurrentPiece, Ytab + Yoffset, Xtab);
                ColisaoX esquerda = new ColisaoX(Board, CurrentPiece, Ytab + Yoffset, Xtab, Xtab - 1);

                if (esquerda.Xcoli == -1)//não houve colisão
                {
                    Xtab--;
                }
                BoardPresenter.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);
            }
        }
        public void MoveDireita()
        {
            int ul = CurrentPiece.LineCount - 1;
            int uc = CurrentPiece.ColumnCount(ul);

            if (Xtab + uc < Board.ColumnCount)
            {
                /* Colisão X não vai limpar a peça 
             *  precisa limpar para fazer o teste 
             */
                BoardPresenter.LimpaPeca(CurrentPiece, Ytab + Yoffset, Xtab);
                ColisaoX direita = new ColisaoX(Board, CurrentPiece, Ytab + Yoffset, Xtab, Xtab + uc);

                if (direita.Xcoli == -1)//não houve colisão
                {
                    Xtab++;
                }
                BoardPresenter.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);
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

            Xtab = (Board.ColumnCount - CurrentPiece.ColumnCount(CurrentPiece.LineCount - 1)) / 2; // Centraliza a peça
            Atualiza();
            Score.PieceCount++;

            for (Ytab = 0; ((Ytab + Yoffset) < Board.LineCount) && !Over; Ytab++) // percorre as linhas do tabuleiro. precisa testar a colisão a cada entrada no loop
            {
                /*
             * NO LOOP PRINCIPAL, O PONTO DE COLISÃO É O PRÓPRIO PONTO A SER DESENHADO
             * NO CASO DE SETA ABAIXO, O YTAB FOI INCREMENTADO FORA DO LOOP
             *
             * CASO DO LOOP FOR:
             * PEÇA JÁ ESTÁ DESENHADA NA LINHA ANTERIOR, PODE IR PARA A ATUAL?
             */
                BoardPresenter.LimpaPeca(CurrentPiece, Ytab - 1 + Yoffset, Xtab); //precisa limpar A ANTERIOR para fazer o teste
                ColisaoY colisaoY = new ColisaoY(Board, CurrentPiece, Ytab + Yoffset, Ytab + Yoffset, Xtab);

                if (colisaoY.Ycoli == -1)//não houve colisão
                {
                    BoardPresenter.LimpaPeca(CurrentPiece, Ytab + Yoffset - 1, Xtab);
                    BoardPresenter.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);

                }
                else
                {
                    BoardPresenter.LimpaPeca(CurrentPiece, Ytab + Yoffset - 1, Xtab);
                    BoardPresenter.DesenhaY(CurrentPiece, Ytab + Yoffset - 1, Xtab);
                    if (colisaoY.Ycoli < CurrentPiece.LineCount - 1)
                    {
                        this.Over = true;
                        this.ParaRelogio();
                    }
                    break;
                }
                PausePresenter.Wait((int)Score.Speed);
            }
            //return false;
        }
        public void Atualiza()
        {
            List<int> indices = new List<int>();
            List<List<int>> vetlin = new List<List<int>>();

            for (int j = 0; j < Board.LineCount; j++)
            {
                List<int> vetcol = new List<int>();
                for (int i = 0; i < Board.ColumnCount; i++)
                {
                    vetcol.Add(Board.Matrix[j][i].Valor);
                }
                vetlin.Add(vetcol);
                if (!vetlin[j].Contains(0))
                {
                    indices.Add(j);
                }
            }

            foreach (int t in indices)
            {
                BoardPresenter.Deleta(t);

                ScorePresenter.Points += 10;
                //ScoreView.Score = Score.Points;

                Thread.Sleep((int)Score.Times[Score.Level]);
            }

            if (indices.Count > 0)
            {
                ScorePresenter.Level = Game.StartLevel + ((int)Score.Points / 100);
                if (ScorePresenter.Level < Score.Times.Length)
                {
                    ScorePresenter.Speed = Score.Times[Score.Level];
                }
            }
        }
    }
}
