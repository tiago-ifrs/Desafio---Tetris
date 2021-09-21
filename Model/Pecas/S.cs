using System.Collections.Generic;
using System.Drawing;

namespace Desafio___Tetris.Model.Pecas
{
    public class S : PieceAbstract
    {
        private int _rot;
        public S()
        {
            Rot = 0;
        }

        public override Color Cor => Color.Green;

        public override List<int[]> Linhas { get; set; }
        public sealed override int Rot
        {
            get => _rot;
            set
            {
                _rot = value;
                switch (value % 2)
                {
                    case 0:
                        this.Linhas = new List<int[]>{
                            new int[]{ 0,1,1 },
                            new int[]{ 1,1,0 }
                        };
                        break;
                    case 1:
                        this.Linhas = new List<int[]>{
                            new int[]{ 1,0 },
                            new int[]{ 1,1 },
                            new int[]{ 0,1 }
                        };
                        break;
                }
            
            }
        }
    }
}
