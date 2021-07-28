using Desafio___Tetris;
using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
public class Conexao
{
    private AbsConexao AbsConexao { get; set; }
    public DbConnection dbConnection { get; set; }
    public Conexao()
    {
        switch (Form1.TipoBanco.Name)
        {
            case nameof(OleDbConnection):
                AbsConexao = new ConexaoOleDB();
                break;
            case nameof(SQLiteConnection):
                AbsConexao = new ConexaoSQLite();
                break;
        }
    }
    
    public DbConnection Abre()
    {
        dbConnection = AbsConexao.OpenDBConnection();
        return dbConnection;
    }
    public void CloseDBConnection()
    {
        try
        {
            if (dbConnection != null)
            {
                if (dbConnection.State != ConnectionState.Closed)
                {
                    dbConnection.Close();
                }
                dbConnection.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("CloseDBConnection - " + ex.ToString());
        }
    }
    public void VerifyDBConnection()
    {
        if (dbConnection == null)
        {
            throw new Exception(" VerifyDBConnection - is null ");
        }
        if (dbConnection.State != ConnectionState.Open)
        {
            throw new Exception(" VerifyDBConnection - connection state is " + dbConnection.State.ToString());
        }
    }
}
