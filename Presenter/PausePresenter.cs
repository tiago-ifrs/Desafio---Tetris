using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Desafio___Tetris.View;

namespace Desafio___Tetris.Presenter
{
    class PausePresenter
    {
        private PauseView PauseView { get; set; }
        private bool _paused { get; set; }
        public bool Paused
        {
            get => _paused;
            set
            {
                _paused = value;
                PauseView.Pause(value);
                while (value)
                {
                    Wait(1000);
                }
            }
        }
        private bool _over { get; set; }
        public bool Over 
        { 
            get 
            { 
                return _over;
            } 
            set 
            {
                _over = value;
                PauseView.Over();
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
            this.PauseView = new PauseView();
            this.Stopwatch = new Stopwatch();
        }
    }
}
