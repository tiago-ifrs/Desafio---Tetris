using System.Windows.Forms;

namespace Desafio___Tetris.Labels
{
    class FormPanels
    {
        public Panel panelPlacar { get; set; }
        FormPanels()
        {
            FormLabels labels = new FormLabels();
            // 
            // Form1
            // 
            this.panelPlacar.ResumeLayout(false);
            this.panelPlacar.PerformLayout();


            this.panelPlacar = new Panel();

            // 
            // panelPlacar
            // 
            this.panelPlacar.Controls.Add(labels.scoreCaptionLabel);
            this.panelPlacar.Controls.Add(labels.scoreLabel);
            this.panelPlacar.Controls.Add(labels.pieceCounterCaptionLabel);
            this.panelPlacar.Controls.Add(labels.gameTimerLabel);
            this.panelPlacar.Controls.Add(labels.levelCaptionLabel);
            this.panelPlacar.Controls.Add(labels.gameTimerCaptionLabel);
            this.panelPlacar.Controls.Add(labels.pieceCounterLabel);
            this.panelPlacar.Controls.Add(labels.levelLabel);
            this.panelPlacar.Controls.Add(labels.speedCaptionLabel);
            this.panelPlacar.Controls.Add(labels.speedLabel);
            this.panelPlacar.Location = new System.Drawing.Point(748, 13);
            this.panelPlacar.Name = "panelPlacar";
            this.panelPlacar.Size = new System.Drawing.Size(242, 198);
            this.panelPlacar.TabIndex = 24;
            this.panelPlacar.SuspendLayout();
        }
    }
}
