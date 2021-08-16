using System.Collections.Generic;
using System.Drawing;

public class L:Abspeca
{
    private int _rot;
    public L()
	{
        Rot = 0;
    }
    public override Color Cor => Color.LightBlue;

    public override int Rot
    {
        get => _rot;
        set
        {
            _rot = value;
            switch (value)
            {
                case 0:
                    this.Linhas = new List<int[]>{
                    new int[]{ 1,0 },
                    new int[]{ 1,0 },
                    new int[]{ 1,1 }
                };
                    break;
                case 1:
                    this.Linhas = new List<int[]>{
                    new int[]{ 0,0,1 },
                    new int[]{ 1,1,1 }
                };
                    break;
                case 2:
                    this.Linhas = new List<int[]>{
                    new int[]{ 1,1 },
                    new int[]{ 0,1 },
                    new int[]{ 0,1 }
                };
                    break;
                case 3:
                    this.Linhas = new List<int[]>{
                    new int[]{ 1,1,1 },
                    new int[]{ 1,0,0 },
                };
                    break;
            }
        }
    } 
    
    public override List<int[]> Linhas { get; set; }
}
