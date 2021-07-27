using Desafio___Tetris;
using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
public class Conexao /*não deve ser singleton, pois a conexão é fechada após as consultas*/
{
    private static AbsConexao AbsConexao { get; set; }
    public static DbConnection dbConnection { get; set; }
    private Conexao()
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
        dbConnection = AbsConexao.OpenDBConnection();
    }
    private static Conexao _instance;
    public static Conexao GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Conexao();
        }
        return _instance;
    }
    public static DbConnection Abre()
    {
        GetInstance();
        return dbConnection;
    }
    public static void CloseDBConnection()
    {
        GetInstance();
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
    public static void VerifyDBConnection()
    {
        GetInstance();
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
