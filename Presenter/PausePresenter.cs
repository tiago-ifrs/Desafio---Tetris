using System;
using System.Diagnostics;
using System.Windows.Forms;
using Desafio___Tetris.View;

namespace Desafio___Tetris.Presenter
{
    internal class PausePresenter
    {
        private PauseView PauseView { get; }
        private bool _paused { get; set; }
        public bool Paused
        {
            get => _paused;
            set
            {
                _paused = value;
                PauseView.Pause(value);
                while (_paused)
                {
                    Wait(1000);
                }
            }
        }
        private bool _over { get; set; }
        public bool Over 
        { 
            get => _over;
            set 
            {
                _over = value;
                PauseView.Over(value);
            } 
        }
        public Stopwatch Stopwatch { get; set; }
        public void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
                Application.DoEvents();
        }
        public PausePresenter()
        {
            this._paused = false;
            this._over = false;
            
            this.Stopwatch = new Stopwatch();
        }
    }
}
