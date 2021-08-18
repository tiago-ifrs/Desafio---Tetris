using System;

namespace Desafio___Tetris.View
{
    public class ScoreView
    {
        #region TimesRegion
        public static readonly int[] Times =
        {
            854,
            800,
            724,
            680,
            610,
            543,
            500, //2/s
            333, //3/s
            250, //4/s
            200, //5/s
            166, //6/s
            143, //7/s
            125, //8/s
            111, //9/s
            100, //10/s
            91, //11/s
            83, //12/s
            77, //13/s
            71, //14/s
            67, //15/s
            50 //20/s
        };
        #endregion
        private int _level { get; set; }
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                Form1.levelLabel.Text = value.ToString();
                Form1.levelLabel.Refresh();
            }
        }
        private int _score { get; set; }
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                Form1.scoreLabel.Text = value.ToString();
                Form1.scoreLabel.Refresh();
            }
        }
        private int _pieceCounter { get; set; }
        public int PieceCounter
        {
            get => _pieceCounter;
            set
            {
                _pieceCounter = value;
                Form1.pieceCounterLabel.Text = value.ToString();
                Form1.pieceCounterLabel.Refresh();
            }
        }
        private double _speed { get; set; }
        public double Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                Form1.speedLabel.Text = string.Format(strings.ScoreView_Speed__0___lines_s_, Math.Round(1000 / value, 2));
                Form1.speedLabel.Refresh();
            }
        }
        public ScoreView()
        {
        }
    }
}
