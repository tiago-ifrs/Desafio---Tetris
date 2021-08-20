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
            AbsConexao = (AbsConexao)Activator.CreateInstance(Type.GetType(dbt) ?? throw new InvalidOperationException());
            DbConnection = AbsConexao.DbConnection;
        }
        /*
        public DbConnection Abre()
        {
            DbConnection = OpenDbConnection();
            return DbConnection;
        }
        */       
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
