using System;
using System.Windows.Forms;

public class Placar
{
	private Tabuleiro Tabuleiro;
	public Placar(Label label, Tabuleiro tabuleiro)
	{
		this.Tabuleiro = tabuleiro;
	}
	public void Atualiza(Peca peca, int ytab) 
	{
		int ul = peca.QLinhas - 1;
		int uc = peca.QColunas(ul);
		int cont = 0;
		RetanguloTabuleiro[] rt;

		for(int i = 0; i < Tabuleiro.Matrix.Length; i++) //16
		{ 
			//Tabuleiro.Matrix[][].Valor
		}
	}
}
