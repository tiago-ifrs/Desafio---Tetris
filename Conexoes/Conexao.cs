using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Desafio___Tetris.Conexoes
{
    public class Conexao
    {
        private AbsConexao AbsConexao { get; set; }
        public DbConnection DbConnection { get; set; }
        public Conexao()
        {
            string dbt = this.GetType().ToString() +
                         ConfigurationManager.AppSettings.Get("DbType");

            Type type = Type.GetType(dbt);
            AbsConexao = (AbsConexao)Activator.CreateInstance(type ?? throw new InvalidOperationException());
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
                if (DbConnection == null) return;
                if (DbConnection.State != ConnectionState.Closed)
                {
                    DbConnection.Close();
                }
                DbConnection.Dispose();
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
}
