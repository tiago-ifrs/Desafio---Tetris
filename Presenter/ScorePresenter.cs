using Desafio___Tetris.Model;
using Desafio___Tetris.View;

namespace Desafio___Tetris.Presenter
{
    internal class ScorePresenter
    {
        internal Score Score { get; init; }
        internal int Points
        {
            get => Score.Points;
            set
            {
                Score.Points = value;
                ScoreView.Points = value;
            }
        }
        internal int Level
        {
            get => Score.Level;
            set
            {
                Score.Level = value;
                ScoreView.Level = value;
            }
        }
        internal double Speed
        {
            get => Score.Speed;
            set
            {
                Score.Speed = value;
                ScoreView.Speed = value;
            }
        }
        internal int PieceCounter
        {
            get => Score.PieceCounter;
            set
            {
                Score.PieceCounter = value;
                ScoreView.PieceCounter = value;
            }
        }
        private ScoreView _ScoreView { get; init; }

        internal ScoreView ScoreView
        {
            get => _ScoreView;
            init
            {
                _ScoreView = value;
                ///initialize ScoreView
                ScoreView.Level = Score.Level;
                ScoreView.Points = Score.Points;
                ScoreView.Speed = Score.Speed;
            }
        }
        internal ScorePresenter()
        {

        }
    }
}
