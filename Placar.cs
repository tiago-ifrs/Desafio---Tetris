using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

public class Placar
{
    private Tabuleiro Tabuleiro { get; }
    private Label Label { get; set; }
    private int Pontos { get; set; }
    public double[] Tempo { get; set; }
    public int nivel { get; set; }

    public Placar(Label label, Tabuleiro tabuleiro)
    {
        this.Tabuleiro = tabuleiro;
        this.Label = label;
        this.Pontos = 0;
        this.nivel = 0;
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
            Thread.Sleep((int)Tempo[nivel]);
            Pontos++;
            Label.Text = (Pontos*10).ToString();
            Label.Refresh();
        }

        if (indices.Count > 0)
        {
            
                nivel = (int) Math.Floor(Pontos/10);
            
        }

    }
}
