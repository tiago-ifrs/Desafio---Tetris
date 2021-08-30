namespace Desafio___Tetris.Model
{
    public class Board
    {
        public static readonly int LineCount = 16;
        public static readonly int ColumnCount = 10;
        public RetanguloTabuleiro[][] Matrix { get; set; }
        public Board()
        {
        }
    }
}