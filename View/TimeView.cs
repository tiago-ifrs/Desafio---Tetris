using Desafio___Tetris.Labels;
using System;
using System.Windows.Forms;

namespace Desafio___Tetris.View
{
    internal class TimeView
    {
        internal FormPanels FormPanels { get; init; }
        private LabelPause LabelPause { get; }
        private Panel _panel { get; init; }
        internal Panel Panel
        {
            get => _panel;
            init
            {
                _panel = value;
                Panel.Controls.Add(LabelPause);
            }
        }
        private TimeSpan _timeSpan { get; set; }
        internal TimeSpan TimeSpan
        {
            get => _timeSpan;
            set
            {
                _timeSpan = value;
                FormPanels.GameTimerLabel.Text = $@"{value.Hours:00}:{value.Minutes:00}:{value.Seconds:00}";
                FormPanels.GameTimerLabel.Refresh();
            }
        }
        internal void Play()
        {
            LabelPause.Text = char.ToString((char)0x34);
            LabelPause.Refresh();
        }
        internal void Pause()
        {
            LabelPause.Text = char.ToString((char)0x3b);
            LabelPause.Refresh();
        }
        internal void Over()
        {
            LabelPause.Text = char.ToString((char)0x3c);
            LabelPause.Refresh();
        }
        internal TimeView()
        {
            LabelPause = new LabelPause();
        }
    }
}