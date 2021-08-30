using System;
using System.Drawing;
using System.Windows.Forms;
using Desafio___Tetris.Model;
using Desafio___Tetris.Model.Pecas;

namespace Desafio___Tetris.Presenter
{
    public class BoardPresenter
    {
        public BoardPresenter()
        {
            this.Inicia();
        }
        public Board Board { get; set; }

        public void Inicia()
        {
            int a = Panel.Height / Board.LineCount;
            int l = Panel.Width / Board.ColumnCount;
            int menor = Math.Min(l, a);
            Inicializa(Board.LineCount, Board.ColumnCount, menor, menor);
        }
        public void Inicializa(int qy, int qx, int alt, int larg)
        {
            Board.Matrix = new RetanguloTabuleiro[qy][];
            this.Panel.Controls.Clear();

            for (int i = 0; i < qy; i++)
            {
                Board.Matrix[i] = new RetanguloTabuleiro[qx];
                for (int j = 0; j < qx; j++)
                {
                    Board.Matrix[i][j] = new RetanguloTabuleiro();
                    int xform = j * larg;
                    int yform = i * alt;

                    Board.Matrix[i][j].Valor = 0;
                    Board.Matrix[i][j].BackColor = Color.White;
                    Board.Matrix[i][j].Location = new Point(xform, yform);
                    Board.Matrix[i][j].Size = new Size(larg - 1, alt - 1);

                    Panel.Controls.Add(Board.Matrix[i][j]);
                }
            }
            Panel.Size = new Size(larg * qx, alt * qy);
        }
        public void Deleta(int ytab)
        {
            if (ytab > 0) // evita erro de indice ao mover valor da linha anterior
            {
                for (int i = 0; ytab - i > 0; i++) // de baixo pra cima
                                                   // precisa mover até a linha 1 e não somente até o tamanho da peça  
                {
                    for (int j = 0; j < Board.ColumnCount; j++)
                    {
                        Board.Matrix[ytab - i][j].Valor = Board.Matrix[ytab - i - 1][j].Valor;
                        Board.Matrix[ytab - i][j].BackColor = Board.Matrix[ytab - i - 1][j].BackColor;
                        Board.Matrix[ytab - i][j].Refresh();
                    }
                }

                for (int j = 0; j < Board.ColumnCount; j++)
                {
                    Board.Matrix[0][j].Valor = 0;
                    Board.Matrix[0][j].BackColor = Color.White;
                    Board.Matrix[0][j].Refresh();
                }
            }
        }
        public bool DesenhaY(Piece p, int ytab, int xtab)
        {
            int ul = p.LineCount - 1;
            int uc = p.ColumnCount(ul);
            int ypec = ul;
            int y = ytab;
            int qtdY = Math.Min(y, ul); //tratamento para evitar IndexOutofRangeException

            if (ytab < Board.LineCount) //evita erros de índice
            {
                for (; qtdY >= 0; y--, ypec--, qtdY--)
                {
                    for (int xpec = 0; xpec < uc && (xtab + xpec) < Board.ColumnCount; xpec++)
                    {
                        if (p.Ponto(ypec, xpec) == 1)
                        {
                            if (Board.Matrix[y][xtab + xpec].Valor == 0)
                            {
                                Board.Matrix[y][xtab + xpec].BackColor = p.CorPonto(ypec, xpec);
                            }
                            if (Board.Matrix[y][xtab + xpec].Valor == 1) //colisão
                            {
                                //return false;
                            }
                        }
                        Board.Matrix[y][xtab + xpec].Valor |= p.Ponto(ypec, xpec);
                        Board.Matrix[y][xtab + xpec].Refresh();
                    }
                }
            }
            return false;
        }
        public void LimpaPeca(Piece p, int ytab, int xtab)
        {
            /*
         NÃO PRECISA DETECTAR COLISÃO
        FUNÇÃO DE LIMPEZA
        CHAMADA PELA DETECÇÃO DE COLISÃO 
         */
            int ul = p.LineCount - 1;
            int uc = p.ColumnCount(ul);

            for (int ypec = ul; ypec >= 0 && ytab >= 0; ypec--, ytab--)
            {
                for (int xpec = 0; xpec < uc; xpec++)
                {
                    if (p.Ponto(ypec, xpec) == 1)
                    {
                        Board.Matrix[ytab][xtab + xpec].Valor = 0;
                        Board.Matrix[ytab][xtab + xpec].BackColor = Color.White;
                        Board.Matrix[ytab][xtab + xpec].Refresh();
                    }
                }
            }

        }
    }
}
