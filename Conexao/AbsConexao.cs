using System;
using System.Data.Common;
using System.IO;

public abstract class AbsConexao
{
    public abstract string pastaBase { get; }
    public abstract string caminho { get;}
    public abstract string connectionString { get; }
    public abstract DbConnection OpenDBConnection();
}
