using System.Drawing;
using System.Windows.Forms;

public class Tabuleiro
{
	public readonly int nlin = 16;
	public readonly int ncol = 10;
	public RetanguloTabuleiro[][] Matrix { get; }
	public Tabuleiro(Panel t)
	{
		int l, a, menor;
		a = t.Height / nlin;
		l = t.Width / ncol;
		if (l < a)
		{
			menor = l;
		}
		else {
			menor = a;
		}
				
		Matrix=RetanguloTabuleiro.Inicializa(t, nlin, ncol, menor, menor);
	}
}
