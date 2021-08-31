using Desafio___Tetris.Conexoes;
using Desafio___Tetris.View;
using System;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Desafio___Tetris.Labels;

namespace Desafio___Tetris
{
    public partial class Form1 : Form
    {
        private Game Game { get; set; }

        //private FormPontuacaoSelect Fs { get; set; }
        private BoardView BoardView { get; set; }
        private GameView GameView { get; set; }
        private TimeView TimeView { get; set; }
        private PieceView PieceView { get; set; }
        private ScoreView ScoreView { get; set; }
        public Form1()
        {
            InitializeComponent();
            FormPanels FormPanels = new FormPanels();
            BoardView = new BoardView
            {
                Panel = panelTabuleiro
            };
            PieceView = new PieceView()
            {
                CurrentPanel = panelAtual,
                NextPanel = panelProx,
            };
            
            ScoreView  = new ScoreView
            {
                FormPanels = FormPanels,
                Output = scorePlaceHolderPanel
            };
            TimeView = new TimeView
            {
                FormPanels = FormPanels,
                Panel = pausePlaceHolderPanel,
                ScorePanel = scorePlaceHolderPanel
            };
            GameView = new GameView()
            {
                TrackBar = trackBarNivel
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
            GameView.Pause();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Up):
                    labelKey.Text = char.ToString((char)0xe1);
                    GameView.RotacionaPeca();
                    break;
                case (Keys.Down):
                    labelKey.Text = char.ToString((char)0xe2);
                    GameView.MoveAbaixo();
                    break;
                case (Keys.Left):
                    labelKey.Text = char.ToString((char)0xdf);
                    GameView.MoveEsquerda();
                    break;
                case (Keys.Right):
                    labelKey.Text = char.ToString((char)0xe0);
                    GameView.MoveDireita();
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

            GameView.BoardView = BoardView;
            GameView.TimeView = TimeView;
            GameView.PieceView = PieceView;
            GameView.ScoreView = ScoreView;

            GameView.Start();
            
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
            if (Game.Time.Paused)
            {
                Game.Time.Paused = false;
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