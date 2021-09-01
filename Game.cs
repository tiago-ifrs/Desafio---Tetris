using Desafio___Tetris.Model;
using Desafio___Tetris.Model.Pecas;

namespace Desafio___Tetris
{
    /// <summary>
    /// class Game must be public because of insertion
    /// </summary>
    public class Game
    {
        internal Time Time { get; set; }
        internal Piece CurrentPiece { get; set; }
        internal Piece NextPiece { get; set; }
        internal Score Score { get; set; }
        internal Board Board{ get; set; }
        internal bool Over { get; set; }
        internal int StartLevel
        {
            get => Score.StartLevel;
            init => Score.StartLevel = value;
        }
        internal Game()
        {
            Time = new Time
            {
                Paused = false
            };
            this.Board = new Board();
            this.Score = new Score();
            
            this.Over = false;
            this.CurrentPiece = new Piece();
            this.NextPiece = null;
        }
    }
}
