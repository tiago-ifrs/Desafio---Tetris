using System.Collections.Generic;
using System.Drawing;

namespace Desafio___Tetris.Model.Pecas
{
    public abstract class PieceAbstract
    {
        public abstract Color Cor { get; }
        public abstract int Rot { get; set; }
        public abstract List<int[]> Linhas { get; set; }

        public PieceAbstract()
        {
            
        }
    }
}
