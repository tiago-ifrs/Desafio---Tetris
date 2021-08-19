using System;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Desafio___Tetris.Conexoes;

namespace Desafio___Tetris
{
    public partial class Form1 : Form
    {
        private Jogo Jogo { get; set; }
        private bool Pause { get; set; }
        private Tabuleiro Tabuleiro { get; set; }
        private Stopwatch Sw { get; set; }
        private Placar Placar { get; set; }
        
        //private FormPontuacaoSelect Fs { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            Conexao conexao = new Conexao();
            DbConnection dbConnection = conexao.Abre();
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
            conexao.CloseDbConnection();
        }
        private void LayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void PanelAtual_Paint(object sender, PaintEventArgs e)
        {
        }
        private void ButtonNJ_Click(object sender, EventArgs e)
        {
            Tetris();
        }
        private void ButtonPause_Click(object sender, EventArgs e)
        {
            if (Pause == false)
            {
                ParaRelogio();
                labelPause.Text = char.ToString((char)0x3b);
                Pause = true;
            }
            else
            {
                AcionaRelogio();
                labelPause.Text = char.ToString((char)0x34);
                Pause = false;
            }
            labelPause.Refresh();
            while (Pause)
            {
                Jogo.Espera();
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Up):
                    labelKey.Text = char.ToString((char)0xe1);
                    Jogo.RotacionaPeca();
                    break;
                case (Keys.Down):
                    labelKey.Text = char.ToString((char)0xe2);
                    Jogo.MoveAbaixo();
                    break;
                case (Keys.Left):
                    labelKey.Text = char.ToString((char)0xdf);
                    Jogo.MoveEsquerda();
                    break;
                case (Keys.Right):
                    labelKey.Text = char.ToString((char)0xe0);
                    Jogo.MoveDireita();
                    break;
            };
            // return the key to the base class if not used.
            //return base.ProcessDialogKey(keyData);
            return true;
        }
        public void Tetris()
        {
            labelPause.Text = char.ToString((char)0x34);
            buttonPause.Enabled = true;
            this.Pause = false;
            trackBarNivel.Enabled = false;
            this.Sw = new Stopwatch();
            this.Tabuleiro = Tabuleiro.GetInstance(panelTabuleiro);
            this.Tabuleiro.Inicia();

            Placar = new Placar(Tabuleiro, trackBarNivel.Value);
            this.Jogo = new Jogo(Tabuleiro, Placar);

            bool over = false;
            Jogo.At = new Peca(Tabuleiro, panelAtual);
            Jogo.Prox = null;

            AcionaRelogio();

            while (!over)
            {
                GeraProx();
                over = Jogo.Percorre();
            }
            ParaRelogio();
            labelPause.Text = char.ToString((char)0x3c);
            MessageBox.Show("Game Over");
            SalvaPontuacao();
            buttonPause.Enabled = false;
            trackBarNivel.Enabled = true;
        }
        private void SalvaPontuacao()
        {
            this.Controls.Add(this.panelPlacar);
            FormPontuacaoInsert fp = new FormPontuacaoInsert(Placar, Sw, panelPlacar.Controls);
            
            Conexao conexao = new Conexao();
            DbConnection dbConnection = conexao.Abre();
            conexao.VerifyDbConnection();
            if (dbConnection != null)
            {
                fp.ShowDialog();
            }
            conexao.CloseDbConnection();
        }
        private void GeraProx()
        {
            if (Jogo.Prox != null)
            {
                Jogo.Prox.Ap = panelAtual;
                Jogo.At = Jogo.Prox;
                Jogo.At.AtualizaPeca();
            }
            Jogo.Prox = new Peca(Tabuleiro, panelProx);
        }
        private void ButtonTGD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("https://github.com/tiago-ifrs/Desafio---Tetris" +
                            "\n" +
                            "tgdbr@yahoo.com.br",
                            "Tetris 21");
        }
        private void AcionaRelogio()
        {
            Sw.Start();
            timerJogo.Start();
        }
        private void ParaRelogio()
        {
            Sw.Stop();
            timerJogo.Stop();
        }

        private void TimerJogo_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = Sw.Elapsed;
            gameTimerLabel.Text = string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
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






