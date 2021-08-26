using System.Collections.Generic;
using System.Drawing;

namespace Desafio___Tetris.Model.Pecas
{
    public class O : Abspeca
    {
        public O()
        {
            this.Linhas = new List<int[]>
            {
                new int[]     { 1,1 },
                new int[]     { 1,1 }
            };
        }
        public override Color Cor => Color.DarkOrange;

        public override int Rot { get; set; }

        public sealed override List<int[]> Linhas { get; set; }
    }
}
