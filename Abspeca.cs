using System;
using System.Collections.Generic;
using System.Drawing;

public abstract class Abspeca
{
	public abstract Color Cor { get; }
    public abstract int Rot { get; set; }
    public abstract List<int[]> Linhas { get; set; }
}
