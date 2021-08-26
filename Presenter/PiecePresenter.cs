using System.Windows.Forms;
using Desafio___Tetris.Model.Pecas;
using Desafio___Tetris.View;

namespace Desafio___Tetris.Presenter
{
    internal class PiecePresenter:AbstractPiecePresenter
    {
        public override Panel Panel //ap = atual ou proximo
        {
            get => PieceView.Panel;
            set => PieceView.Panel = value;
        }
        public override Piece Piece
        {
            get => PieceView.Piece;
            set => PieceView.Piece = value;
        }
        public override Tabuleiro Tabuleiro
        {
            get => PieceView.Tabuleiro;
            set => PieceView.Tabuleiro = value;
        }
        public override PieceView PieceView { get; set; }
        public PiecePresenter(Panel panel) : base(panel)
        {
            this.Panel = panel;
            this.PieceView = new PieceView();
        }
    }
}