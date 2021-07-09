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
         * FUNÇÃO DE MOVIMENTO NO EIXO DAS ORDENADAS (Y)
         */
        bool col = false;

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

        /*   
            if (!ColisaoY(p, ytab, xtab))   // detecta colisão na linha onde a peça vai ser colocada
            {
                LimpaPeca(p, ytab, xtab);
                int ul = p.QLinhas - 1;
                int uc = p.QColunas(ul);
                int ypec = ul;

                for (int ynovo = ytab; ynovo >= 0; ynovo--, ypec--)
                {
                    if (ypec >= 0)
                    {
                        for (int xpec = 0; xpec < uc; xpec++)
                        {
                            if (p.Ponto(ypec, xpec) == 1)
                            {
                                Matrix[ynovo][xtab + xpec].Valor = p.Ponto(ypec, xpec);
                                Matrix[ynovo][xtab + xpec].BackColor = p.CorPonto(ypec, xpec);
                            }
                            Matrix[ynovo][xtab + xpec].Refresh();
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        */
    }

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

                //bool[] tabver = new bool[vetl.Capacity];
                //List<int> vetp = p.Linhas[ul].ToList();
                /*
                for (yp = 0; yp < 1; yp++) //pvirt.Count-1 pq está incrementando 1 na comparação
                                                          //for (int y=0; y< pvirt.Count-1;y++) //pvirt.Count-1 pq está incrementando 1 na comparação
                                                          // compara a linha de cima do tabuleiro com a última linha da peça
                {*/
                //for (xp = 0; xp< pvirt[yp].Count-1; xp++)
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

        if (xtab >= 0 && xtab < ncol && ytab >= 0 && ytab < nlin) //restrições
        {
            for (int ypec = ul; ypec >= 0 && ytab >= 0; ypec--, ytab--)
            {
                for (int xpec = 0; xpec < uc; xpec++)
                {
                    if (p.Ponto(ypec, xpec) == 1)
                    {
                        Matrix[ytab][xtab + xpec].Valor = 0;
                        Matrix[ytab][xtab + xpec].BackColor = Color.AntiqueWhite;
                        Matrix[ytab][xtab + xpec].Refresh();
                    }
                }
            }
        }
    }
}