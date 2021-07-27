using System;
using System.Data.Common;
using System.Data.OleDb;

public class ConexaoOleDB:AbsConexao
{
    private const string caminho = "Conexao\\conexao.udl";
    private string connectionString = $"File Name={pastaBase}{caminho}";
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
