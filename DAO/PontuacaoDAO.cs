using Desafio___Tetris;
using System.Data.OleDb;
using System.Data.SQLite;

public class PontuacaoDao
{
    public AbsPontuacaoDao AbsPontuacaoDao { get; set; }
    public PontuacaoDao()
    {
        switch (Form1.TipoBanco.Name) 
        {
            case nameof(OleDbConnection):
                AbsPontuacaoDao = new PontuacaoDaoOleDb();
                break;
            case nameof(SQLiteConnection):
                AbsPontuacaoDao = new PontuacaoDaosqLite();
                break;
        }
    }
}
