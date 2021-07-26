using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

public static class Conexao
{
    private static OleDbConnection OpenDBConnection(string _connectionString)
    {
        OleDbConnection oleDbConnection;
        try
        {
            oleDbConnection = new OleDbConnection(_connectionString);
            oleDbConnection.Open();
        }
        catch (Exception ex)
        {
            oleDbConnection = null;
            throw new Exception("OpenDBConnection - " + ex.ToString());
        }
        return oleDbConnection;
    }
    public static void VerifyDBConnection(ref DbConnection _oDBConnection)
    {
        if (_oDBConnection == null)
            throw new Exception(" VerifyDBConnection - is null ");
        if (_oDBConnection.State != ConnectionState.Open)
            throw new Exception(" VerifyDBConnection - connection state is " + _oDBConnection.State.ToString());
    }

    /*
     * CONEXÃO SQL SERVER
     */
    /*
    public static OleDbConnection Abre() 
    {
        string pastaBase = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));   
        string caminho = "Conexao\\conexao.udl";
        string connectionString = $"File Name={pastaBase}{caminho}";

        return OpenDBConnection(connectionString);
    }
    */
    public static SQLiteConnection Abre()
    {
        string pastaBase = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        string caminho = "bancoSqlite\\tetris.db";
        string connectionString = $"Data Source={pastaBase}{caminho}";
        
        return SQLiteConnection(connectionString);
    }

    private static SQLiteConnection SQLiteConnection(string connectionString)
    {
        SQLiteConnection Connection;
        try
        {
            Connection = new SQLiteConnection(connectionString);
            Connection.Open();
        }
        catch (Exception ex)
        {
            Connection = null;
            throw new Exception("SQLiteConnection - " + ex.ToString());
        }
        return Connection;
    }

    public static void CloseDBConnection(ref DbConnection _oDBConnection)
    {
        try
        {
            if (_oDBConnection != null)
            {
                if (_oDBConnection.State != ConnectionState.Closed)
                    _oDBConnection.Close();
                _oDBConnection.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("CloseDBConnection - " + ex.ToString());
        }
    }
}
