using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;

namespace Desafio___Tetris.Conexoes
{
    public class ConexaoOleDb:AbsConexao
    {
        public override string PastaBase => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        public override string Caminho => "Conexao\\conexao.udl";
        public override DbConnection DbConnection { get; set; }
        public override string ConnectionString { get => $"File Name={PastaBase}{Caminho}"; set => throw new NotImplementedException(); }
        public override string Database => throw new NotImplementedException();

        public override string DataSource => throw new NotImplementedException();

        public override string ServerVersion => throw new NotImplementedException();

        public override ConnectionState State => throw new NotImplementedException();
        /*
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
*/
        public ConexaoOleDb() 
        {
            DbConnection = new OleDbConnection();
            DbConnection.Open();
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        protected override DbCommand CreateDbCommand()
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            throw new NotImplementedException();
        }
    }
}
