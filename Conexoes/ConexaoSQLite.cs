using System;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace Desafio___Tetris.Conexoes
{
    public class ConexaoSqLite:AbsConexao
    {
        public override string PastaBase => Path.GetFullPath(AppContext.BaseDirectory);
        public override string Caminho => "tetris.db";
        public override string ConnectionString => $"Data Source={PastaBase}{Caminho}";
        public override DbConnection OpenDbConnection()
        {
            SQLiteConnection connection;
            try
            {
                connection = new SQLiteConnection(ConnectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("SQLiteConnection - " + ex.ToString());
            }
            return connection;
        }
        public ConexaoSqLite() { }
    }
}
