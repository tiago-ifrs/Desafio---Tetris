using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class Tabuleiro
{
    public readonly int nlin = 16;
    public readonly int ncol = 10;
    public RetanguloTabuleiro[][] Matrix { get; set; }
    private int Menor(int a, int b)
    {
        if (a < b)
            return a;
        else
            return b;
    }
    private Tabuleiro(Panel t)
    {
        int l, a, menor;
        a = t.Height / nlin;
        l = t.Width / ncol;
        menor = Menor(l, a);
        Matrix = RetanguloTabuleiro.Inicializa(t, nlin, ncol, menor, menor);
    }
    private static Tabuleiro _instance;
    public static Tabuleiro GetInstance(Panel t)
    {
        if (_instance == null)
        {
            _instance = new Tabuleiro(t);
        }
        return _instance;
    }

    public void Deleta(int ytab)
    {
        if (ytab > 0) // evita erro de indice ao mover valor da linha anterior
        {
            for (int i = 0; ytab - i > 0; i++) // de baixo pra cima
                                               // precisa mover até a linha 1 e não somente até o tamanho da peça  
            {
                for (int j = 0; j < ncol; j++)
                {
                    Matrix[ytab - i][j].Valor = Matrix[ytab - i - 1][j].Valor;
                    Matrix[ytab - i][j].BackColor = Matrix[ytab - i - 1][j].BackColor;
                    Matrix[ytab - i][j].Refresh();
                }
            }

            for (int j = 0; j < ncol; j++)
            {
                Matrix[0][j].Valor = 0;
                Matrix[0][j].BackColor = Color.White;
                Matrix[0][j].Refresh();
            }
        }
    }

    public bool DesenhaY(Peca p, int ytab, int xtab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);
        int ypec = ul;
        int y = ytab;
        int qtdY = Menor(y, ul); //tratamento para evitar IndexOutofRangeException

        if (ytab < nlin) //evita erros de índice
        {
            for (; qtdY >= 0; y--, ypec--, qtdY--)
            {
                for (int xpec = 0; xpec < uc; xpec++)
                {
                    if (p.Ponto(ypec, xpec) == 1)
                    {
                        if (Matrix[y][xtab + xpec].Valor == 0)
                        {

                            Matrix[y][xtab + xpec].BackColor = p.CorPonto(ypec, xpec);
                        }
                        if (Matrix[y][xtab + xpec].Valor == 1) //colisão
                        {
                            //return false;
                        }
                    }
                    Matrix[y][xtab + xpec].Valor |= p.Ponto(ypec, xpec);
                    Matrix[y][xtab + xpec].Refresh();
                }
            }
        }
        return false;
    }



    /*
    public bool ColisaoY(Peca p, int ytab, int xtab)
    {
        if (ytab < nlin - 1 && ytab > 0)
        {
            int ul = p.QLinhas - 1;
            int uc = p.QColunas(ul);
            int yp = 0;
            int xp = 0;
            List<int> vetl = new List<int>();

            for (int i = 0; i < Matrix[ytab].Length; i++)
            {
                vetl.Add(Matrix[ytab+1][i].Valor);
            }

            vetl = vetl.GetRange(xtab, uc);
            if (vetl.Contains(1)) // existe uma posição ocupada onde a peça vai cair
            {
                List<int> posicoes = new List<int>();
                int[,] pvirt = new int[3, uc];

                for (int xa = 0; xa < uc; xa++)
                {
                    pvirt[0, xa] = Matrix[ytab + 1][xtab + xa].Valor;
                    pvirt[1, xa] = Matrix[ytab][xtab + xa].Valor;
                }
               
                for (int xa = 0; xa < uc; xa++)
                {
                    pvirt[2, xa] = p.Ponto(ul, xa);
                }

                for (xp = 0; xp < uc; xp++)
                {
                    //if ((pvirt[yp][xp] & pvirt[yp + 1][xp]) == 1)
                    if ((pvirt[0, xp] & pvirt[1, xp]) == 1)
                    {
                        posicoes.Add(xp);
                    }
                }
                //}
                if (posicoes.Count != uc)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
            return false;
    }
    */

    /*
    public bool ColisaoY(Peca p, int ytab, int xtab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);
        int xpec = 0;

        for (; xpec < uc; xpec++)
        {
            //if ((Matrix[ytab][xtab + xpec].Valor & p.Ponto(ul, xpec)) == 1)
            if ((Matrix[ytab][xtab + xpec].Valor & p.Ponto(ul, xpec)) == 1)
            {
                return true;
            }
        }
        return false;
    }
    */
    /*
    public bool ColisaoY(Peca p, int ytab, int xtab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);
        int cq = 0;
        int yc = ytab+1;
        int qtdY = Menor(ytab, ul); //tratamento para evitar IndexOutofRangeException

        if (xtab >= 0)
        {
            if (xtab < ncol - 1)
                for (int ypec = ul; qtdY > 0; qtdY--, ypec--, yc--) //for (int y = 0; qtdY >= 0; qtdY--, y--)
                {

                    for (int xpec = 0; xpec < uc; xpec++)
                    {

                        if ((Matrix[yc][xtab + xpec].Valor & p.Ponto(ypec, xpec)) == 1)
                        {
                            cq++;
                            return true;
                        }
                    }
                }
        }
        if (cq > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    */
    public void LimpaPeca(Peca p, int ytab, int xtab)
    {
        /*
         NÃO PRECISA DETECTAR COLISÃO
        FUNÇÃO DE LIMPEZA
        CHAMADA PELA DETECÇÃO DE COLISÃO 
         */
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);

        for (int ypec = ul; ypec >= 0 && ytab >= 0; ypec--, ytab--)
        {
            for (int xpec = 0; xpec < uc; xpec++)
            {
                if (p.Ponto(ypec, xpec) == 1)
                {
                    Matrix[ytab][xtab + xpec].Valor = 0;
                    Matrix[ytab][xtab + xpec].BackColor = Color.White;
                    Matrix[ytab][xtab + xpec].Refresh();
                }
            }
        }

    }
}