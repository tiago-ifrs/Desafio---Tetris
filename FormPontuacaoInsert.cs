using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Desafio___Tetris.DAO;
using Desafio___Tetris.Model;
using Desafio___Tetris.View;

namespace Desafio___Tetris
{
    public partial class FormPontuacaoInsert : Form
    {
        private Bitmap CaptureBitmap { get; }
        private Game Game { get; set; }
        private Panel Panel { get; set; }
        BoardView BoardView { get; set; }
        ScoreView ScoreView { get; set; }
        public FormPontuacaoInsert(Game game, BoardView boardView, ScoreView scoreView)
        {
            this.BoardView = boardView;
            this.Game = game;
            this.ScoreView = scoreView;
            this.CaptureBitmap = new Bitmap(boardView.Panel.Width, boardView.Panel.Height);
            InitializeComponent();
        }
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Pontuacao po = new Pontuacao
            {
                Nome = textBoxNome.Text,
                Score = Game.Score.Points,
                Nivel = Game.Score.Level,
                QtdPecas = Game.Score.PieceCount,
                TempoJogo = Game.Score.TimeSpan,
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
        private void FormPontuacaoInsert_Load(object sender, EventArgs e)
        {
            Bitmap bitmapPictureBoxImage = new Bitmap(pictureBoxTabuleiro.Width, pictureBoxTabuleiro.Height);
            Rectangle captureRectangle = new Rectangle(0, 0, BoardView.Panel.Width, BoardView.Panel.Height);
            BoardView.Panel.DrawToBitmap(CaptureBitmap, captureRectangle);
            Graphics g = Graphics.FromImage(bitmapPictureBoxImage);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(CaptureBitmap, 0, 0, pictureBoxTabuleiro.Width, pictureBoxTabuleiro.Height);

            pictureBoxTabuleiro.Image = bitmapPictureBoxImage;
            Panel = ScoreView.Output;
            ScoreView.Output = panelPlacarInsert;
        }

        private void FormPontuacaoInsert_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void FormPontuacaoInsert_Validated(object sender, EventArgs e)
        {

        }

        private void FormPontuacaoInsert_FormClosed(object sender, FormClosedEventArgs e)
        {
            ScoreView.Output = Panel;
        }
    }
}