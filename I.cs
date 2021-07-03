using System;
using System.Collections.Generic;
using System.Drawing;

public class I : Abspeca
{
    public override List<int[]> Linhas { get; set; }
    public I()
    {
        this.Linhas = null;
        switch (Rot)
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

    public override Color Cor => Color.LightCyan;

    public override int Rot { get; set; }
}
