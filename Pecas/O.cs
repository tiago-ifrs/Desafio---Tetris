using System.Collections.Generic;
using System.Drawing;

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

    public override List<int[]> Linhas { get; set; }
}
