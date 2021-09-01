using System.Windows.Forms;
using Desafio___Tetris.Presenter;

namespace Desafio___Tetris.View
{
    internal class GameView
    {
        internal GamePresenter GamePresenter { get; set; }
        internal TimePresenter TimePresenter { get; set; }
        internal TrackBar TrackBar { get; init; }
        internal BoardView BoardView { get; init; }
        internal TimeView TimeView { get; init; }
        internal PieceView PieceView { get; init; }
        internal ScoreView ScoreView { get; init; }
        public GameView()
        {
            
        }
        public void Start()
        {
            GamePresenter = new GamePresenter
            {
                GameView = this
            };
        }
        public void Pause() 
        {
            TimePresenter.Pause();
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
        
    }
}
