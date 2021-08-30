using System;
using System.Configuration;

namespace Desafio___Tetris.DAO
{
    public class PontuacaoDao
    {
        public AbsPontuacaoDao AbsPontuacaoDao { get; set; }
        public PontuacaoDao()
        {
            string dbt = this.GetType().ToString()+
                         ConfigurationManager.AppSettings.Get("DbType");
            AbsPontuacaoDao = Activator.CreateInstance(Type.GetType(dbt) ?? throw new InvalidOperationException()) as AbsPontuacaoDao;
        }
    }
}
