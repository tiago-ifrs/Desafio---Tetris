﻿using System.Drawing;
using System.Threading;

public class Jogo
{
    private Peca at;
    private Peca prox;
    private readonly int ytab;   // coordenada y do tabuleiro
    private readonly Tabuleiro tabuleiro;
    bool pecaNova = false;
    public Jogo(Tabuleiro tabuleiro, Tela janelaAtual, Tela janelaProx)
    {
        this.tabuleiro = tabuleiro;
        this.at = new Peca(tabuleiro.Larg, tabuleiro.Alt, janelaAtual);
        this.prox = null;

        this.pecaNova = false;

        bool over = false;
        
        //bool colisaoX = false;
        bool colisaoY = false;
        bool tabXLivre = false;

        while (!over)
        {
            if(!pecaNova)
            {
                if(this.prox != null) 
                {
                    /*
                    this.prox.Tela = janelaAtual;
                    this.at = this.prox;
                    */
                    this.prox.Move(this.at);
                    //this.at.Tela = janelaProx;
                }

                this.prox = new Peca(tabuleiro.Larg, tabuleiro.Alt, janelaProx);
                pecaNova = true;
            }
            for (ytab = 0; ytab < tabuleiro.nlin; ytab++) // percorre as linhas do tabuleiro
            {
                int ypec;
                ypec = ~ytab & (at.QLinhas() - 1);         //inicializa posição y das peças com ytab de offset          
                for (int xtab = 0; xtab < at.QColunas(ypec); xtab++)        // percorre as colunas do tabuleiro abaixo da peça
                {
                    if (tabuleiro.Linhas[ytab][xtab].Valor == 0) //local vazio no tabuleiro
                    {
                        colisaoY = false; //não há colisão
                        tabXLivre = true; // posição livre
                    }
                    else // local ocupado no tabuleiro
                    {
                        tabXLivre = false;  // posição ocupada
                                            // pode haver colisão se a peça for 1
                        if (at.Ponto(ytab, xtab) == 1) // peça está ocupando posição x
                        {
                            colisaoY = true;
                            //empilhar peças
                        }

                        // comparar as 4 colunas da peça onde ela for cair no tabuleiro
                        // coordenadas do tabuleiro (xtab, ytab)

                        // percorre as colunas da peça se a posição não estiver livre no tabuleiro:
                        /*
                        for (xpec = 0; xpec < linTabAt.Length - 1; xpec++)
                        {
                            if (ultLinPecAt[xpec] == 1)
                            {
                                if (linTabAt[xpec] == 1)
                                {
                                    colisaoY = true;
                                    break;
                                }
                            }
                            else //uma das posiçoes é 0
                            {
                                colisaoY = false;
                            }
                        } // terminou de percorrer as colunas da peça
                        */
                    } //else local ocupado no tabuleiro			
                } //for xtab

                if (tabXLivre == true) // os 4 espaços inferiores estão vazios, peça cai
                {
                    if (pecaNova)
                    {
                        PoePeca();
                    }
                    if (!colisaoY)
                    {
                        MoveTabY();
                    }
                } // fim if tabXlivre
            } //for ytab
        }//while !over
    } //construtor
    private void PoePeca()
    {
        int ul = at.QLinhas() - 1;

        for (int ypec = 0; ypec <= ul; ypec++)
        {
            for (int xpec = 0; xpec < at.QColunas(ypec); xpec++)
            {
                tabuleiro.Linhas[ypec - ytab][xpec].Valor = at.Ponto(ypec - ytab, xpec);

                if (at.Ponto(ypec - ytab, xpec) == 1)
                {
                    tabuleiro.Linhas[ypec - ytab][xpec].Cor = at.Cor;
                }
                else
                {
                    tabuleiro.Linhas[ypec - ytab][xpec].Cor = Color.White;
                }
            }
        }
        pecaNova = false;
    }

    private void MoveTabY()
    {
        int ul = at.QLinhas() - 1;
        int uc = at.QColunas(ul);

        for (int ytaux = ytab; ytaux > 0; ytaux--)
        { 
            for (int xpec = 0; xpec < uc; xpec++)
            {
                //atualiza posição no tabuleiro
                tabuleiro.Linhas[ytaux][xpec].Valor = tabuleiro.Linhas[ytaux - 1][xpec].Valor;
                tabuleiro.Linhas[ytaux][xpec].Cor = tabuleiro.Linhas[ytaux - 1][xpec].Cor;
            }
        }
        if (ytab > 0) 
        {
            for (int xpec = 0; xpec < uc; xpec++)
            {
                tabuleiro.Linhas[0][xpec].Valor = 0;
                tabuleiro.Linhas[0][xpec].Cor = Color.AntiqueWhite;
            }
        }
        Thread.Sleep(1000);
    }
}
