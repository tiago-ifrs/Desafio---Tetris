using System.Collections.Generic;
using System.Drawing;

namespace Desafio___Tetris.Model.Pecas
{
    public class I : Abspeca
    {
        private int _rot;
    
        public override List<int[]> Linhas { get; set; }
        public I()
        {
            Rot = 0;
        }

        public override Color Cor => Color.DarkBlue;

        public sealed override int Rot
        {
            get => _rot;
            set
            {
                _rot = value;
                switch (value)
                {
                    case 0:
                        this.Linhas = new List<int[]>
                        {
                            new int[]   { 1 },
                            new int[]   { 1 },
                            new int[]   { 1 },
                            new int[]   { 1 }
                        };
                        break;
                    case 1:
                        this.Linhas = new List<int[]>{
                            new int[]   { 1,1,1,1 }
                        };
                        break;
                    case 2:
                        this.Linhas = new List<int[]>{
                            new int[]   { 1 },
                            new int[]   { 1 },
                            new int[]   { 1 },
                            new int[]   { 1 }
                        };
                        break;
                    case 3:
                        this.Linhas = new List<int[]>{
                            new int[]   { 1,1,1,1 },
                        };
                        break;
                }
            }
        }
    }
}
