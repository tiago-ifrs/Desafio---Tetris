using System;
using Desafio___Tetris.Labels;

namespace Desafio___Tetris.View
{
    class ScoreView
    {
        #region TimesRegion
        protected static readonly int[] Times =
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

        private FormPanels FormPanels{ get; set; }
        private TimeSpan _timeSpan { get; set; }
        protected TimeSpan TimeSpan
        {
            get => _timeSpan;
            set
            {
                _timeSpan = value;

            }
        }
        private int _level { get; set; }
        protected int Level
        {
            get => _level;
            set
            {
                _level = value;
                FormPanels.levelLabel.Text = value.ToString();
                FormPanels.levelLabel.Refresh();
            }
        }
        private int _score { get; set; }
        protected int Score
        {
            get => _score;
            set
            {
                _score = value;
                FormPanels.scoreLabel.Text = value.ToString();
                FormPanels.scoreLabel.Refresh();
            }
        }
        private int _pieceCounter { get; set; }
        protected int PieceCounter
        {
            get => _pieceCounter;
            set
            {
                _pieceCounter = value;
                FormPanels.pieceCounterLabel.Text = value.ToString();
                FormPanels.pieceCounterLabel.Refresh();
            }
        }
        private double _speed { get; set; }
        protected double Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                FormPanels.speedLabel.Text = string.Format(strings.ScoreView_Speed__0___lines_s_, Math.Round(1000 / value, 2));
                FormPanels.speedLabel.Refresh();
            }
        }
        protected ScoreView()
        {
            FormPanels = new FormPanels();
        }
    }
}
