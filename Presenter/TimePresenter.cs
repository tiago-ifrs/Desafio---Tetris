using Desafio___Tetris.View;
using System;
using System.Diagnostics;
using Desafio___Tetris.Model;

namespace Desafio___Tetris.Presenter
{
    internal class TimePresenter
    {
        internal Time Time { get; set; }
        internal TimeView TimeView { get; set; }
        public TimeSpan TimeSpan
        {
            get => Time.TimeSpan;
            set
            {
                Time.TimeSpan = value;
                TimeView.TimeSpan = value;
            }
        }
        internal bool Paused
        {
            get => Time.Paused;
            set
            {
                Time.Paused = value;
                TimeView.Pause(value);
                while (Time.Paused)
                {
                    Time.Wait(1000);
                }
            }
        }
        private void TimerJogo_Tick(object sender, EventArgs e)
        {
            Time.TimeSpan = Time.Stopwatch.Elapsed;
        }
        internal void Pause()
        {
            if (Time.Paused == false)
            {
                Time.ParaRelogio();
                Time.Paused = true;
            }
            else
            {
                Time.AcionaRelogio();
                Time.Paused = false;
            }
        }
        internal TimePresenter()
        {
            Time.Timer.Tick += this.TimerJogo_Tick;
            Time.Stopwatch = new Stopwatch();
            Time.AcionaRelogio();
        }
    }
}
