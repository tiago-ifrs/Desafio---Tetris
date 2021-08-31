using Desafio___Tetris.Model;
using Desafio___Tetris.View;
using System;
using Timer = System.Windows.Forms.Timer;

namespace Desafio___Tetris.Presenter
{
    class ScorePresenter
    {
        public Score Score { get; set; }
        public int Points 
        { 
            get { return Score.Points; } 
            set 
            {
                Score.Points = value;
                ScoreView.Points = value;
            } 
        }
        public int Level 
        { 
            get 
            { 
                return Score.Level; 
            }
            set 
            {
                Score.Level = value;
                ScoreView.Level = value;
            } 
        }
        public double Speed 
        { 
            get 
            { 
                return Score.Speed; 
            } 
            set 
            {
                Score.Speed = value;
                ScoreView.Speed = value;
            } 
        }
        public TimeSpan TimeSpan
        {
            get => Score.TimeSpan;
            set
            {
                Score.TimeSpan = value;
                ScoreView.TimeSpan = value;
            }
        }
        public Timer Timer { get; set; }
        private ScoreView ScoreView { get; }
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

    }
}
