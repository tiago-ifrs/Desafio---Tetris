using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Desafio___Tetris.Model;

namespace Desafio___Tetris
{
    public partial class FormPontuacaoInsert : Form
    {
        private Placar Placar { get; set; }
        private Stopwatch Stopwatch { get; set; }
        private Bitmap CaptureBitmap { get; set; }
        private Label ScoreCaptionLabel { get; set;}
        private Label SpeedCaptionLabel { get; set; }
        private Label LevelCaptionLabel { get; set; }
        private Label PieceCounterCaptionLabel { get; set; }
        private Label GameTimerCaptionLabel { get; set; }
        private Label ScoreLabel { get; set; }
        private Label LevelLabel { get; set; }
        private Label SpeedLabel { get; set; }
        private Label PieceCounterLabel { get; set; }
        private Label GameTimerLabel { get; set; }
        public FormPontuacaoInsert(Placar placar,
            Stopwatch stopwatch,
            ref Label scoreCaptionLabel,
            ref Label levelCaptionLabel,
            ref Label speedCaptionLabel,
            ref Label pieceCounterCaptionLabel,
            ref Label gameTimerCaptionLabel,
            ref Label scoreLabel,
            ref Label levelLabel,
            ref Label speedLabel,
            ref Label pieceCounterLabel,
            ref Label gameTimerLabel
            )
        {
            this.Placar = placar;
            this.Stopwatch = stopwatch;
            this.ScoreCaptionLabel = scoreCaptionLabel;
            this.LevelCaptionLabel = levelCaptionLabel;
            this.SpeedCaptionLabel = speedCaptionLabel;
            this.PieceCounterCaptionLabel = pieceCounterCaptionLabel;
            this.GameTimerCaptionLabel = gameTimerCaptionLabel;
            this.ScoreLabel = scoreLabel;
            this.LevelLabel = levelLabel;
            this.SpeedLabel = speedLabel;
            this.PieceCounterLabel = pieceCounterLabel;
            this.GameTimerLabel = gameTimerLabel;
            this.CaptureBitmap = new Bitmap(Tabuleiro.Panel.Width, Tabuleiro.Panel.Height);
            InitializeComponent();
        }
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Pontuacao po = new Pontuacao
            {
                Nome = textBoxNome.Text,
                Score = Placar.Score,
                Nivel = Placar.Nivel,
                QtdPecas = Placar.QtdPecas,
                TempoJogo = Stopwatch.Elapsed,
                DataScore = DateTime.Now,
                Tabuleiro = CaptureBitmap
            };

            IEnumerable<ValidationResult> results = Validador.GValidationResults(po);
            string s = string.Empty;
            foreach (ValidationResult variable in results)
            {
                s += variable.ErrorMessage + '\n';
            }

            if (results.Any()) //existem erros de validação
            {
                MessageBox.Show(s);
            }
            else
            {
                AbsPontuacaoDao pd = new PontuacaoDao().AbsPontuacaoDao;
                pd.Insert(po);
                //TrocaControles(panelPlacarInsert.Controls, Placar.Panel.Controls);
                this.Close();
            }
        }
        private void ButtonCancela_Click(object sender, EventArgs e)
        {
            //TrocaControles(panelPlacarInsert.Controls, Placar.Panel.Controls);
            this.Close();
        }
        private void FormPontuacaoInsert_Load(object sender, EventArgs e)
        {
            //TrocaControles(Placar.Panel.Controls, panelPlacarInsert.Controls);
            TrocaControles();

            Bitmap bitmapPictureBoxImage = new Bitmap(pictureBoxTabuleiro.Width, pictureBoxTabuleiro.Height);
            Rectangle captureRectangle = new Rectangle(0, 0, Tabuleiro.Panel.Width, Tabuleiro.Panel.Height);
            Tabuleiro.Panel.DrawToBitmap(CaptureBitmap, captureRectangle);
            Graphics g = Graphics.FromImage(bitmapPictureBoxImage);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(CaptureBitmap, 0, 0, pictureBoxTabuleiro.Width, pictureBoxTabuleiro.Height);
            pictureBoxTabuleiro.Image = bitmapPictureBoxImage;
        }
        
        private void TrocaControles(System.Windows.Forms.Control.ControlCollection org,
                                    System.Windows.Forms.Control.ControlCollection dst)
        {
            dst.Add(org["scoreCaptionLabel"]);
            dst.Add(org["scoreLabel"]);

            dst.Add(org["levelCaptionLabel"]);
            dst.Add(org["levelLabel"]);

            dst.Add(org["speedCaptionLabel"]);
            dst.Add(org["speedLabel"]);

            dst.Add(org["pieceCounterCaptionLabel"]);
            dst.Add(org["pieceCounterLabel"]);

            dst.Add(org["gameTimerCaptionLabel"]);
            dst.Add(org["gameTimerLabel"]);
        }
        
        private void TrocaControles()
        {
            this.Controls.Add(ScoreCaptionLabel);
            this.Controls.Add(ScoreLabel);
            this.Controls.Add(LevelCaptionLabel);
            this.Controls.Add(LevelLabel);
            this.Controls.Add(SpeedCaptionLabel);
            this.Controls.Add(SpeedLabel);
            this.Controls.Add(PieceCounterCaptionLabel);
            this.Controls.Add(PieceCounterLabel);
            this.Controls.Add(GameTimerCaptionLabel);
            this.Controls.Add(GameTimerLabel);
        }
    }
}
