using Desafio___Tetris.Labels;
using System.Drawing;
using System.Windows.Forms;

namespace Desafio___Tetris.View
{
    internal class PauseView
    {
        private LabelPause LabelPause { get; set; }
        public void Pause(bool paused)
        {
            LabelPause.Text = paused == false ? char.ToString((char)0x3b) : char.ToString((char)0x34);
            LabelPause.Refresh();
        }
        public void Over() 
        {
            LabelPause.Text = char.ToString((char)0x3c);
        }
        internal PauseView()
        {
            LabelPause = new LabelPause
            {
                Text = char.ToString((char)0x34)
            };
            /*
            Form1.pausePlaceHolderPanel = new Panel
            {
                Location = new Point(439, 618),
                Name = "pausePlaceHolderPanel",
                Size = new Size(111, 78),
                TabIndex = 29
            };
            */
            //LabelPause.Controls.Add(Form1.pausePlaceHolderPanel);
            Form1.pausePlaceHolderPanel.Controls.Add(LabelPause);
        }
    }
}
