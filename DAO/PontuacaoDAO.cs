using Desafio___Tetris;
using System.Data.OleDb;
using System.Data.SQLite;

public class PontuacaoDAO
{
    public AbsPontuacaoDAO AbsPontuacaoDAO { get; set; }
    public PontuacaoDAO()
    {
        switch (Form1.TipoBanco.Name) 
        {
            case nameof(OleDbConnection):
                AbsPontuacaoDAO = new PontuacaoDAOOleDb();
                break;
            case nameof(SQLiteConnection):
                AbsPontuacaoDAO = new PontuacaoDAOSQLite();
                break;
        }
    }
}
