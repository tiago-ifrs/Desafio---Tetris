using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public partial class Form1 : Form
    {
        private Jogo Jogo { get; set; }
        private bool Pause { get; set; }
        private Tabuleiro Tabuleiro { get; set; }
        private Stopwatch Sw { get; set; }
        private OleDbConnection oleDbConnection { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            oleDbConnection = Conexao.Abre();
            if(oleDbConnection != null) 
            {
                labelSQL.Text = "SQL: "+oleDbConnection.State.ToString();
                labelSQL.Visible = true;
                //FormPontuacaoSelect fs = new FormPontuacaoSelect();
                //fs.Show();
            }
        }
        private void LayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void PanelAtual_Paint(object sender, PaintEventArgs e)
        {
        }
        private void ButtonNJ_Click(object sender, EventArgs e)
        {
            this.Pause = false;
            Tetris();
        }
        private void ButtonPause_Click(object sender, EventArgs e)
        {
            if (Pause == false)
            {
                ParaRelogio();
                //labelPause.Text = "PAUSE";
                labelPause.Text = Char.ToString((char)0x3b);
                //labelPause.Visible = true;
                Pause = true;
            }
            else
            {
                AcionaRelogio();
                //labelPause.Visible = false;
                //labelPause.Text = "Tetris";
                labelPause.Text = Char.ToString((char)0x34);
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
                    labelKey.Text = Char.ToString((char)0xe1);
                    Jogo.RotacionaPeca();

                    return true;
                case (Keys.Down):
                    labelKey.Text = Char.ToString((char)0xe2);
                    Jogo.MoveAbaixo();

                    return true;
                case (Keys.Left):
                    labelKey.Text = Char.ToString((char)0xdf);
                    Jogo.MoveEsquerda();

                    return true;
                case (Keys.Right):
                    labelKey.Text = Char.ToString((char)0xe0);
                    Jogo.MoveDireita();

                    return true;
            };
            // return the key to the base class if not used.
            //return base.ProcessDialogKey(keyData);
            return true;
        }
        public void Tetris()
        {
            labelPause.Text = Char.ToString((char)0x34);
            buttonPause.Enabled = true;
            this.Sw = new Stopwatch();
            this.Tabuleiro = Tabuleiro.GetInstance(panelTabuleiro);
            this.Tabuleiro.Inicia();

            Placar p = new Placar(Tabuleiro, labelPlacar, labelLevel, labelSpeed, labelQtdPeca);

            this.Jogo = new Jogo(Tabuleiro, p);

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
            labelPause.Text = Char.ToString((char)0x3c);
            buttonPause.Enabled = false;
            MessageBox.Show("Game Over");
            SalvaPontuacao(p);
        }
        private void SalvaPontuacao(Placar pl) 
        {
            FormPontuacaoInsert fp = new FormPontuacaoInsert();

            oleDbConnection = Conexao.Abre();
            if (oleDbConnection != null)
            {
                double pcW, pcH;
                Bitmap captureBitmap = new Bitmap(panelTabuleiro.Width, panelTabuleiro.Height);
                Rectangle captureRectangle = new Rectangle(0, 0, panelTabuleiro.Width, panelTabuleiro.Height);
                panelTabuleiro.DrawToBitmap(captureBitmap, captureRectangle);
                pcW = fp.pictureBox.Width / panelTabuleiro.Width;
                pcH = fp.pictureBox.Height / panelTabuleiro.Height;
                Bitmap bitmapPictureBoxImage = new Bitmap(fp.pictureBox.Width, fp.pictureBox.Height);
                Graphics g = Graphics.FromImage(bitmapPictureBoxImage);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(captureBitmap, 0,0,fp.pictureBox.Width, fp.pictureBox.Height);
                fp.pictureBox.Image = bitmapPictureBoxImage;
                
                fp.ShowDialog();
                if(fp.DialogResult == DialogResult.OK)
                {
                    PontuacaoDAO pd = new PontuacaoDAO();
                    Pontuacao po = new Pontuacao();
                    po.Nome = fp.nome;
                    po.Score = pl.Score;
                    po.Nivel = pl.Nivel;
                    po.QtdPecas = pl.QtdPecas;
                    po.TempoJogo = Sw.Elapsed;
                    po.DataScore = DateTime.Now;
                    po.Tabuleiro = captureBitmap;
                    pd.Insert(po);
                }               
            }
        }
        private void GeraProx()
        {
            if (Jogo.Prox != null)
            {
                Jogo.Prox.ap = panelAtual;
                Jogo.At = Jogo.Prox;
                Jogo.At.AtualizaPeca();
            }
            Jogo.Prox = new Peca(Tabuleiro, panelProx);
        }
        private void ButtonTGD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("https://github.com/tiago-ifrs/Desafio---Tetris"+
                            "\n"+
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
            labelTimerJogo.Text = String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
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
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(sfd.FileName).ToLower();
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
                captureBitmap.Save(sfd.FileName, formato);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}






