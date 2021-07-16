﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class Tabuleiro
{
    public readonly int nlin = 16;
    public readonly int ncol = 10;
    public RetanguloTabuleiro[][] Matrix { get; set; }
    public static Panel Panel { get; set; }
    private int Menor(int a, int b)
    {
        if (a < b)
            return a;
        else
            return b;
    }
    private Tabuleiro(Panel t)
    {
        Panel = t;
    }
    private static Tabuleiro _instance;
    public static Tabuleiro GetInstance(Panel t)
    {
        if (_instance == null)
        {
            _instance = new Tabuleiro(t);
        }
        return _instance;
    }
    public void Inicia() 
    {
        int l, a, menor;

        a = Panel.Height / nlin;
        l = Panel.Width / ncol;
        menor = Menor(l, a);
        Matrix = RetanguloTabuleiro.Inicializa(Panel, nlin, ncol, menor, menor);
    }
    public void Deleta(int ytab)
    {
        if (ytab > 0) // evita erro de indice ao mover valor da linha anterior
        {
            for (int i = 0; ytab - i > 0; i++) // de baixo pra cima
                                               // precisa mover até a linha 1 e não somente até o tamanho da peça  
            {
                for (int j = 0; j < ncol; j++)
                {
                    Matrix[ytab - i][j].Valor = Matrix[ytab - i - 1][j].Valor;
                    Matrix[ytab - i][j].BackColor = Matrix[ytab - i - 1][j].BackColor;
                    Matrix[ytab - i][j].Refresh();
                }
            }

            for (int j = 0; j < ncol; j++)
            {
                Matrix[0][j].Valor = 0;
                Matrix[0][j].BackColor = Color.White;
                Matrix[0][j].Refresh();
            }
        }
    }
    public bool DesenhaY(Peca p, int ytab, int xtab)
    {
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);
        int ypec = ul;
        int y = ytab;
        int qtdY = Menor(y, ul); //tratamento para evitar IndexOutofRangeException

        if (ytab < nlin) //evita erros de índice
        {
            for (; qtdY >= 0; y--, ypec--, qtdY--)
            {
                for (int xpec = 0; xpec < uc && (xtab + xpec) < ncol; xpec++)
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
    }
    public void LimpaPeca(Peca p, int ytab, int xtab)
    {
        /*
         NÃO PRECISA DETECTAR COLISÃO
        FUNÇÃO DE LIMPEZA
        CHAMADA PELA DETECÇÃO DE COLISÃO 
         */
        int ul = p.QLinhas - 1;
        int uc = p.QColunas(ul);

        for (int ypec = ul; ypec >= 0 && ytab >= 0; ypec--, ytab--)
        {
            for (int xpec = 0; xpec < uc; xpec++)
            {
                if (p.Ponto(ypec, xpec) == 1)
                {
                    Matrix[ytab][xtab + xpec].Valor = 0;
                    Matrix[ytab][xtab + xpec].BackColor = Color.White;
                    Matrix[ytab][xtab + xpec].Refresh();
                }
            }
        }

    }
}