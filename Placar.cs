using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class Placar
{
    private Tabuleiro Tabuleiro { get; }
    private Label Label { get; set; }
    private int Pontos { get; set; }
    public Placar(Label label, Tabuleiro tabuleiro)
    {
        this.Tabuleiro = tabuleiro;
        this.Label = label;
        this.Pontos = 0;
    }
    public void Atualiza()
    {
        List<int> vetcol;
        List<List<int>> vetlin = new List<List<int>>();

        for (int j = 0; j < Tabuleiro.nlin; j++)
        {
            vetcol = new List<int>();
            for (int i = 0; i < Tabuleiro.ncol; i++)
            {
                vetcol.Add(Tabuleiro.Matrix[j][i].Valor);
            }
            vetlin.Add(vetcol);
        }

        for (int j = 0; j < Tabuleiro.nlin; j++)
        {
            if (!vetlin[j].Contains(0))
            {
                Tabuleiro.Deleta(j);
                Pontos += 10;
                Label.Text = Pontos.ToString();
                Label.Refresh();
            }
        }
    }
}
