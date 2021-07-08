using System;
using System.Drawing;
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
    }
    public bool ColisaoY(Peca p, int ytab, int xtab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);

        for (int xpec = 0; xpec < uc; xpec++)
        {
            if ((Matrix[ytab][xtab + xpec].Valor & p.Ponto(ul, xpec)) == 1)
            {
                return true;
            }
        }
        return false;
    }
    public void LimpaPeca(Peca p, int ytab, int xtab)
    {
        /*
         NÃO PRECISA DETECTAR COLISÃO NO EIXO X
        FUNÇÃO DE LIMPEZA CHAMADA PELAS SETAS
         */
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);
        
        //tabuleiro está desenhando uma posição abaixo de ytab

        int qtdY = Menor(ytab - 1, ul); //tratamento para evitar IndexOutofRangeException
        int xl = xtab;
        if (xtab >= 0)
        {
            if (xtab < ncol - 1)
                for (int ypec = 0; qtdY >= 0; qtdY--, ypec--) //for (int y = 0; qtdY >= 0; qtdY--, y--)
                {
                    for (int xpec = 0; xpec < uc; xpec++)
                    {
                        Matrix[ytab - 1 + ypec][xl + xpec].Valor = 0;
                        Matrix[ytab - 1 + ypec][xl + xpec].BackColor = Color.White;
                        Matrix[ytab - 1 + ypec][xl + xpec].Refresh();
                    }
                }
        }
    }
}