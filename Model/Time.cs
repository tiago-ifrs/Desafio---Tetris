using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Desafio___Tetris.Model
{
    internal class Time
    {
        internal bool Paused { get; set; }
        internal Stopwatch Stopwatch { get; set; }
        internal Timer Timer { get; set; }
        internal TimeSpan TimeSpan { get; set; }
        /// <summary>
        /// Wait  
        /// CA1822: Mark members as static
        /// </summary>
        /// <param name="ms">Time in milliseconds</param>
        internal static void Wait(int ms) 
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
                Application.DoEvents();
        }
        internal void Start()
        {
            Stopwatch.Start();
            Timer.Start();
        }
        internal void Stop()
        {
            Stopwatch.Stop();
            Timer.Stop();
        }
        internal void Pause(bool paused)
        {
            Paused = paused;
            while (Paused)
            {
                Wait(1000);
            }
        }
        internal Time()
        {
            Timer = new Timer();
            Stopwatch = new Stopwatch();
        }
    }
}