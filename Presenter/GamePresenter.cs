using System;
using System.Windows.Forms;
using Desafio___Tetris.Model;
using Desafio___Tetris.Model.Pecas;
using Desafio___Tetris.View;

namespace Desafio___Tetris.Presenter
{
    class GamePresenter
    {
        private BoardPresenter BoardPresenter { get; set; }
        public GameView GameView { get; set; }
        private PausePresenter PausePresenter { get; }
        private PiecePresenter CurrentPiecePresenter { get; }
        private PiecePresenter NextPiecePresenter { get; }
        private ScorePresenter ScorePresenter { get; set; }
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
        public GamePresenter(Board board, int startLevel)
        {
            this.PausePresenter = new PausePresenter();
            this.BoardPresenter = new BoardPresenter
            {
                Board = board
            };
            this.ScorePresenter = new ScorePresenter(startLevel);
            this.CurrentPiecePresenter = new PiecePresenter(currentPiecePanel);
            this.NextPiecePresenter = new PiecePresenter(nextPiecePanel);

            this.TimerJogo.Tick += this.TimerJogo_Tick;
            this.AcionaRelogio();
        }
    }
}
