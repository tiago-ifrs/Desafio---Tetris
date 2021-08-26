using System;
using System.Windows.Forms;

namespace Desafio___Tetris.Labels
{
    internal class FormLabels
    {
        internal Label GameTimerCaptionLabel { get; set; }
        internal Label GameTimerLabel { get; set; }
        internal Label LevelCaptionLabel { get; set; }
        internal Label LevelLabel { get; set; }
        internal Label PieceCounterCaptionLabel { get; set; }
        internal Label PieceCounterLabel { get; set; }
        internal Label ScoreCaptionLabel { get; set; }
        internal Label ScoreLabel { get; set; }
        internal Label SpeedCaptionLabel { get; set; }
        internal Label SpeedLabel { get; set; }
        internal FormLabels()
        {
            GameTimerCaptionLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(4, 100),
                Name = "gameTimerCaptionLabel",
                Size = new System.Drawing.Size(135, 25),
                TabIndex = 18,
                Text = strings.FormLabels_FormLabels_Elapsed_Time
            };
            GameTimerLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(145, 100),
                Name = "gameTimerLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 19,
                Text = TimeSpan.Zero.ToString()
            };
            LevelCaptionLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(4, 25),
                Name = "levelCaptionLabel",
                Size = new System.Drawing.Size(51, 25),
                TabIndex = 14,
                Text = strings.FormLabels_FormLabels_Level
            };
            LevelLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(61, 25),
                Name = "levelLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 15,
                Text = 0.ToString()
            };
            PieceCounterCaptionLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(4, 75),
                Name = "pieceCounterCaptionLabel",
                Size = new System.Drawing.Size(55, 25),
                TabIndex = 21,
                Text = strings.FormLabels_FormLabels_Pieces
            };
            PieceCounterLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(65, 75),
                Name = "pieceCounterLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 22,
                Text = 0.ToString()
            };
            ScoreCaptionLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(3, 0),
                Name = "scoreCaptionLabel",
                Size = new System.Drawing.Size(56, 25),
                TabIndex = 11,
                Text = strings.FormLabels_FormLabels_Score
            };
            ScoreLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(65, 0),
                Name = "scoreLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 12,
                Text = 0.ToString()
            };
            SpeedCaptionLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(4, 50),
                Name = "speedCaptionLabel",
                Size = new System.Drawing.Size(98, 25),
                TabIndex = 16,
                Text = strings.FormLabels_FormLabels_Speed
            };
            SpeedLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(108, 50),
                Name = "speedLabel",
                Size = new System.Drawing.Size(22, 25),
                TabIndex = 17,
                Text = 0.ToString()
            };
        }
    }
}
