using System.Data.Common;

namespace Desafio___Tetris.Conexoes
{
    public abstract class AbsConexao : DbConnection
    {
        public abstract string PastaBase { get; }
        public abstract string Caminho { get;}
        public abstract DbConnection DbConnection { get; set; }
        //public abstract string ConnectionString { get; }
        //public abstract DbConnection OpenDbConnection();
    }
}
