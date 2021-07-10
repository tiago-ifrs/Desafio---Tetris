using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class Tabuleiro
{
    public readonly int nlin = 16;
    public readonly int ncol = 10;
    public RetanguloTabuleiro[][] Matrix { get; }
    private int Menor(int a, int b)
    {
        if (a < b)
            return a;
        else
            return b;
    }
    public Tabuleiro(Panel t)
    {
        int l, a, menor;
        a = t.Height / nlin;
        l = t.Width / ncol;
        menor = Menor(l, a);
        Matrix = RetanguloTabuleiro.Inicializa(t, nlin, ncol, menor, menor);
    }

    public bool MoveY(Peca p, int ytab, int xtab)
    {
        /*
         * FUNÇÃO DE MOVIMENTO
         */
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

    public bool ColisaoY(Peca p, int ytab, int xtab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);
        List<int> vetl = new List<int>();

        for (int i = 0; i < Matrix[ytab].Length; i++)
        {
            vetl.Add(Matrix[ytab][i].Valor);
        }

        vetl = vetl.GetRange(xtab, uc);
        if (vetl.Contains(1)&&ytab>0) // existe uma posição ocupada onde a peça vai cair
        {
            LimpaPeca(p, ytab-1, xtab);
            for (int ypec = ul; ypec >= 0 && ytab >= 0; ypec--, ytab--)
            {
                for (int xpec = 0; xpec < uc; xpec++)
                {
                    if ((Matrix[ytab][xtab + xpec].Valor & p.Ponto(ypec, xpec)) == 0)
                    {
                        if (p.Ponto(ypec, xpec) == 1)
                        {
                            //Matrix[ytab][xtab + xpec].Valor = 0;
                            //Matrix[ytab][xtab + xpec].BackColor = Color.Transparent;
                            //Matrix[ytab][xtab + xpec].Refresh();
                        }
                    }
                    else
                    {
                        //LimpaPeca(p, ytab, xtab);
                        //MoveY(p, ytab, xtab);
                        /*
                        Matrix[ytab][xtab + xpec].BackColor = Color.Black;
                        Matrix[ytab][xtab + xpec].Refresh();
                        */
                        return true;
                    }
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
         */
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);

        //ytab = Menor(ul, ytab);
        //if (xtab >= 0 && xtab < ncol && ytab >= 0 && ytab < nlin) //restrições
        //{


        //for (int ypec = ul; ypec >= 0 && ytab >= 0; ypec--, ytab--)
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