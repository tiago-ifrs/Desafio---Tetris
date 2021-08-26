using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Desafio___Tetris.Model.Pecas;

namespace Desafio___Tetris.View
{
    class PieceView
    {
        private Piece _piece { get; set; }
        public Piece Piece
        {
            get => _piece;
            set
            {
                _piece = value;
                //cria os quadradinhos redimensionados conforme o tamanho da peça
                this.ColumnCount = value.ColumnCount(value.LineCount - 1);
            }
        }
        private RetanguloTabuleiro[][] Matrix { get; set; }
        private Tabuleiro _tabuleiro { get; set; }
        public Tabuleiro Tabuleiro
        {
            get => _tabuleiro;
            set
            {
                _tabuleiro = value;
                //altura e largura do 1º quadradinho do tabuleiro:
                this.Height = Tabuleiro.Matrix[0][0].Height;
                this.Width = Tabuleiro.Matrix[0][0].Width;
            }
        }

        private Panel _panel { get; set; }
        public Panel Panel //ap = atual ou proximo
        {
            get => _panel;
            set
            {
                _panel = value;
                Matrix = RetanguloTabuleiro.Inicializa(value, Piece.LineCount, ColumnCount, Height, Width);
                this.AtualizaPeca();
            }
        }
        private int Height { get; set; }
        private int Width { get; set; }
        private int ColumnCount { get; set; }
        public PieceView()
        {
        }
        public void AtualizaPeca()
        {
            Panel.Controls.Clear();
            var nova = new RetanguloTabuleiro[Piece.LineCount][];
            for (int i = 0; i < Piece.LineCount; i++)
            {
                nova[i] = new RetanguloTabuleiro[Piece.ColumnCount(Piece.LineCount - 1)];
                for (int j = 0; j < Piece.ColumnCount(Piece.LineCount - 1); j++)
                {
                    int xform = j * Width;
                    int yform = i * Height;
                    nova[i][j] = new RetanguloTabuleiro
                    {
                        Size = Tabuleiro.Matrix[0][0].Size, //quadrados iguais, pega o primeiro índice
                        Location = new Point(xform, yform),
                        Valor = Piece.Ponto(i, j),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Piece.CorPonto(i, j)
                    };
                    Panel.Controls.Add(nova[i][j]);
                }
            }
            Panel.Size = new Size(Panel.Controls[0].Width * Piece.ColumnCount(Piece.LineCount - 1), Panel.Controls[0].Height * Piece.LineCount);
            Matrix = nova;
        }
    }
}
