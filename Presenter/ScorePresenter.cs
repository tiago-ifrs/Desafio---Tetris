using Desafio___Tetris.Model;
using Desafio___Tetris.View;
using System;
using Timer = System.Windows.Forms.Timer;

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
        public Timer Timer { get; set; }
        public ScoreView ScoreView { get; set; }
        public ScorePresenter()
        {
            //Score = new Score();
        }
        /*
        public ScorePresenter(int startLevel)
        {
            ScoreView = new ScoreView
            {
                //Initializes score labels each new game
                Level = startLevel,
                PieceCounter = 0,
                Points = 0,
                Speed = Score.Times[startLevel]
            };
        }
        */
    }
}
