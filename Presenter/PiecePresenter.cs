using Desafio___Tetris.Model.Pecas;
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
        public PieceView PieceView { get; set; }
        public PiecePresenter()
        {
            Piece = new Piece();
            //this.PieceView = new PieceView(panel);
            //this.Panel = panel;
        }
    }
}