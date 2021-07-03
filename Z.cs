using System;
using System.Collections.Generic;
using System.Drawing;

public class Z : Abspeca
{
    public Z()
    {
        this.Linhas = null;
        switch (Rot % 2)
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

    public override Color Cor => Color.Red;

    public override int Rot { get; set; }

    public override List<int[]> Linhas { get; set; }

}
