﻿using System.Data.Common;

namespace Desafio___Tetris.Conexoes
{
    public abstract class AbsConexao
    {
        public abstract string PastaBase { get; }
        public abstract string Caminho { get;}
        public abstract string ConnectionString { get; }
        public abstract DbConnection OpenDbConnection();
    }
}
