using System;
using System.Collections.Generic;

public abstract class AbsPontuacaoDAO
{
	public AbsPontuacaoDAO()
	{
	}
	public abstract void Insert(Pontuacao p);
	public abstract Pontuacao ImagemPorId(int id);
	public abstract List<Pontuacao> ListaTodos();
	public abstract List<Pontuacao> ListaTodosTLP();
}
