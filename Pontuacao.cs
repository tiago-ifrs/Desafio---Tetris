using System;
using System.Drawing;

public class Pontuacao
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public int Score { get; set; }
	public int Nivel { get; set; }
	public TimeSpan TempoJogo { get; set; }
	public int QtdPecas { get; set; }
	public DateTime DataScore { get; set; }
	public Bitmap Tabuleiro { get; set; }
	public Pontuacao()
	{
	}
}
