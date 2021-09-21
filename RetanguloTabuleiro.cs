using System.Drawing;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public sealed class RetanguloTabuleiro : Panel
    {
        public int Valor { get; set; }
        public RetanguloTabuleiro()
        {
            Valor = 0;
            //BackColor = Color.White;
        }
    }
}