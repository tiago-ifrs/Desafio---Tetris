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
        private Placar Placar { get; }
        private Stopwatch Stopwatch { get; }
        private Bitmap CaptureBitmap { get; }
        private Label ScoreCaptionLabel { get; }
        private Label SpeedCaptionLabel { get; }
        private Label LevelCaptionLabel { get; }
        private Label PieceCounterCaptionLabel { get; }
        private Label GameTimerCaptionLabel { get; }
        private Label ScoreLabel { get; }
        private Label LevelLabel { get; }
        private Label SpeedLabel { get; }
        private Label PieceCounterLabel { get; }
        private Label GameTimerLabel { get; }
        private Control.ControlCollection Collection { get; set; }

        public FormPontuacaoInsert(Jogo jogo)
        {
            this.Placar = jogo.Placar;
            this.Stopwatch = jogo.Sw;
            //this.Collection = collection;
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
            TrocaControles(panelPlacarInsert.Controls, Collection);
            this.Close();
        }
        private void FormPontuacaoInsert_Load(object sender, EventArgs e)
        {
            TrocaControles(Collection, panelPlacarInsert.Controls);

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
    }
}
