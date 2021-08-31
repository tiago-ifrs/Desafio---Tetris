using Desafio___Tetris.Model;
using Desafio___Tetris.Model.Pecas;
using Desafio___Tetris.Presenter;
using Desafio___Tetris.View;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public class Game
    {
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
        public Score Score { get; set; }
        private Board Board{ get; set; }        
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
        public void Pause() 
        {
            GamePresenter.Pause();
        }
        public void RotacionaPeca() 
        {
            GamePresenter.RotacionaPeca();
        }
        public void MoveAbaixo() 
        { 
            GamePresenter.MoveAbaixo(); 
        }
        public void MoveEsquerda()
        {
            GamePresenter.MoveEsquerda();
        }
        public void MoveDireita()
        {
            GamePresenter.MoveDireita();
        }
        public void Percorre()
        {
            GamePresenter.Percorre();
        }
        public int StartLevel { get; set; }
        public Game()
        {
            this.GamePresenter = new GamePresenter(Board, StartLevel);
            this.Over = false;

            this.Timer = new Timer();
            this.Board = new Board();
            this.Score = new Score();
            
            
            this.CurrentPiece = new Piece();
            this.NextPiece = null;
        }
    }
}
