using System.Drawing;
using System.Windows.Forms;

namespace Desafio___Tetris.Labels
{
    public class FormPanels : FormLabels
    {
        public Panel panelPlacar { get; set; }
        public FormPanels() : base()
        {
            this.panelPlacar = new Panel();
            // 
            // Form1
            // 
            this.panelPlacar.ResumeLayout(false);
            this.panelPlacar.PerformLayout();
            // 
            // panelPlacar
            // 
            this.panelPlacar.Controls.Add(scoreCaptionLabel);
            this.panelPlacar.Controls.Add(scoreLabel);
            this.panelPlacar.Controls.Add(pieceCounterCaptionLabel);
            this.panelPlacar.Controls.Add(gameTimerLabel);
            this.panelPlacar.Controls.Add(levelCaptionLabel);
            this.panelPlacar.Controls.Add(gameTimerCaptionLabel);
            this.panelPlacar.Controls.Add(pieceCounterLabel);
            this.panelPlacar.Controls.Add(levelLabel);
            this.panelPlacar.Controls.Add(speedCaptionLabel);
            this.panelPlacar.Controls.Add(speedLabel);
            this.panelPlacar.Location = new Point(748, 13);
            this.panelPlacar.Name = "panelPlacar";
            this.panelPlacar.Size = new Size(242, 198);
            this.panelPlacar.TabIndex = 24;
            this.panelPlacar.SuspendLayout();
        }
    }
}
