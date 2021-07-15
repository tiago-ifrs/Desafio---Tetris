using System;
using System.Data;
using System.Data.OleDb;
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
    public static void VerifyDBConnection(ref OleDbConnection _oDBConnection)
    {
        if (_oDBConnection == null)
            throw new Exception(" VerifyDBConnection - is null ");
        if (_oDBConnection.State != ConnectionState.Open)
            throw new Exception(" VerifyDBConnection - connection state is " + _oDBConnection.State.ToString());
    }

    public static OleDbConnection Abre() 
    {
        string caminho = "Conexao\\conexao.udl";
        string pastaBase = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        string  connectionString = $"File Name={pastaBase}{caminho}";
        return OpenDBConnection(connectionString);
    }
    public static void CloseDBConnection(ref OleDbConnection _oDBConnection)
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
