using System.Data.Common;

public abstract class AbsConexao
{
    public abstract string PastaBase { get; }
    public abstract string Caminho { get;}
    public abstract string ConnectionString { get; }
    public abstract DbConnection OpenDbConnection();
}
