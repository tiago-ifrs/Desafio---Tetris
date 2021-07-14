using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

public class Placar
{
    private Tabuleiro Tabuleiro { get; }
    private Label Label { get; set; }
    private int Pontos { get; set; }
    public double Tempo { get; set; }
    public Placar(Label label, Tabuleiro tabuleiro)
    {
        this.Tabuleiro = tabuleiro;
        this.Label = label;
        this.Pontos = 0;
        this.Tempo = 1000;
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
            Thread.Sleep((int)Tempo/2);
            Pontos += 10;
            Label.Text = Pontos.ToString();
            Label.Refresh();
        }
        
        if (indices.Count > 0)
        {
            //Tempo = 1000- (int)(Pontos/(Math.PI/2));
        }
        
    }
}
