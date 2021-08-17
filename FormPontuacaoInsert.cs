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
        public FormPontuacaoInsert(Placar placar, Stopwatch stopwatch)
        {
            this.Placar = placar;
            this.Stopwatch = stopwatch;
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
                TrocaControles(panelPlacarInsert.Controls, Placar.Panel.Controls);
                this.Close();
            }
        }
        private void ButtonCancela_Click(object sender, EventArgs e)
        {
            TrocaControles(panelPlacarInsert.Controls, Placar.Panel.Controls);
            this.Close();
        }
        private void FormPontuacaoInsert_Load(object sender, EventArgs e)
        {
            TrocaControles(Placar.Panel.Controls, panelPlacarInsert.Controls);


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
            dst.Add(org["label4"]);
            dst.Add(org["labelPlacar"]);

            dst.Add(org["label5"]);
            dst.Add(org["labelLevel"]);

            dst.Add(org["label7"]);
            dst.Add(org["labelSpeed"]);

            dst.Add(org["label8"]);
            dst.Add(org["labelQtdPeca"]);

            dst.Add(org["label6"]);
            dst.Add(org["labelTimerJogo"]);
        }
    }
}
