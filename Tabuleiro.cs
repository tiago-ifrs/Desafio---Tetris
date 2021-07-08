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

    public bool PoePeca(Peca p, int ytab, int xtab)
    {
        if (!ColisaoY(p, ytab, xtab)) //detecta colisão somente na maior linha
        {
            int ul = p.QLinhas - 1;
            int uc = p.QColunas(ul);
            int ypec = ul;
            for (int y = ytab; y >= 0; y--)
            {
                if (ypec >= 0)
                {
                    for (int xpec = 0; xpec < uc; xpec++)
                    {
                        Matrix[y][xtab + xpec].Valor = p.Ponto(ypec, xpec);
                        Matrix[y][xtab + xpec].BackColor = p.CorPonto(ypec, xpec);
                        Matrix[y][xtab + xpec].Refresh();
                    }
                    ypec--;
                }
            }
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool MoveY(Peca p, int ytab, int xtab)
    {
        /*
         * FUNÇÃO DE MOVIMENTO NO EIXO DAS ORDENADAS (Y)
         */
        if (!ColisaoY(p, ytab, xtab))   // detecta colisão na linha onde a peça vai ser colocada
        {
            int ul = p.QLinhas - 1;
            int uc = p.QColunas(ul);
            int ypec = ul;

            for (int ynovo = ytab; ynovo >= 0; ynovo--)
            {
                if (ypec >= 0)
                {
                    for (int xpec = 0; xpec < uc; xpec++)
                    {
                        Matrix[ynovo][xtab + xpec].Valor = p.Ponto(ypec, xpec);
                        Matrix[ynovo][xtab + xpec].BackColor = p.CorPonto(ypec, xpec);
                        Matrix[ynovo][xtab + xpec].Refresh();
                    }
                    ypec--;
                }
            }
            LimpaAcima(p, ytab, xtab);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void XMove(Peca p, int ytab, int xtab)
    {
        /*
         * FUNÇÃO DE MOVIMENTO NO EIXO DAS ABSCISSAS (X)
         * DETECTAR COLISÃO NO EIXO X
         */
        //if (!ColisaoY(p, ytab, xtab)) 
        //{
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);
        int ypec = ul;
        for (int ynovo = ytab; ynovo >= 0; ynovo--)
        {
            if (ypec >= 0)
            {
                for (int xpec = 0; xpec < uc; xpec++)
                {
                    Matrix[ynovo][xtab + xpec].BackColor = p.CorPonto(ypec, xpec);
                    Matrix[ynovo][xtab + xpec].Valor = p.Ponto(ypec, xpec);
                    Matrix[ynovo][xtab + xpec].Refresh();
                }
                ypec--;
            }
        }
        /*
        return true;
    }
    else
    {
        return false;
    }
     */
    }

    public void EsquerdaLimpa(Peca p, int ytab, int xtab)
    {
        /*
         NÃO PRECISA DETECTAR COLISÃO NO EIXO X
        FUNÇÃO DE LIMPEZA DO LADO ESQUERDO
        CHAMADA PELA TECLA DE SETA DIREITA
         */
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);
        //tabuleiro está desenhando uma posição abaixo de ytab?

        int qtdY = Menor(ytab - 1, ul); //tratamento para evitar IndexOutofRangeException
        int xl = xtab - 1;
        if (xtab < ncol)
        {
            for (int y = 0; qtdY >= 0; qtdY--, y--)
            {
                Matrix[ytab - 1 + y][xl].Valor = 0;
                Matrix[ytab - 1 + y][xl].BackColor = Color.AntiqueWhite;
                Matrix[ytab - 1 + y][xl].Refresh();
            }
        }
    }
    public void DireitaLimpa(Peca p, int ytab, int xtab)
    {
        /*
         NÃO PRECISA DETECTAR COLISÃO NO EIXO X
        FUNÇÃO DE LIMPEZA DO LADO DIREITO
        CHAMADA PELA TECLA DE SETA ESQUERDA
         */
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);
        //tabuleiro está desenhando uma posição abaixo de ytab?

        int qtdY = Menor(ytab - 1, ul); //tratamento para evitar IndexOutofRangeException
        int xl = xtab + uc;
        if (xtab > 0)
        {
            for (int y = 0; qtdY >= 0; qtdY--, y--)
            {
                Matrix[ytab - 1 + y][xl].Valor = 0;
                Matrix[ytab - 1 + y][xl].BackColor = Color.AntiqueWhite;
                Matrix[ytab - 1 + y][xl].Refresh();
            }
        }
    }

    public void LimpaAcima(Peca p, int ytab, int xtab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);
        int y = ytab - 1 - ul;
        if (y >= 0)
        {
            for (int xpec = 0; xpec < uc; xpec++)
            {
                Matrix[y][xpec + xtab].Valor = 0;
                Matrix[y][xpec + xtab].BackColor = Color.White;
                Matrix[y][xpec].Refresh();
            }
        }
    }

    public bool ColisaoY(Peca p, int ytab, int xtab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);

        for (int ypec = ul; ypec >= 0; ypec--)
        {
            for (int xpec = 0; xpec < uc; xpec++)
            {
                if ((Matrix[ytab][xtab + xpec].Valor & p.Ponto(ypec, xpec)) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void LimpaPeca(Peca p, int ytab, int xtab)
    {
        /*
         NÃO PRECISA DETECTAR COLISÃO NO EIXO X
        FUNÇÃO DE LIMPEZA CHAMADA PELA SETA CIMA
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