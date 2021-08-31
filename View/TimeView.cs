using Desafio___Tetris.Labels;
using System;
using System.Windows.Forms;

namespace Desafio___Tetris.View
{
    class TimeView
    {
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
        private LabelPause LabelPause { get; }
        private Panel _panel { get; set; }

        public Panel Panel
        {
            get => _panel;
            set
            {
                _panel = value;

            }
        }
        public FormPanels FormPanels { get; set; }
        public Panel ScorePanel { get; set; }
        public void Pause(bool paused)
        {
            LabelPause.Text = paused == false ? char.ToString((char)0x34) : char.ToString((char)0x3b);
            LabelPause.Refresh();
        }
        public void Over(bool over)
        {
            LabelPause.Text = over ? char.ToString((char)0x3c) : char.ToString((char)0x34);
            LabelPause.Refresh();
        }
        internal TimeView()
        {
            Panel.Controls.Add(LabelPause);
            this.LabelPause = new LabelPause();
            LabelPause.Text = char.ToString((char)0x34);
            LabelPause.Refresh();
        }
    }
}
