using Desafio___Tetris.Model.Pecas;
using System.Drawing;
using System.Windows.Forms;

namespace Desafio___Tetris.View
{
    class PieceView
    {
        public Panel CurrentPanel { get; set; }
        public Panel NextPanel { get; set; }
        private Piece _piece { get; set; }
        public Piece Piece
        {
            get => _piece;
            set
            {
                _piece = value;
                if (value != null)
                {
                    //cria os quadradinhos redimensionados conforme o tamanho da peça
                    this.ColumnCount = value.ColumnCount(value.LineCount - 1);
                    //this.AtualizaPeca();
                }
            }
        }
        private Size Size { get; set; }
        /*
        private Tabuleiro _tabuleiro { get; set; }
        public Tabuleiro Tabuleiro
        {
            get => _tabuleiro;
            set
            {
                _tabuleiro = value;
                if (value != null)
                {
                    //altura e largura do 1º quadradinho do tabuleiro:
                    this.Height = Tabuleiro.Matrix[0][0].Height;
                    this.Width = Tabuleiro.Matrix[0][0].Width;
                }
            }
        }
        
        private Panel _panel { get; set; }
        public Panel Panel //ap = atual ou proximo
        {
            get => _panel;
            set
            {
                _panel = value;
                //Inicializa(value, Piece.LineCount, ColumnCount, Height, Width);
            }
        }
        */
        private int ColumnCount { get; set; }
        public PieceView()
        {
        }
        public void Inicializa(Panel pai, int qy, int qx, int alt, int larg)
        {
            RetanguloTabuleiro[][] rt = new RetanguloTabuleiro[qy][];
            pai.Controls.Clear();

            for (int i = 0; i < qy; i++)
            {
                rt[i] = new RetanguloTabuleiro[qx];
                for (int j = 0; j < qx; j++)
                {
                    rt[i][j] = new RetanguloTabuleiro();
                    int xform = j * larg;
                    int yform = i * alt;

                    rt[i][j].Valor = 0;
                    rt[i][j].BackColor = Color.White;
                    rt[i][j].Location = new Point(xform, yform);
                    rt[i][j].Size = new Size(larg - 1, alt - 1);

                    pai.Controls.Add(rt[i][j]);
                }
            }
            pai.Size = new Size(larg * qx, alt * qy);
        }
        public void AtualizaPeca(Panel panel)
        {
            panel.Controls.Clear();
            var nova = new RetanguloTabuleiro[Piece.LineCount][];
            for (int i = 0; i < Piece.LineCount; i++)
            {
                nova[i] = new RetanguloTabuleiro[Piece.ColumnCount(Piece.LineCount - 1)];
                for (int j = 0; j < Piece.ColumnCount(Piece.LineCount - 1); j++)
                {
                    int xform = j * Size.Width;
                    int yform = i * Size.Height;
                    nova[i][j] = new RetanguloTabuleiro
                    {
                        Size = this.Size,
                        Location = new Point(xform, yform),
                        Valor = Piece.Ponto(i, j),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Piece.CorPonto(i, j)
                    };
                    panel.Controls.Add(nova[i][j]);
                }
            }
            panel.Size = new Size(panel.Controls[0].Width * Piece.ColumnCount(Piece.LineCount - 1), panel.Controls[0].Height * Piece.LineCount);
        }
    }
}
