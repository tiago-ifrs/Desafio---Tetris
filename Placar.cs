using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

public class Placar
{
    private Tabuleiro Tabuleiro { get; }
    private Label LabelScore { get; set; }
    private Label LabelLevel { get; set; }
    private Label LabelSpeed { get; set; }
    private Label LabelQtd { get; set; }
    private int Pontos { get; set; }
    private int[] Tempo { get; set; }
    public int Nivel { get; set; }
    public double Velo { get; set; }
    private int _QtdPecas { get; set; }
    public int QtdPecas
    {
        get 
        {
            return _QtdPecas;
        }
        set 
        {
            _QtdPecas = value;
            LabelQtd.Text = value.ToString();
        }
    }
    public Placar(Tabuleiro tabuleiro, Label labelScore, Label labelLevel, Label labelSpeed, Label labelqtd)
    {
        this.Tabuleiro = tabuleiro;
        this.LabelScore = labelScore;
        this.LabelLevel = labelLevel;
        this.LabelSpeed = labelSpeed;
        this.LabelQtd = labelqtd;
        this.Pontos = 0;
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
        LabelSpeed.Text = Math.Round(1000/this.Velo, 2).ToString() + " (linhas/s)"; 
        LabelScore.Text = "0"; //zera a label do placar a cada novo jogo
        LabelLevel.Text = "0";
        labelqtd.Text = "0";
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

            Pontos += 10;
            LabelScore.Text = (Pontos).ToString();
            LabelScore.Refresh();
            Thread.Sleep((int)Tempo[Nivel]);
        }

        if (indices.Count > 0)
        {
            Nivel = (int)Pontos / 100;
            LabelLevel.Text = (Nivel).ToString();
            LabelLevel.Refresh();
            Velo = Tempo[Nivel];
            LabelSpeed.Text = Math.Round(1000/Velo, 2).ToString()+" (linhas/s)";
            LabelSpeed.Refresh();
        }

    }
}
