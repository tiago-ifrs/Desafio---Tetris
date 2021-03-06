using Desafio___Tetris.Colisao;
using Desafio___Tetris.Model;
using Desafio___Tetris.Model.Pecas;
using Desafio___Tetris.View;
using System.Collections.Generic;
using System.Threading;

namespace Desafio___Tetris.Presenter
{
    internal class GamePresenter
    {
        private int Ytab { get; set; }   // coordenada y do tabuleiro
        private int Xtab { get; set; }   // coordenada x do tabuleiro
        private int Yoffset { get; set; }
        public bool Over { get; set; }
        private BoardPresenter BoardPresenter { get; set; }
        public GameView _GameView { get; set; }
        public GameView GameView
        {
            get => _GameView;
            set
            {
                _GameView = value;
                this.Game = new Game
                {
                    //GamePresenter = this,
                    StartLevel = _GameView.TrackBar.Value
                };
                BoardPresenter = new BoardPresenter
                {
                    Board = Game.Board,
                    BoardView = GameView.BoardView
                };
                BoardPresenter.Inicia();
                ScorePresenter = new ScorePresenter
                {
                    Score = Game.Score, //Score must be set first
                    ScoreView = GameView.ScoreView
                };
                TimePresenter = new TimePresenter
                {
                    TimeView = GameView.TimeView, //TimeView must be set first
                    Time = Game.Time
                };
                GameView.GamePresenter = this;
                GameView.TimePresenter = TimePresenter;
                CurrentPiecePresenter = new PiecePresenter
                {
                    Width = BoardPresenter.Width,
                    Height = BoardPresenter.Height,
                    Piece = Game.CurrentPiece,
                    PieceView = GameView.CurrentPieceView

                };
                NextPiecePresenter = new PiecePresenter
                {
                    Width = BoardPresenter.Width,
                    Height = BoardPresenter.Height,
                    Piece = Game.NextPiece,
                    PieceView = GameView.NextPieceView
                };

                while (!Over)
                {
                    Percorre();
                }
            }
        }
        private TimePresenter TimePresenter { get; set; }
        private PiecePresenter CurrentPiecePresenter { get; set; }
        private PiecePresenter NextPiecePresenter { get; set; }
        private ScorePresenter ScorePresenter { get; set; }
        internal Game Game { get; set; }

