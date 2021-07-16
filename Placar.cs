﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

public class Placar
{
    private Tabuleiro Tabuleiro { get; }
    private int _qtdPecas { get; set; }
    private int[] Tempo { get; set; }
    private ControlCollection Controles { get; set; }
    public int Score { get; set; }
    public int Nivel { get; set; }
    public double Velo { get; set; }
    public Panel Panel { get; set; }
    public int QtdPecas
    {
        get 
        {
            return _qtdPecas;
        }
        set 
        {
            _qtdPecas = value;
            Controles["labelQtdPeca"].Text = value.ToString();
        }
    }
    public Placar(Tabuleiro tabuleiro, Panel panelPlacar)
    {
        this.Tabuleiro = tabuleiro;
        this.Panel = panelPlacar;
        this.Controles = panelPlacar.Controls;
        this.Score = 0;
        this.Nivel = 0;
        this.Tempo = new int[]
        {       854,
                800,
                724,
                680,
                610,
                543,
                500,                //2/s
                333,                //3/s
                250,                //4/s
                200,                //5/s
                166,                //6/s
                143,                //7/s
                125,                //8/s
                111,                //9/s
                100,                //10/s
                91,                 //11/s
                83,                 //12/s
                77,                 //13/s
                71,                 //14/s
                67,                 //15/s
                50};                //20/s
        this.Velo = this.Tempo[this.Nivel];
                
        //zera a label do placar a cada novo jogo
        Controles["labelPlacar"].Text = "0";
        Controles["labelLevel"].Text = "0";
        Controles["labelSpeed"].Text = Math.Round(1000 / this.Velo, 2).ToString() + " (linhas/s)"; 
        Controles["labelQtdPeca"].Text = "0"; 
    }
    public void Atualiza()
    {
        List<int> vetcol;
        List<int> indices = new List<int>();
        List<List<int>> vetlin = new List<List<int>>();

        for (int j = 0; j < Tabuleiro.nlin; j++)
        {
            vetcol = new List<int>();
            for (int i = 0; i < Tabuleiro.ncol; i++)
            {
                vetcol.Add(Tabuleiro.Matrix[j][i].Valor);
            }
            vetlin.Add(vetcol);
            if (!vetlin[j].Contains(0))
            {
                indices.Add(j);
            }
        }

        for (int j = 0; j < indices.Count; j++)
        {
            Tabuleiro.Deleta(indices[j]);

            Score += 10;
            Controles["labelPlacar"].Text = (Score).ToString();
            Controles["labelPlacar"].Refresh();
            Thread.Sleep((int)Tempo[Nivel]);
        }

        if (indices.Count > 0)
        {
            Nivel = (int)Score / 100;
            Controles["labelLevel"].Text = (Nivel).ToString();
            Controles["labelLevel"].Refresh();
            Velo = Tempo[Nivel];
            Controles["labelSpeed"].Text = Math.Round(1000/Velo, 2).ToString()+" (linhas/s)";
            Controles["labelSpeed"].Refresh();
        }
    }
}
