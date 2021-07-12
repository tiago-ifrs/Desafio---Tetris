using System;
using System.Collections.Generic;

public class Colisao
{
    private Tabuleiro Tabuleiro { get; set; }
    private Peca Peca { get; set; }
    private int Yorig { get; set; }
    private int Xorig { get; set; }
    public int Ycoli { get; set; }
    public int Xcoli { get; set; }
    public Colisao colisao { get; set; }
	public Colisao(Tabuleiro tabuleiro, Peca peca, int yorig, int xorig)
	{
        this.Peca = peca;
        this.Tabuleiro = tabuleiro;
        this.Yorig = yorig;
        this.Xorig = xorig;
        this.Ycoli = -1;
        this.Xcoli = -1;
        this.ColisaoY();
	}
    public void ColisaoY()
    {
        int ul = Peca.QLinhas - 1;
        int uc = Peca.QColunas(ul);

        List<int> vetl = new List<int>();

        for (int i = 0; i < Tabuleiro.Matrix[Yorig].Length; i++)
        {
            vetl.Add(Tabuleiro.Matrix[Yorig][i].Valor);
        }

        vetl = vetl.GetRange(Xorig, uc);
        //if (vetl.Contains(1) && Yorig > 0) // existe uma posição ocupada onde a peça vai cair
        if (vetl.Contains(1)) // existe uma posição ocupada onde a peça vai cair
        {
            //LimpaPeca(p, ytab - 1, xtab); //precisa limpar para fazer o teste
            Tabuleiro.LimpaPeca(Peca, Yorig - 1, Xorig); //precisa limpar para fazer o teste
            for (int ypec = 0; ypec <= ul; ypec++)
            {
                for (int xpec = 0; xpec < uc; xpec++)
                {
                    if ((Tabuleiro.Matrix[Yorig-ypec][Xorig + xpec].Valor & Peca.Ponto(ul-ypec, xpec)) == 0)
                    {
                        if (Peca.Ponto(ul-ypec, xpec) == 1)
                        {
                            //Matrix[ytab][xtab + xpec].Valor = 0;
                            //Matrix[ytab][xtab + xpec].BackColor = Color.Transparent;
                            //Matrix[ytab][xtab + xpec].Refresh();
                        }
                    }
                    else //houve colisão
                    {
                        Ycoli = Yorig - ypec;
                        Xcoli = Xorig + xpec;
                        colisao = this;
                        return;
                        //return true;
                    }
                }
            }
        }
        //não houve colisão
        colisao = this;
        return ;
    }
}
