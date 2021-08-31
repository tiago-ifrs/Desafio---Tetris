using System.Windows.Forms;
using Desafio___Tetris.Presenter;

namespace Desafio___Tetris.View
{
    internal class GameView
    {
        internal GamePresenter GamePresenter { get; set; }
        internal TimePresenter TimePresenter { get; set; }
        internal TrackBar TrackBar { get; set; }
        internal BoardView BoardView { get; set; }
        internal TimeView TimeView { get; set; }
        internal PieceView PieceView { get; set; }
        internal ScoreView ScoreView { get; set; }
        public GameView()
        {
            
        }
        public void Start()
        {
            GamePresenter = new GamePresenter
            {
                GameView = this
            };
            TimePresenter = new TimePresenter();
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
