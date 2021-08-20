using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace Desafio___Tetris.Conexoes
{
    public class ConexaoSqLite : AbsConexao
    {
        public override string PastaBase => Path.GetFullPath(AppContext.BaseDirectory);
        public override string Caminho => $"{Database}.db";
        public override string ConnectionString { get => $"Data Source={DataSource}"; set => throw new NotImplementedException(); }
        public override string Database => "tetris";
        public override string DataSource => $"{PastaBase}{Caminho}";
        public override string ServerVersion => throw new NotImplementedException();
        public override ConnectionState State => DbConnection.State;
        public override DbConnection DbConnection { get; set; }
        public ConexaoSqLite()
        {
            DbConnection = new SQLiteConnection(ConnectionString);
            DbConnection.Open();
            if (!File.Exists(DataSource))
            {
                SQLiteConnection.CreateFile(DataSource);
            }
            using SQLiteCommand sQLiteCommand = new SQLiteCommand();
            sQLiteCommand.Connection = (SQLiteConnection)DbConnection;
            sQLiteCommand.CommandText = strings.SQLite_Create;
            try
            {
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erro sqlite" + e.Message);
            }
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
            try
            {
                if (DbConnection == null) return;
                if (State != ConnectionState.Closed)
                {
                    DbConnection.Close();
                }
                DbConnection.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(this.GetType().ToString() + ex.ToString());
            }
        }
        protected override DbCommand CreateDbCommand()
        {
            throw new NotImplementedException();
        }
        public override void Open()
        {
            try
            {
                DbConnection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(this.GetType().ToString() + ex.ToString());
            }
        }
    }
}