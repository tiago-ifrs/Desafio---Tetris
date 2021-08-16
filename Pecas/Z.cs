using System.Collections.Generic;
using System.Drawing;

public class Z : Abspeca
{
    private int _rot;
    public Z()
    {
        Rot = 0;
    }

    public override Color Cor => Color.Red;

    public override List<int[]> Linhas { get; set; }
    public override int Rot
    {
        get => _rot;
        set
        {
            _rot = value;
            switch (value % 2)
            {
                case 0:
                    this.Linhas = new List<int[]>{
                    new int[]{ 1,1,0 },
                    new int[]{ 0,1,1 }
                };
                    break;
                case 1:
                    this.Linhas = new List<int[]>{
                    new int[]{ 0,1 },
                    new int[]{ 1,1 },
                    new int[]{ 1,0 }
                };
                    break;
            }
        }
    }
}
