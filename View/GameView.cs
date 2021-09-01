using System.Windows.Forms;
using Desafio___Tetris.Presenter;

namespace Desafio___Tetris.View
{
    /// <summary>
    /// GameView
    /// Must be public because it's referenced in 2 different forms
    /// </summary>
    public class GameView
    {
        internal GamePresenter GamePresenter { get; set; }
        internal TimePresenter TimePresenter { get; set; }
        internal TrackBar TrackBar { get; init; }
        internal BoardView BoardView { get; init; }
        internal TimeView TimeView { get; init; }
        internal ScoreView ScoreView { get; init; }
        internal PieceView CurrentPieceView { get; init; }
        internal PieceView NextPieceView { get; init; }
        internal void Start()
        {
            GamePresenter = new GamePresenter
            {
                GameView = this
            };
        }
        internal void Pause() 
        {
            TimePresenter.Pause();
        }
        internal void RotacionaPeca() 
        {
            GamePresenter.RotacionaPeca();
        }
        internal void MoveAbaixo() 
        { 
            GamePresenter.MoveAbaixo(); 
        }
        internal void MoveEsquerda()
        {
            GamePresenter.MoveEsquerda();
        }
        internal void MoveDireita()
        {
            GamePresenter.MoveDireita();
        }
        internal GameView()
        {
        }
    }
}