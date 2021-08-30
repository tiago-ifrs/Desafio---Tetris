using Desafio___Tetris.Colisao;
using Desafio___Tetris.Model;
using Desafio___Tetris.Model.Pecas;
using Desafio___Tetris.Presenter;
using Desafio___Tetris.View;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public class Game
    {
        private int Ytab { get; set; }   // coordenada y do tabuleiro
        private int Xtab { get; set; }   // coordenada x do tabuleiro
        private Timer Timer {
            get => ScorePresenter.Timer;
            set => ScorePresenter.Timer = value;
        }
        private ScorePresenter ScorePresenter { get; set; }
        
        public Piece CurrentPiece
        {
            get => GamePresenter.CurrentPiece;
            set => GamePresenter.CurrentPiece = value;
        }
        public Piece NextPiece
        {
            get => GamePresenter.NextPiece;
            set => GamePresenter.NextPiece = value;
        }

        private Score Score { get; set; }
        private Board Board{ get; set; }
        private int Yoffset { get; set; }
        
        private GamePresenter GamePresenter { get; set; }

        internal GameView GameView
        {
            get => GamePresenter.GameView;
            set => GamePresenter.GameView = value;
        }
        
        public bool Over
        {
            get => GamePresenter.Over;
            set => GamePresenter.Over = value;
        }
        public bool Paused
        {
            get => GamePresenter.Paused;
            set => GamePresenter.Paused = value;
        }
        public int StartLevel { get; set; }
        public Game()
        {
            this.Over = false;

            this.Timer = new Timer();
            this.Board = new Board();
            this.Score = new Score();
            this.GamePresenter = new GamePresenter(Board, StartLevel);
            
            this.CurrentPiece = new Piece();
            this.NextPiece = null;
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
            BoardPresenter.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);
        }
        public void MoveAbaixo()
        {
            if ((Ytab + Yoffset) < Board.LineCount - 1)
            {
                BoardPresenter.LimpaPeca(CurrentPiece, Ytab + Yoffset, Xtab);
                ColisaoY baixo = new ColisaoY(Tabuleiro, CurrentPiece, Ytab + Yoffset, Ytab + Yoffset + 1, Xtab);

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
                ColisaoX esquerda = new ColisaoX(Tabuleiro, CurrentPiece, Ytab + Yoffset, Xtab, Xtab - 1);

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
                ColisaoX direita = new ColisaoX(Tabuleiro, CurrentPiece, Ytab + Yoffset, Xtab, Xtab + uc);

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
            Placar.Atualiza();
            Placar.QtdPecas++;

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
                ColisaoY colisaoY = new ColisaoY(Tabuleiro, CurrentPiece, Ytab + Yoffset, Ytab + Yoffset, Xtab);

                if (colisaoY.Ycoli == -1)//não houve colisão
                {
                    BoardPresenter.LimpaPeca(CurrentPiece, Ytab + Yoffset - 1, Xtab);
                    BoardPresenter.DesenhaY(CurrentPiece, Ytab + Yoffset, Xtab);

                } 
                else
                {
                    BoardPresenter.LimpaPeca(CurrentPiece, Ytab + Yoffset - 1, Xtab);
                    BoardPresenter.DesenhaY(CurrentPiece, Ytab + Yoffset - 1, Xtab);
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
