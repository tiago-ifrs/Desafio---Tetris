using Desafio___Tetris.Conexoes;
using Desafio___Tetris.View;
using System;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public partial class Form1 : Form
    {
        private Game Game { get; set; }

        //private FormPontuacaoSelect Fs { get; set; }
        private BoardView BoardView { get; set; }
        private PauseView PauseView { get; set; }
        private PieceView PieceView { get; set; }
        private ScoreView ScoreView { get; set; }
        public Form1()
        {
            InitializeComponent();
            BoardView = new BoardView
            {
                Panel = panelTabuleiro
            };
            PieceView = new PieceView()
            {
                CurrentPanel = panelAtual,
                NextPanel = panelProx,
            };
            PauseView = new PauseView
            {
                Panel = pausePlaceHolderPanel
            };
            ScoreView  = new ScoreView
            {
                Output = scorePlaceHolderPanel
            };
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            DbConnection dbConnection = conexao.DbConnection;
            conexao.VerifyDbConnection();
            if (dbConnection != null)
            {
                buttonPontuacao.Visible = true;
                FormPontuacaoTlp formPontuacaoTlp = new FormPontuacaoTlp
                {
                    TopMost = true
                };
                formPontuacaoTlp.Show();
            }
            conexao.DbConnection.Close();
        }
        private void ButtonNJ_Click(object sender, EventArgs e)
        {
            Tetris();
        }
        private void ButtonPause_Click(object sender, EventArgs e)
        {
            Game.Pause();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Up):
                    labelKey.Text = char.ToString((char)0xe1);
                    Game.RotacionaPeca();
                    break;
                case (Keys.Down):
                    labelKey.Text = char.ToString((char)0xe2);
                    Game.MoveAbaixo();
                    break;
                case (Keys.Left):
                    labelKey.Text = char.ToString((char)0xdf);
                    Game.MoveEsquerda();
                    break;
                case (Keys.Right):
                    labelKey.Text = char.ToString((char)0xe0);
                    Game.MoveDireita();
                    break;
            };
            // return the key to the base class if not used.
            //return base.ProcessDialogKey(keyData);
            return true;
        }
        public void Tetris()
        {
            buttonPause.Enabled = true;
            trackBarNivel.Enabled = false;
            
            GameView gameView = new GameView
            {
                BoardView = BoardView,
                PauseView = PauseView,
                PieceView = PieceView,
                ScoreView = ScoreView
            };

            this.Game = new Game
            {
                GameView = gameView,
                StartLevel = trackBarNivel.Value
            };

            while (!Game.Over)
            {
                Game.Percorre();
            }

            MessageBox.Show(strings.Form1_Tetris_Game_Over);
            SalvaPontuacao();
            buttonPause.Enabled = false;
            trackBarNivel.Enabled = true;
        }
        private void SalvaPontuacao()
        {
            FormPontuacaoInsert fp = new FormPontuacaoInsert(Game, BoardView, ScoreView);

            Conexao conexao = new Conexao();
            DbConnection dbConnection = conexao.DbConnection;
            conexao.VerifyDbConnection();
            if (dbConnection != null)
            {
                fp.ShowDialog();
            }
            conexao.DbConnection.Close();
        }
        private void ButtonTGD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("https://github.com/tiago-ifrs/Desafio---Tetris" +
                            "\n" +
                            "tgdbr@yahoo.com.br",
                            "Tetris 21");
        }
        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            string minhasImagens = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            SaveFileDialog sfd = new SaveFileDialog();
            ImageFormat formato = ImageFormat.Jpeg;
            Bitmap captureBitmap = new Bitmap(panelTabuleiro.Width, panelTabuleiro.Height);
            Rectangle captureRectangle = new Rectangle(0, 0, panelTabuleiro.Width, panelTabuleiro.Height);
            panelTabuleiro.DrawToBitmap(captureBitmap, captureRectangle);

            sfd.Filter = "Imagens|*.png;*.bmp;*.jpg";
            sfd.InitialDirectory = minhasImagens;
            sfd.DefaultExt = "*.jpg";

            if (sfd.ShowDialog() != DialogResult.OK) return;
            string ext = Path.GetExtension(sfd.FileName)?.ToLower();
            switch (ext)
            {
                case ".jpg":
                    formato = ImageFormat.Jpeg;
                    break;
                case ".bmp":
                    formato = ImageFormat.Bmp;
                    break;
                case ".png":
                    formato = ImageFormat.Png;
                    break;
            }
            captureBitmap.Save(sfd.FileName ?? throw new InvalidOperationException(), formato);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Game.Paused)
            {
                Game.Paused = false;
                Game.Over = true;
            }
            Application.Exit();
        }
        private void ButtonPontuacao_Click(object sender, EventArgs e)
        {
            FormPontuacaoTlp formPontuacaoTlp = new FormPontuacaoTlp
            {
                TopMost = true
            };
            formPontuacaoTlp.Show();
        }
        private void TrackBarNivel_ValueChanged(object sender, EventArgs e)
        {
            labelTBNivel.Text = trackBarNivel.Value.ToString();
        }
    }
}