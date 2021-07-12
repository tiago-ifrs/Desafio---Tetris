using System;
using System.Collections.Generic;

public class ColisaoX : AbsColisao
{
    public ColisaoX(Tabuleiro tabuleiro, Peca peca, int ydest, int xdest)
    {
        Peca = peca;
        Tabuleiro = tabuleiro;
        Ydest = ydest;
        Xdest = xdest;
        Ycoli = -1;
        Xcoli = -1;

        this.Detecta();
    }
    public override AbsColisao colisao { get; set; }
    public override int Ycoli { get; set; }
    public override int Xcoli { get; set; }
    public override Tabuleiro Tabuleiro { get; set; }
    public override Peca Peca { get; set; }
    public override int Ydest { get; set; }
    public override int Xdest { get; set; }

    public override void Detecta()
    {
        int ul = Peca.QLinhas - 1;
        int uc = Peca.QColunas(ul);

        List<int> vetl = new List<int>();

        for (int i = 0; i < Tabuleiro.nlin; i++)
        {
            vetl.Add(Tabuleiro.Matrix[i][Xdest].Valor);
        }

        //vetl = vetl.GetRange(0, Ydest);

        if (vetl.Contains(1)) // existe uma posição ocupada onde a peça vai cair
        {
            /* PEÇA DEVE ESTAR LIMPA ANTES */
            for (int ypec = 0; ypec <= ul && (Ydest-ypec) >=0; ypec++)
            {
                for (int xpec = 0; xpec < uc && (Xdest + xpec) < Tabuleiro.ncol; xpec++)
                {
                    if ((Tabuleiro.Matrix[Ydest - ypec][Xdest + xpec].Valor & Peca.Ponto(ul - ypec, xpec)) == 0)
                    {
                        if (Peca.Ponto(ul - ypec, xpec) == 1)
                        {
                            //Matrix[ytab][xtab + xpec].Valor = 0;
                            //Matrix[ytab][xtab + xpec].BackColor = Color.Transparent;
                            //Matrix[ytab][xtab + xpec].Refresh();
                        }
                    }
                    else //houve colisão
                    {
                        /*
                         * COLISÃO X NÃO VAI DESENHAR ONDE ESTAVA
                         * Tabuleiro.DesenhaY(Peca, Ydest, Xdest); //desenha na linha anterior se houver colisão
                         */

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
}
