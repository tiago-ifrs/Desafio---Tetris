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
        public FormPontuacaoInsert(Jogo jogo)
        {
            this.Placar = jogo.Placar;
            this.Stopwatch = jogo.Sw;
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
                this.Close();
            }
        }
        private void ButtonCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormPontuacaoInsert_Load(object sender, EventArgs e)
        {
            Placar.Output = panelPlacarInsert;

            Bitmap bitmapPictureBoxImage = new Bitmap(pictureBoxTabuleiro.Width, pictureBoxTabuleiro.Height);
            Rectangle captureRectangle = new Rectangle(0, 0, Tabuleiro.Panel.Width, Tabuleiro.Panel.Height);
            Tabuleiro.Panel.DrawToBitmap(CaptureBitmap, captureRectangle);
            Graphics g = Graphics.FromImage(bitmapPictureBoxImage);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(CaptureBitmap, 0, 0, pictureBoxTabuleiro.Width, pictureBoxTabuleiro.Height);
            pictureBoxTabuleiro.Image = bitmapPictureBoxImage;
        }
    }
}