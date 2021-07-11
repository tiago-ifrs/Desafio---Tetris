using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class Placar
{
    private Tabuleiro Tabuleiro { get; }
    private Label Label { get; set; }
    private int pontos { get; set; }
    public Placar(Label label, Tabuleiro tabuleiro)
    {
        this.Tabuleiro = tabuleiro;
        this.Label = label;
        this.pontos = 0;
    }
    public void Atualiza(Peca peca, int ytab)
    {
        int ul = peca.QLinhas - 1;
        //int uc = peca.QColunas(ul);

        List<int> vetcol;
        List<List<int>> vetlin = new List<List<int>>();

        for (int j = 0; j < ytab; j++)
        {
            vetcol = new List<int>();
            for (int i = 0; i < Tabuleiro.ncol; i++)
            {
                vetcol.Add(Tabuleiro.Matrix[ytab-j][i].Valor);
            }
            vetlin.Add(vetcol);
        }

        for (int j = 0; j < ytab; j++)
        {
            if (!vetlin[j].Contains(0))
            {
                Tabuleiro.Atualiza(peca, ytab-j);
                pontos += 10;
                Label.Text = pontos.ToString();
                Label.Refresh();
            }
        }
    }
}
