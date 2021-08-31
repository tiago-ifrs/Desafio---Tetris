using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Desafio___Tetris.Model
{
    internal class Time
    {
        internal Stopwatch Stopwatch { get; set; }
        internal Timer Timer { get; set; }
        internal bool Paused { get; set; }
        internal TimeSpan TimeSpan { get; set; }
        internal void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
                Application.DoEvents();
        }
        internal void AcionaRelogio()
        {
            Stopwatch.Start();
            Timer.Start();
        }
        internal void ParaRelogio()
        {
            Stopwatch.Stop();
            Timer.Stop();
        }
    }
}
