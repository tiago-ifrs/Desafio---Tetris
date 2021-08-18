using System;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;

public class ConexaoOleDb:AbsConexao
{
    public override string PastaBase => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
    public override string Caminho => "Conexao\\conexao.udl";
    public override string ConnectionString => $"File Name={PastaBase}{Caminho}";
    public override DbConnection OpenDbConnection()
    {
        OleDbConnection oleDbConnection;
        try
        {
            oleDbConnection = new OleDbConnection(ConnectionString);
            oleDbConnection.Open();
        }
        catch (Exception ex)
        {
            throw new Exception("OleDBConnection - " + ex.ToString());
        }
        return oleDbConnection;
    }
    public ConexaoOleDb() { }
}
