using Desafio___Tetris;
using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
public class Conexao
{
    private AbsConexao AbsConexao { get; set; }
    public DbConnection DbConnection { get; set; }
    public Conexao()
    {
        switch (Form1.TipoBanco.Name)
        {
            case nameof(OleDbConnection):
                AbsConexao = new ConexaoOleDb();
                break;
            case nameof(SQLiteConnection):
                AbsConexao = new ConexaoSqLite();
                break;
        }
    }
    
    public DbConnection Abre()
    {
        DbConnection = AbsConexao.OpenDbConnection();
        return DbConnection;
    }
    public void CloseDbConnection()
    {
        try
        {
            if (DbConnection != null)
            {
                if (DbConnection.State != ConnectionState.Closed)
                {
                    DbConnection.Close();
                }
                DbConnection.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("CloseDBConnection - " + ex.ToString());
        }
    }
    public void VerifyDbConnection()
    {
        if (DbConnection == null)
        {
            throw new Exception(" VerifyDBConnection - is null ");
        }
        if (DbConnection.State != ConnectionState.Open)
        {
            throw new Exception(" VerifyDBConnection - connection state is " + DbConnection.State.ToString());
        }
    }
}
