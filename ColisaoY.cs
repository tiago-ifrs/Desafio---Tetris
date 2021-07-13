using System;
using System.Collections.Generic;
using System.Drawing;

public class ColisaoY : AbsColisao
{
    private int Yorig { get; set; }
    public ColisaoY(Tabuleiro tabuleiro, Peca peca, int yorig, int ydest, int xdest)
    {
        Peca = peca;
        Tabuleiro = tabuleiro;
        Yorig = yorig;
        Ydest = ydest;
        Xdest = xdest;
        Ycoli = -1;
        Xcoli = -1;

        this.Detecta();
    }
    public override void Detecta()
    {
        int ul = Peca.QLinhas - 1;
        int uc = Peca.QColunas(ul);

        List<int> vetl = new List<int>();

        for (int i = 0; i < Tabuleiro.Matrix[Ydest].Length; i++)
        {
            vetl.Add(Tabuleiro.Matrix[Ydest][i].Valor);
        }

        vetl = vetl.GetRange(Xdest, uc);

        if (vetl.Contains(1)) // existe uma posição ocupada onde a peça vai cair
        {
                

                for (int ypec = 0; ypec <= ul; ypec++)
                {
                    for (int xpec = 0; xpec < uc; xpec++)
                    {
                        if ((Tabuleiro.Matrix[Ydest - ypec][Xdest + xpec].Valor & Peca.Ponto(ul - ypec, xpec)) == 0)
                        {
                            if (Peca.Ponto(ul - ypec, xpec) == 1)
                            {
                            /*TESTE*/
                            //Matrix[Ydest - ypec][xtab + xpec].Valor = 0;
                            //Tabuleiro.Matrix[Ydest - ypec][Xdest + xpec].BackColor = Color.Transparent;
                            //Tabuleiro.Matrix[Ydest - ypec][Xdest + xpec].Refresh();
                        }
                    }
                        else //houve colisão
                        {
                        /*
                         * DESENHAR ONDE ESTAVA:
                         * Tabuleiro.DesenhaY(Peca, Ydest - 1, Xdest); //desenha na linha anterior se houver colisão
                         * AGORA NÃO
                         */
                        /*TESTE*/
                        //Matrix[Ydest - ypec][xtab + xpec].Valor = 0;
                        //Tabuleiro.Matrix[Ydest - ypec][Xdest + xpec].BackColor = Color.Black;
                        //Tabuleiro.Matrix[Ydest - ypec][Xdest + xpec].Refresh();

                            Ycoli = Ydest - ypec;
                            Xcoli = Xdest + xpec;
                            //return this;
                            colisao = this;
                            return;
                            //return true;
                        }
                    }
                }
        }
        //não houve colisão
        //return this;
        colisao = this;
        return;
    }
    public override AbsColisao colisao { get; set; }
    public override int Ycoli { get; set; }
    public override int Xcoli { get; set; }
    public override Tabuleiro Tabuleiro { get; set; }
    public override Peca Peca { get; set; }
    public override int Ydest { get; set; }
    public override int Xdest { get; set; }
}
