using System.Drawing;
using System.Windows.Forms;

namespace Desafio___Tetris.Labels
{
    internal class FormPanels : FormLabels
    {
        public Panel ScorePanel { get; set; }
        public FormPanels()
        {
            ScorePanel = new Panel();
            ScorePanel.ResumeLayout(false);
            ScorePanel.PerformLayout();
            ScorePanel.Controls.Add(ScoreCaptionLabel);
            ScorePanel.Controls.Add(ScoreLabel);
            ScorePanel.Controls.Add(PieceCounterCaptionLabel);
            ScorePanel.Controls.Add(GameTimerLabel);
            ScorePanel.Controls.Add(LevelCaptionLabel);
            ScorePanel.Controls.Add(GameTimerCaptionLabel);
            ScorePanel.Controls.Add(PieceCounterLabel);
            ScorePanel.Controls.Add(LevelLabel);
            ScorePanel.Controls.Add(SpeedCaptionLabel);
            ScorePanel.Controls.Add(SpeedLabel);
            ScorePanel.Location = new Point(748, 13);
            ScorePanel.Name = "ScorePanel";
            ScorePanel.Size = new Size(242, 198);
            ScorePanel.TabIndex = 24;
            ScorePanel.SuspendLayout();
        }
    }
}
