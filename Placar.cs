using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

public class Placar
{
    private Tabuleiro Tabuleiro { get; }
    public Label LabelScore { get; set; }
    public Label LabelLevel { get; set; }
    public Label LabelSpeed { get; set; }
    private int Pontos { get; set; }
    private double[] Tempo { get; set; }
    public int Nivel { get; set; }
    public double Velo { get; set; }

    public Placar(Tabuleiro tabuleiro, Label labelScore, Label labelLevel, Label labelSpeed)
    {
        this.Tabuleiro = tabuleiro;
        this.LabelScore = labelScore;
        this.LabelLevel = labelLevel;
        this.LabelSpeed = labelSpeed;
        this.Pontos = 0;
        this.Nivel = 0;
        this.Tempo = new double[]
        {       883.333333333333,
                816.666666666667,
                750,
                683.333333333333,
                616.666666666667,
                550,
                466.666666666667,
                366.666666666667,
                283.333333333333,
                183.333333333333,
                166.666666666667,
                150,
                133.333333333333,
                116.666666666667,
                100,
                100,
                83.3333333333333,
                83.3333333333333,
                66.6666666666667,
                66.6666666666667,
                50};
        this.Velo = this.Tempo[this.Nivel];
        LabelSpeed.Text = Math.Round(this.Velo/1000, 2).ToString() + " s/linha"; 
        LabelScore.Text = "0"; //zera a label do placar a cada novo jogo
        LabelLevel.Text = "0";
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
            LabelSpeed.Text = Math.Round(Velo/1000, 2).ToString()+" s/linha";
            LabelSpeed.Refresh();
        }

    }
}
