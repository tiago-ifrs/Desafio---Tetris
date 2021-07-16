using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public partial class FormPontuacaoInsert : Form
    {
        private Placar Placar { get; set; }
        private Stopwatch Stopwatch { get; set; }
        private Bitmap CaptureBitmap { get; set; }
        /*
        public FormPontuacaoInsert()
        {
            InitializeComponent();
        }
        */
        public FormPontuacaoInsert(Placar placar, Stopwatch stopwatch)
        {
            this.Placar = placar;
            this.Stopwatch = stopwatch;
            this.CaptureBitmap = new Bitmap(Tabuleiro.Panel.Width, Tabuleiro.Panel.Height);
            InitializeComponent();
        }
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            PontuacaoDAO pd = new PontuacaoDAO();
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
            pd.Insert(po);
            this.Close();
        }
        private void ButtonCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormPontuacaoInsert_Load(object sender, EventArgs e)
        {
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
