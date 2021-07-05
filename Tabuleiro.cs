using System.Drawing;
using System.Windows.Forms;

public class Tabuleiro
{
    public readonly int nlin = 16;
    public readonly int ncol = 10;
    public RetanguloTabuleiro[][] Matrix { get; }
    public Tabuleiro(Panel t)
    {
        int l, a, menor;
        a = t.Height / nlin;
        l = t.Width / ncol;
        if (l < a)
        {
            menor = l;
        }
        else
        {
            menor = a;
        }

        Matrix = RetanguloTabuleiro.Inicializa(t, nlin, ncol, menor, menor);
    }

    public void PoePeca(Peca p, int ytab, int ypec)
    {
        for (int xpec = 0; xpec < p.QColunas(ypec); xpec++)
        {
            Matrix[0][xpec].Valor = p.Ponto(ypec, xpec);

            if (p.Ponto(ypec, xpec) == 1)
            {
                Matrix[0][xpec].BackColor = p.Cor;
            }
            else
            {
                Matrix[0][xpec].BackColor = Color.White;
            }
            Matrix[0][xpec].Refresh();
        }
    }
    public void MoveY(Peca p, int ytab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);

        for (int cont = ytab; cont >= 0; cont--)
        {
            for (int xpec = 0; xpec < uc; xpec++)
            {
                //atualiza posição abaixo no tabuleiro
                Matrix[cont + 1][xpec].Valor = Matrix[cont][xpec].Valor;
                Matrix[cont + 1][xpec].BackColor = Matrix[cont][xpec].BackColor;
                Matrix[cont + 1][xpec].Refresh();
            }
        }
    }
    public void TerminaPeca(Peca p)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);

        //atualiza posições acima no tabuleiro
        for (int xpec = 0; xpec < uc; xpec++)
        {
            Matrix[0][xpec].Valor = 0;
            Matrix[0][xpec].BackColor = Color.AntiqueWhite;
            Matrix[0][xpec].Refresh();
        }
    }
}
