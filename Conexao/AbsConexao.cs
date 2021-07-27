using System;
using System.Data.Common;
using System.IO;

public abstract class AbsConexao
{
    public static readonly string pastaBase = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
    public abstract DbConnection OpenDBConnection();
}
