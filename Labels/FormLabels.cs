using System.Windows.Forms;

namespace Desafio___Tetris.Labels
{
    class FormLabels
    {
        public Label gameTimerCaptionLabel { get; set; }
        public Label levelLabel { get; set; }
        public Label scoreCaptionLabel { get; set; }
        public Label scoreLabel { get; set; }
        public Label speedLabel { get; set; }
        public Label pieceCounterLabel { get; set; }
        
        public FormLabels()
        {
            // 
            // gameTimerCaptionLabel
            // 
            this.gameTimerCaptionLabel.AutoSize = true;
            this.gameTimerCaptionLabel.Location = new System.Drawing.Point(4, 100);
            this.gameTimerCaptionLabel.Name = "gameTimerCaptionLabel";
            this.gameTimerCaptionLabel.Size = new System.Drawing.Size(135, 25);
            this.gameTimerCaptionLabel.TabIndex = 18;
            this.gameTimerCaptionLabel.Text = "Tempo de Jogo";
            // 
            // gameTimerLabel
            // 
            this.gameTimerLabel.AutoSize = true;
            this.gameTimerLabel.Location = new System.Drawing.Point(145, 100);
            this.gameTimerLabel.Name = "gameTimerLabel";
            this.gameTimerLabel.Size = new System.Drawing.Size(22, 25);
            this.gameTimerLabel.TabIndex = 19;
            this.gameTimerLabel.Text = "0";
            // 
            // levelCaptionLabel
            // 
            this.levelCaptionLabel.AutoSize = true;
            this.levelCaptionLabel.Location = new System.Drawing.Point(4, 25);
            this.levelCaptionLabel.Name = "levelCaptionLabel";
            this.levelCaptionLabel.Size = new System.Drawing.Size(51, 25);
            this.levelCaptionLabel.TabIndex = 14;
            this.levelCaptionLabel.Text = "Nível";
            this.levelLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(61, 25),
                Name = "levelLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 15,
                Text = "0"
            };
            // 
            // pieceCounterCaptionLabel
            // 
            this.pieceCounterCaptionLabel.AutoSize = true;
            this.pieceCounterCaptionLabel.Location = new System.Drawing.Point(4, 75);
            this.pieceCounterCaptionLabel.Name = "pieceCounterCaptionLabel";
            this.pieceCounterCaptionLabel.Size = new System.Drawing.Size(55, 25);
            this.pieceCounterCaptionLabel.TabIndex = 21;
            this.pieceCounterCaptionLabel.Text = "Peças";
            this.pieceCounterLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(65, 75),
                Name = "pieceCounterLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 22,
                Text = "0"
            };
            // 
            // scoreCaptionLabel
            // 
            this.scoreCaptionLabel.AutoSize = true;
            this.scoreCaptionLabel.Location = new System.Drawing.Point(3, 0);
            this.scoreCaptionLabel.Name = "scoreCaptionLabel";
            this.scoreCaptionLabel.Size = new System.Drawing.Size(56, 25);
            this.scoreCaptionLabel.TabIndex = 11;
            this.scoreCaptionLabel.Text = "Score";
            this.scoreLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(65, 0),
                Name = "scoreLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 12,
                Text = "0"
            };
            // 
            // speedCaptionLabel
            // 
            this.speedCaptionLabel.AutoSize = true;
            this.speedCaptionLabel.Location = new System.Drawing.Point(4, 50);
            this.speedCaptionLabel.Name = "speedCaptionLabel";
            this.speedCaptionLabel.Size = new System.Drawing.Size(98, 25);
            this.speedCaptionLabel.TabIndex = 16;
            this.speedCaptionLabel.Text = "Velocidade";
            this.speedLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(108, 50),
                Name = "speedLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 17,
                Text = "0"
            };
        }
    }
}
