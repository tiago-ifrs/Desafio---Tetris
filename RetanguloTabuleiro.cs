using System.Drawing;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public sealed class RetanguloTabuleiro : Panel
    {
        public int Valor { get; set; }
        public int X { get; init; }
        public int Y { get; init; }
        //public int Width { get; init; }
        //public int height { get; init; }
        public RetanguloTabuleiro()
        {
            Valor = 0;
            BackColor = Color.White;
            
        }
    }
}