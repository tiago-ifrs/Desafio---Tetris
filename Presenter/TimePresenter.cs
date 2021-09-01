using Desafio___Tetris.Model;
using Desafio___Tetris.View;
using System;

namespace Desafio___Tetris.Presenter
{
    internal class TimePresenter
    {
        private Time _Time { get; init; }
        internal Time Time
        {
            get => _Time;
            init
            {
                _Time = value;
                Time.Timer.Tick += Timer_Tick;
                TimeView.Play();
                Time.Start();
            }
        }
        internal TimeView TimeView { get; init; }
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeView.TimeSpan = Time.TimeSpan = Time.Stopwatch.Elapsed;
        }
        internal void Pause()
        {
            if (Time.Paused == false)
            {
                Time.Stop();
                TimeView.Pause();
                Time.Pause(true);
            }
            else
            {
                Time.Pause(false);
                Time.Start();
                TimeView.Play();
            }
        }
        internal void Over()
        {
            Time.Stop();
            TimeView.Over();
        }
        internal TimePresenter()
        {
        }
    }
}