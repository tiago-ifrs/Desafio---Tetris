using Desafio___Tetris.Model;
using Desafio___Tetris.View;

namespace Desafio___Tetris.Presenter
{
    internal class PiecePresenter
    {
        private Piece _piece { get; set; }
        public Piece Piece
        {
            get => _piece;
            set
            {
                _piece = value;
                if (PieceView != null)
                {
                    PieceView.Piece = value;
                }
            }
        }
        private PieceView _PieceView { get; set; }

        public PieceView PieceView
        {
            get => _PieceView;
            set
            {
                _PieceView=value;
                value.Width = this.Width;
                value.Height = this.Height;
            }
        }
        public int Height { get; set; }
        public int Width { get; set; }
        public PiecePresenter()
        {
        }
    }
}