using Desafio___Tetris.Labels;
using System;
using System.Windows.Forms;

namespace Desafio___Tetris.View
{
    internal class ScoreView
    {
        private FormPanels FormPanels{ get; }
        private Panel _output { get; set; }
        public Panel Output
        {
            get => _output;
            set
            {
                Control.ControlCollection collection = _output == null ? FormPanels.ScorePanel.Controls : _output.Controls;
                int c = collection.Count;
                for (int i = 0; i < c; i++)
                {
                    //must be the 1st index as Controls are being deleted from collection while added to placeholder
                    value.Controls.Add(collection[0]);
                }
                _output = value;
            }
        }
        private TimeSpan _timeSpan { get; set; }
        public TimeSpan TimeSpan
        {
            get => _timeSpan;
            set
            {
                _timeSpan = value;
                FormPanels.GameTimerLabel.Text = $@"{value.Hours:00}:{value.Minutes:00}:{value.Seconds:00}";
                FormPanels.GameTimerLabel.Refresh();
            }
        }
        private int _level { get; set; }
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                FormPanels.LevelLabel.Text = value.ToString();
                FormPanels.LevelLabel.Refresh();
            }
        }
        private int _pieceCounter { get; set; }
        public int PieceCounter
        {
            get => _pieceCounter;
            set
            {
                _pieceCounter = value;
                FormPanels.PieceCounterLabel.Text = value.ToString();
                FormPanels.PieceCounterLabel.Refresh();
            }
        }
        private int _score { get; set; }
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                FormPanels.ScoreLabel.Text = value.ToString();
                FormPanels.ScoreLabel.Refresh();
            }
        }
        private double _speed { get; set; }
        public double Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                FormPanels.SpeedLabel.Text = string.Format(strings.ScoreView_Speed__0___lines_s_, Math.Round(1000 / value, 2));
                FormPanels.SpeedLabel.Refresh();
            }
        }
        public ScoreView()
        {
            FormPanels = new FormPanels();
        }
    }
}