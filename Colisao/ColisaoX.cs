﻿using System;
using System.Collections.Generic;
using System.Drawing;

public class ColisaoX : AbsColisao
{
    private int Xorig { get; set; }
    private void VerificaDireita(int ul, int uc)
    {
        /* PEÇA DEVE ESTAR LIMPA ANTES */
        for (int ypec = 0; ypec <= ul && (Ydest - ypec) >= 0; ypec++)
        {
            /* XDEST VAI SER A LINHA DE VERIFICAÇÃO, NÃO ONDE A PEÇA COMEÇA*/
            for (int xpec = 0; xpec <= uc-1 && (Xdest - xpec) < Tabuleiro.ncol; xpec++) 
            {
                /*MOVIMENTO À DIREITA, O ÍNDICE X DA PEÇA DEVE PARTIR DE XDEST E DECREMENTAR*/
                /*ITERAR AO CONTRÁRIO*/
                /*no caso de movimento à direita, vai incrementar 1 na origem*/
                if ((Tabuleiro.Matrix[Ydest - ypec][Xdest - xpec].Valor & Peca.Ponto(ul-ypec, uc-1-xpec)) == 0)
                {
                    if (Peca.Ponto(ul-ypec, uc-1-xpec) == 1)
                    {
                        /*TESTE*/
                        //Matrix[Ydest - ypec][xtab + xpec].Valor = 0;
                        //Tabuleiro.Matrix[Ydest - ypec][Xdest - xpec].BackColor = Color.Transparent;
                        //Tabuleiro.Matrix[Ydest - ypec][Xdest - xpec].Refresh();
                    }
                }
                else //houve colisão
                {
                    /*
                     * COLISÃO X NÃO VAI DESENHAR ONDE ESTAVA
                     * Tabuleiro.DesenhaY(Peca, Ydest, Xdest); //desenha na linha anterior se houver colisão
                     */
                    /*TESTE*/
                    //Matrix[Ydest - ypec][xtab + xpec].Valor = 0;
                    //Tabuleiro.Matrix[Ydest - ypec][Xdest -xpec].BackColor = Color.Black;
                    //Tabuleiro.Matrix[Ydest - ypec][Xdest - xpec].Refresh();

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
    private void VerificaEsquerda(int ul, int uc) 
    {
        /* PEÇA DEVE ESTAR LIMPA ANTES */
        for (int ypec = 0; ypec <= ul && (Ydest - ypec) >= 0; ypec++)
        {
            for (int xpec = 0; xpec < uc && (Xdest + xpec) >= 0; xpec++) 
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
    //não houve colisão
    //return this;
        colisao = this;
        return;
    }
    public ColisaoX(Tabuleiro tabuleiro, Peca peca, int ydest, int xorig, int xdest)
    {
        Peca = peca;
        Tabuleiro = tabuleiro;
        Ydest = ydest;
        Xorig = xorig;
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

        List<int> vetc = new List<int>();

        for (int i = 0; i < Tabuleiro.nlin; i++)
        {
            vetc.Add(Tabuleiro.Matrix[i][Xdest].Valor);
        }

        //vetc = vetc.GetRange(Ydest-ul, ul+1);

        if (vetc.Contains(1)) // existe uma posição ocupada onde a peça vai cair
        {
            if (Xdest < Xorig)
            {
                VerificaEsquerda(ul, uc);
            }
            if (Xdest > Xorig)
            {
                VerificaDireita(ul, uc);
            }
        }
    }
}