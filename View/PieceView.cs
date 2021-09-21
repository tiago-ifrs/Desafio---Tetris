using Desafio___Tetris.Model;
using System.Drawing;
using System.Windows.Forms;

namespace Desafio___Tetris.View
{
    internal class PieceView
    {
        internal Panel Panel { get; set; }
        private Piece _piece { get; set; }
        internal int Width { get; set; }
        internal int Height { get; set; }
        public Piece Piece
        {
            get => _piece;
            set
            {
                _piece = value;
                if (value != null)
                {
                    //cria os quadradinhos redimensionados conforme o tamanho da peça
                    this.ColumnCount = Piece.ColumnCount(Piece.LineCount - 1);
                    //int width = Panel.Width / ColumnCount;
                    //int height = Panel.Height / Piece.LineCount;

                    RetanguloTabuleiro[][] rt = new RetanguloTabuleiro[Piece.LineCount][];
                    Panel.Controls.Clear();

                    for (int i = 0; i < Piece.LineCount; i++)
                    {
                        rt[i] = new RetanguloTabuleiro[ColumnCount];
                        for (int j = 0; j < ColumnCount; j++)
                        {
                            rt[i][j] = new RetanguloTabuleiro();
                            rt[i][j].Location = new Point(j * (Width), i * (Height));
                            rt[i][j].Size = new Size(Width - 1, Height - 1);
                            rt[i][j].BackColor = Piece.CorPonto(i, j);
                            Panel.Controls.Add(rt[i][j]);
                        }
                    }
                    Panel.Size = new Size(Width * ColumnCount, Height * Piece.LineCount);
                }
                //this.AtualizaPeca();
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
