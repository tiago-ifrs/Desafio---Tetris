using System.Drawing;
using System.Windows.Forms;

public class Tabuleiro
{
	public readonly int nlin = 16;
	public readonly int ncol = 10;
	public RetanguloTabuleiro[][] Linhas { get; set; }

    public int Alt { get; }

    public int Larg { get; }

	public Panel LayoutPanel { get; }

	private void Inicializa() {
		int x, y;

		Linhas = new RetanguloTabuleiro[nlin][];	

		for (int i = 0; i < nlin; i++) 
		{
			Linhas[i] = new RetanguloTabuleiro[ncol];
			for (int j = 0; j < ncol; j++) {
				Linhas[i][j] = new RetanguloTabuleiro();
				x = j * Larg;
				y = i * Alt;
												
				Linhas[i][j].Cor = Color.Black;
				Linhas[i][j].Valor = 0;
				Linhas[i][j].Xy = new Point(x,y);
				Linhas[i][j].La = new Size(Larg-1, Alt-1);
				
				LayoutPanel.Controls.Add(Linhas[i][j].Panel);
			}
		}
	}
	
	public Tabuleiro(Tela t)
	{
		int l, a;
		a = t.Alt / nlin;
		l = t.Larg / ncol / 2;
		if (l < a)
		{
			this.Larg = this.Alt = a;
		}
		else {
			this.Larg = this.Alt = l;
		}
		this.LayoutPanel = t.LayoutPanel;
				
		Inicializa();
	}
}
