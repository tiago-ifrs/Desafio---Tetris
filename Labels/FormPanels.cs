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
            ScorePanel.Controls.Add(scoreCaptionLabel);
            ScorePanel.Controls.Add(scoreLabel);
            ScorePanel.Controls.Add(pieceCounterCaptionLabel);
            ScorePanel.Controls.Add(gameTimerLabel);
            ScorePanel.Controls.Add(levelCaptionLabel);
            ScorePanel.Controls.Add(gameTimerCaptionLabel);
            ScorePanel.Controls.Add(pieceCounterLabel);
            ScorePanel.Controls.Add(levelLabel);
            ScorePanel.Controls.Add(speedCaptionLabel);
            ScorePanel.Controls.Add(speedLabel);
            ScorePanel.Location = new Point(748, 13);
            ScorePanel.Name = "ScorePanel";
            ScorePanel.Size = new Size(242, 198);
            ScorePanel.TabIndex = 24;
            ScorePanel.SuspendLayout();
        }
    }
}
