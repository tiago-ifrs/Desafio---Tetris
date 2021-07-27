using System;
using System.Data.Common;
using System.Data.SQLite;

public class ConexaoSQLite:AbsConexao
{
    private const string caminho = "bancoSqlite\\tetris.db";
    private string connectionString = $"Data Source={pastaBase}{caminho}";
    public override DbConnection OpenDBConnection()
    {
        SQLiteConnection Connection;
        try
        {
            Connection = new SQLiteConnection(connectionString);
            Connection.Open();
        }
        catch (Exception ex)
        {
            throw new Exception("SQLiteConnection - " + ex.ToString());
        }
        return Connection;
    }
    public ConexaoSQLite() { }
}
