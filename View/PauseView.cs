using System.Windows.Forms;
using Desafio___Tetris.Labels;

namespace Desafio___Tetris.View
{
    internal class PauseView
    {
        private LabelPause LabelPause { get; }
        public void Pause(bool paused)
        {
            LabelPause.Text = paused == false ? char.ToString((char)0x34) : char.ToString((char)0x3b);
            LabelPause.Refresh();
        }
        public void Over(bool over)
        {
            LabelPause.Text = over ? char.ToString((char) 0x3c) : char.ToString((char)0x34);
            LabelPause.Refresh();
        }
        internal PauseView(Control pausePlaceHolderPanel)
        {
            LabelPause = (LabelPause) pausePlaceHolderPanel.Controls[0];

            LabelPause.Text = char.ToString((char) 0x34);
            LabelPause.Refresh();
        }
    }
}