using System;
using System.Collections.Generic;
using System.Drawing;

public class S : Abspeca
{
    public S()
    {
        this.Linhas = null;
        switch (Rot % 2)
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

    public override Color Cor => Color.Green;

    public override int Rot { get; set; }

    public override List<int[]> Linhas { get; set; }
}
