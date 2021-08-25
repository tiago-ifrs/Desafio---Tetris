using System.Drawing;
using System.Windows.Forms;

namespace Desafio___Tetris.Labels
{
    class FormPanels : FormLabels
    {
        public static Panel panelPlacar { get; set; }
        public FormPanels() : base()
        {
            FormLabels formLabels = new FormLabels();
            panelPlacar = new Panel();
            // 
            // Form1
            // 
            panelPlacar.ResumeLayout(false);
            panelPlacar.PerformLayout();
            // 
            // panelPlacar
            // 
            panelPlacar.Controls.Add(formLabels.scoreCaptionLabel);
            panelPlacar.Controls.Add(formLabels.scoreLabel);
            panelPlacar.Controls.Add(formLabels.pieceCounterCaptionLabel);
            panelPlacar.Controls.Add(formLabels.gameTimerLabel);
            panelPlacar.Controls.Add(formLabels.levelCaptionLabel);
            panelPlacar.Controls.Add(formLabels.gameTimerCaptionLabel);
            panelPlacar.Controls.Add(formLabels.pieceCounterLabel);
            panelPlacar.Controls.Add(formLabels.levelLabel);
            panelPlacar.Controls.Add(formLabels.speedCaptionLabel);
            panelPlacar.Controls.Add(formLabels.speedLabel);
            panelPlacar.Location = new Point(748, 13);
            panelPlacar.Name = "panelPlacar";
            panelPlacar.Size = new Size(242, 198);
            panelPlacar.TabIndex = 24;
            panelPlacar.SuspendLayout();
        }
    }
}
