using System.Drawing;
using System.Windows.Forms;

namespace Desafio___Tetris.Labels
{
    internal class LabelPause : Label
    {
        internal LabelPause()
        {
            Anchor = AnchorStyles.Bottom;
            AutoSize = true;
            BackColor = Color.Transparent;
            Font = new Font("Webdings",
                                           30F,
                                           FontStyle.Regular,
                                           GraphicsUnit.Point);
            Location = new Point(439, 632);
            Name = "labelPause";
            Size = new Size(87, 61);
            TabIndex = 0;
            Text = "<";
            TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}
