using Desafio___Tetris.Model;
using Desafio___Tetris.Model.Pecas;

namespace Desafio___Tetris.Colisao
{
    public abstract class AbsColisao
    {
        public abstract AbsColisao Colisao { get; set; }
        public abstract int Ycoli { get; set; }
        public abstract int Xcoli { get; set; }
        public abstract Board Tabuleiro { get; set; }
        public abstract Piece Peca { get; set; }
        public abstract int Ydest { get; set; }
        public abstract int Xdest { get; set; }
        public abstract void Detecta();
    }
}
