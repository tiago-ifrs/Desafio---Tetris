using Desafio___Tetris.Model;
using Desafio___Tetris.View;

namespace Desafio___Tetris.Presenter
{
    public class ScorePresenter
    {
        internal Score Score { get; set; }
        public int Points 
        { 
            get => Score.Points;
            set 
            {
                Score.Points = value;
                ScoreView.Points = value;
            } 
        }
        public int Level 
        { 
            get => Score.Level;
            set 
            {
                Score.Level = value;
                ScoreView.Level = value;
            } 
        }
        public double Speed 
        { 
            get => Score.Speed;
            set 
            {
                Score.Speed = value;
                ScoreView.Speed = value;
            } 
        }
        
        public int PieceCounter
        {
            get => Score.PieceCounter;
            set
            {
                Score.PieceCounter = value;
                ScoreView.PieceCounter = value;
            }
        }
        public ScoreView ScoreView { get; set; }
        public ScorePresenter()
        {
        }
    }
}
