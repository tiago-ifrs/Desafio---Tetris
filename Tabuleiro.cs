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
        if (!colisaoY(p, ytab+1, xtab))
        {
            int ul = p.QLinhas - 1;
            int uc = p.QColunas(ul);
            int mask = ul & ~ytab;
            for (int xpec = 0; xpec < uc; xpec++)
            {
                Matrix[0][xpec].Valor = p.Ponto(mask, xpec);
                Matrix[0][xpec].BackColor = p.CorPonto(mask, xpec);
                Matrix[0][xpec].Refresh();
            }
            return true;  //pôs a peça
        }
        else
        {
            return false;
        }
    }
    public bool MoveY(Peca p, int ytab, int xtab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);

        int ynovo = ytab + 1;
        int ypec = ul;

        int menor = Menor(ypec, ynovo);
        
        if (!colisaoY(p, ynovo, xtab)) //detecta colisão na linha onde a peça vai ser colocada, não precisa detecção para linhas anteriores
        {
            LimpaAcima(p, ytab, xtab);
            for (; menor >= 0; menor--)//peça é preenchida de baixo para cima
            {
                for (int xpec = 0; xpec < uc; xpec++)
                {
                    Matrix[ynovo][xtab + xpec].BackColor = p.CorPonto(ypec, xpec);                   
                    Matrix[ynovo][xtab + xpec].Valor = p.Ponto(ypec, xpec);
                    Matrix[ynovo][xtab + xpec].Refresh();
                }
                ynovo--;
                ypec--;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public void MoveX(Peca p, int ytab, int xtab)
    {
        //tabuleiro está desenhando uma posição abaixo de ytab?
        int ul = p.QLinhas-1;
        int uc = p.QColunas(ul);
        int ypec = 0;

        for (int y= ytab; y <= ul; y++) 
        {
            for (int xpec = 0; xpec < uc; xpec++)
            {
                Matrix[y][xtab + xpec].Valor = p.Ponto(ypec, xpec);
                Matrix[y][xtab + xpec].BackColor = p.CorPonto(ypec, xpec);
                Matrix[y][xtab + xpec].Refresh();
            }
            ypec++;
        }
        LimpaXant(p, ytab, xtab);
        LimpaAcima(p, ytab, xtab);
    }
    public void LimpaXant(Peca p, int ytab, int xtab)
    {
        int ul = p.QLinhas - 1;
        //tabuleiro está desenhando uma posição abaixo de ytab?
        //int ynovo = ytab+1;
        int ynovo = ytab;

        for (int ypec = ul; ypec >= 0; ypec--)
        {
            Matrix[ynovo][xtab - 1].Valor = 0;
            Matrix[ynovo][xtab - 1].BackColor = Color.Black;
            Matrix[ynovo][xtab - 1].Refresh();
            ynovo--;
        }
    }

    public void LimpaAcima(Peca p, int ytab, int xtab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);

        for (int ynovo = ytab - ul; ynovo >= 0; ynovo--)
        {
            for (int xpec = 0; xpec < uc; xpec++)
            {
                Matrix[ynovo][xpec + xtab].Valor = 0;
                Matrix[ynovo][xpec + xtab].BackColor = Color.AntiqueWhite;
                Matrix[ynovo][xpec].Refresh();
            }
        }
    }

    public bool colisaoY(Peca p, int linha, int xtab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);
        for (int xpec = 0; xpec < uc; xpec++)
        {
            if ((Matrix[linha][xtab+xpec].Valor & p.Ponto(ul, xpec)) == 1)
            {
                return true;
            }
        }
        return false;
    }
}
