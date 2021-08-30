using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Desafio___Tetris.View
{
    internal class GameView
    {
        internal BoardView BoardView { get; set; }
        internal PauseView PauseView { get; set; }
        internal PieceView PieceView { get; set; }
        internal ScoreView ScoreView { get; set; }
        public GameView()
        {
            
        }
    }
}
