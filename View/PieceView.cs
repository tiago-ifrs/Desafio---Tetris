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
                if (value != null)
                {
                    //cria os quadradinhos redimensionados conforme o tamanho da peça
                    this.ColumnCount = value.ColumnCount(value.LineCount - 1);
                    this.AtualizaPeca();
                }
            }
        }

        private Tabuleiro Tabuleiro { get; set; }

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
        */
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
        
        private int ColumnCount { get; set; }
        public PieceView(Panel panel)
        {
            this.Panel = panel;
            this.Tabuleiro = Tabuleiro.GetInstance();
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
        public void AtualizaPeca()
        {
            Panel.Controls.Clear();
            var nova = new RetanguloTabuleiro[Piece.LineCount][];
            for (int i = 0; i < Piece.LineCount; i++)
            {
                nova[i] = new RetanguloTabuleiro[Piece.ColumnCount(Piece.LineCount - 1)];
                for (int j = 0; j < Piece.ColumnCount(Piece.LineCount - 1); j++)
                {
                    int xform = j * Tabuleiro.Matrix[0][0].Width;
                    int yform = i * Tabuleiro.Matrix[0][0].Height;
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
            
        }
    }
}