        internal GamePresenter()
        {

        }
        public void RotacionaPeca()
        {
            int ulAnt = CurrentPiecePresenter.Piece.LineCount - 1;
            int ucAnt = CurrentPiecePresenter.Piece.ColumnCount(ulAnt);
            int rotAnt = CurrentPiecePresenter.Piece.Rot;
            BoardPresenter.LimpaPeca(CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab); // precisa limpar o espaço da peça antes de rotacionar
            if (CurrentPiecePresenter.Piece.Rot < 4)
            {
                CurrentPiecePresenter.Piece.Rot++;
            }
            else
            {
                CurrentPiecePresenter.Piece.Rot = 0;
            }
            /* 
         * DETECTAR COLISÃO HORIZONTAL ANTES DE DESENHAR
         * AS COLISÕES PODEM ACONTECEM NO LADO DIREITO, POIS XTAB É O PONTO DE ORIGEM DO DESENHO DA PEÇA
         */
            int ulPos = CurrentPiecePresenter.Piece.LineCount - 1;
            int ucPos = CurrentPiecePresenter.Piece.ColumnCount(ulPos);
            if (Xtab + ucPos >= Board.ColumnCount)
            {
                //Direita = new ColisaoX(Tabuleiro, At, Ytab + Yoffset, Xtab, Xtab - ucPos - ucAnt); //detectar colisão uma linha abaixo?
                ColisaoX direita = new ColisaoX(BoardPresenter.Board, CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab, Xtab - ucPos + ucAnt);
                if (direita.Xcoli == -1)//não houve colisão
                {
                    //mantém a rotação
                    //move a peça para a esquerda
                    Xtab -= ucPos - ucAnt;
                }
                else
                {
                    CurrentPiecePresenter.Piece.Rot = rotAnt; //recupera a rotação anterior, impedindo o movimento
                }
            }
            /* DESENHA QUALQUER UMA DAS DUAS */
            BoardPresenter.DesenhaY(CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab);
        }
        public void MoveAbaixo()
        {
            if ((Ytab + Yoffset) < Board.LineCount - 1)
            {
                BoardPresenter.LimpaPeca(CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab);
                ColisaoY baixo = new ColisaoY(BoardPresenter.Board, CurrentPiecePresenter.Piece, Ytab + Yoffset, Ytab + Yoffset + 1, Xtab);

                if (baixo.Ycoli == -1)//não houve colisão
                {
                    Yoffset++;
                }
                BoardPresenter.DesenhaY(CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab);
            }
        }
        public void MoveEsquerda()
        {
            if (Xtab > 0)
            {
                /* Colisão X não vai limpar a peça 
             * precisa limpar para fazer o teste 
             */
                BoardPresenter.LimpaPeca(CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab);
                ColisaoX esquerda = new ColisaoX(BoardPresenter.Board, CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab, Xtab - 1);

                if (esquerda.Xcoli == -1)//não houve colisão
                {
                    Xtab--;
                }
                BoardPresenter.DesenhaY(CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab);
            }
        }
        public void MoveDireita()
        {
            int ul = CurrentPiecePresenter.Piece.LineCount - 1;
            int uc = CurrentPiecePresenter.Piece.ColumnCount(ul);

            if (Xtab + uc < Board.ColumnCount)
            {
                /* Colisão X não vai limpar a peça 
             *  precisa limpar para fazer o teste 
             */
                BoardPresenter.LimpaPeca(CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab);
                ColisaoX direita = new ColisaoX(BoardPresenter.Board, CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab, Xtab + uc);

                if (direita.Xcoli == -1)//não houve colisão
                {
                    Xtab++;
                }
                BoardPresenter.DesenhaY(CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab);
            }
        }
        private void GeraProx()
        {
            CurrentPiecePresenter.Piece ??= new Piece();
            if (NextPiecePresenter.Piece != null)
            {
                //NextPiece.Ap = panelAtual;
                CurrentPiecePresenter.Piece = NextPiecePresenter.Piece;
                //CurrentPiece.AtualizaPeca();
            }
            NextPiecePresenter.Piece = new Piece();
        }
        public void Percorre()
        {
            GeraProx();
            //condições iniciais:
            Yoffset = 0;

            Xtab = (Board.ColumnCount - CurrentPiecePresenter.Piece.ColumnCount(CurrentPiecePresenter.Piece.LineCount - 1)) / 2; // Centraliza a peça
            Atualiza();
            ScorePresenter.PieceCounter++;

            for (Ytab = 0; ((Ytab + Yoffset) < Board.LineCount) && !Over; Ytab++) // percorre as linhas do tabuleiro. precisa testar a colisão a cada entrada no loop
            {
                /*
             * NO LOOP PRINCIPAL, O PONTO DE COLISÃO É O PRÓPRIO PONTO A SER DESENHADO
             * NO CASO DE SETA ABAIXO, O YTAB FOI INCREMENTADO FORA DO LOOP
             *
             * CASO DO LOOP FOR:
             * PEÇA JÁ ESTÁ DESENHADA NA LINHA ANTERIOR, PODE IR PARA A ATUAL?
             */
                BoardPresenter.LimpaPeca(CurrentPiecePresenter.Piece, Ytab - 1 + Yoffset, Xtab); //precisa limpar A ANTERIOR para fazer o teste
                ColisaoY colisaoY = new ColisaoY(BoardPresenter.Board, CurrentPiecePresenter.Piece, Ytab + Yoffset, Ytab + Yoffset, Xtab);

                if (colisaoY.Ycoli == -1)//não houve colisão
                {
                    BoardPresenter.LimpaPeca(CurrentPiecePresenter.Piece, Ytab + Yoffset - 1, Xtab);
                    BoardPresenter.DesenhaY(CurrentPiecePresenter.Piece, Ytab + Yoffset, Xtab);

                }
                else
                {
                    BoardPresenter.LimpaPeca(CurrentPiecePresenter.Piece, Ytab + Yoffset - 1, Xtab);
                    BoardPresenter.DesenhaY(CurrentPiecePresenter.Piece, Ytab + Yoffset - 1, Xtab);
                    if (colisaoY.Ycoli < CurrentPiecePresenter.Piece.LineCount - 1)
                    {
                        this.Over = true;
                        TimePresenter.Over();
                    }
                    break;
                }
                Time.Wait((int)ScorePresenter.Speed);
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
                    vetcol.Add(BoardPresenter.Board.Matrix[j][i].Valor);
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

                Thread.Sleep((int)Score.Times[ScorePresenter.Level]);
            }

            if (indices.Count > 0)
            {
                ScorePresenter.Level = Game.StartLevel + ((int)ScorePresenter.Points / 100);
                if (ScorePresenter.Level < Score.Times.Length)
                {
                    ScorePresenter.Speed = Score.Times[ScorePresenter.Level];
                }
            }
        }
    }
}
