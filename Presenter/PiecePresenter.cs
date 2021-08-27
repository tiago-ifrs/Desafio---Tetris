using System.Windows.Forms;
using Desafio___Tetris.Model.Pecas;
using Desafio___Tetris.View;

namespace Desafio___Tetris.Presenter
{
    internal class PiecePresenter
    {
        private Panel _panel { get; set; }
        public Panel Panel //ap = atual ou proximo
        {
            get => _panel;
            set
            {
                _panel = value;
                if (PieceView != null)
                {
                    PieceView.Panel = value;
                }
            }
        }
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
        public PiecePresenter(Panel panel) 
        {
            this.PieceView = new PieceView(panel);
            this.Panel = panel;
        }
    }
}