using System;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

public class ConexaoSQLite:AbsConexao
{
    public override string pastaBase => Path.GetFullPath(AppContext.BaseDirectory);
    public override string caminho => "tetris.db";
    public override string connectionString => $"Data Source={pastaBase}{caminho}";
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
