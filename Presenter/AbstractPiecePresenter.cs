using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Desafio___Tetris.Model.Pecas;
using Desafio___Tetris.View;

namespace Desafio___Tetris.Presenter
{
    internal abstract class AbstractPiecePresenter
    {
        public abstract Panel Panel { get; set; }
        public abstract Piece Piece { get; set; }
        public abstract Tabuleiro Tabuleiro { get; set; }
        public abstract PieceView PieceView { get; set; }
        protected AbstractPiecePresenter(Panel panel)
        {
            this.Panel = panel;
        }
    }
}
