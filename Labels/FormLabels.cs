using System.Windows.Forms;

namespace Desafio___Tetris.Labels
{
    class FormLabels
    {
        protected Label gameTimerCaptionLabel { get; set; }
        protected Label gameTimerLabel { get; set; }
        protected Label levelCaptionLabel { get; set; }
        protected Label levelLabel { get; set; }
        protected Label pieceCounterCaptionLabel { get; set; }
        protected Label pieceCounterLabel { get; set; }
        protected Label scoreCaptionLabel { get; set; }
        protected Label scoreLabel { get; set; }
        protected Label speedCaptionLabel { get; set; }
        protected Label speedLabel { get; set; }


        protected FormLabels()
        {
            this.gameTimerCaptionLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(4, 100),
                Name = "gameTimerCaptionLabel",
                Size = new System.Drawing.Size(135, 25),
                TabIndex = 18,
                Text = "Tempo de Jogo"
            };
            this.gameTimerLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(145, 100),
                Name = "gameTimerLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 19,
                Text = "0"
            };
            this.levelCaptionLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(4, 25),
                Name = "levelCaptionLabel",
                Size = new System.Drawing.Size(51, 25),
                TabIndex = 14,
                Text = "Nível"
            };
            this.levelLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(61, 25),
                Name = "levelLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 15,
                Text = "0"
            };
            this.pieceCounterCaptionLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(4, 75),
                Name = "pieceCounterCaptionLabel",
                Size = new System.Drawing.Size(55, 25),
                TabIndex = 21,
                Text = "Peças"
            };
            this.pieceCounterLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(65, 75),
                Name = "pieceCounterLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 22,
                Text = "0"
            };
            this.scoreCaptionLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(3, 0),
                Name = "scoreCaptionLabel",
                Size = new System.Drawing.Size(56, 25),
                TabIndex = 11,
                Text = "Score"
            };
            this.scoreLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(65, 0),
                Name = "scoreLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 12,
                Text = "0"
            };
            this.speedCaptionLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(4, 50),
                Name = "speedCaptionLabel",
                Size = new System.Drawing.Size(98, 25),
                TabIndex = 16,
                Text = "Velocidade"
            };
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
