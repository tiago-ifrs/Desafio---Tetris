using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio___Tetris.View
{
    class PauseView
    {
        public void Pause(bool paused)
        {
            Form1.labelPause.Text = paused == false ? char.ToString((char)0x3b) : char.ToString((char)0x34);
            Form1.labelPause.Refresh();
        }
        internal PauseView()
        {
        }
    }
}
