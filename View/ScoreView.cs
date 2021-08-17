using System;
using System.Windows.Forms;

namespace Desafio___Tetris.View
{
    public class ScoreView
    {
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
        private Label ScoreLabel { get; set; }
        private Label LevelLabel { get; set; }
        private Label SpeedLabel { get; set; }
        private Label PieceCounterLabel { get; set; }
        private int _score { get; set; }
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                ScoreLabel.Text = value.ToString();
                ScoreLabel.Refresh();
            }
        }
        private int _level { get; set; }
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                LevelLabel.Text = value.ToString();
                LevelLabel.Refresh();
            }
        }
        private double _speed { get; set; }
        public double Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                SpeedLabel.Text = $"{Math.Round(1000 / value, 2)} (linhas/s)";
                SpeedLabel.Refresh();
            }
        }
        private int _pieceCounter { get; set; }
        public int PieceCounter
        {
            get => _pieceCounter;
            set
            {
                _pieceCounter = value;
                PieceCounterLabel.Text = value.ToString();
                PieceCounterLabel.Refresh();
            }
        }
        public ScoreView(ref Label scoreLabel, ref Label levelLabel, ref Label speedLabel, ref Label pieceCounterLabel)
        {
            this.ScoreLabel = scoreLabel;
            this.LevelLabel = levelLabel;
            this.SpeedLabel = speedLabel;
            this.PieceCounterLabel = pieceCounterLabel;
        }
    }
}
