using System;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;

public class ConexaoOleDB:AbsConexao
{
    public override string pastaBase => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
    public override string caminho => "Conexao\\conexao.udl";
    public override string connectionString => $"File Name={pastaBase}{caminho}";
    public override DbConnection OpenDBConnection()
    {
        OleDbConnection oleDbConnection;
        try
        {
            oleDbConnection = new OleDbConnection(connectionString);
            oleDbConnection.Open();
        }
        catch (Exception ex)
        {
            throw new Exception("OleDBConnection - " + ex.ToString());
        }
        return oleDbConnection;
    }
    public ConexaoOleDB() { }
}
