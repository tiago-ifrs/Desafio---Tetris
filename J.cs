﻿using System;
using System.Collections.Generic;
using System.Drawing;

public class J : Abspeca
{
    public J()
    {
        {
            this.Linhas = null;
            switch (Rot)
            {
                case 0:
                    this.Linhas = new List<int[]>{
                    new int[]{ 0,1 },
                    new int[]{ 0,1 },
                    new int[]{ 1,1 }
                };
                    break;
                case 1:
                    this.Linhas = new List<int[]>{
                    new int[]{ 1,1,1 },
                    new int[]{ 0,0,1 },
                };
                    break;
                case 2:
                    this.Linhas = new List<int[]>{
                    new int[]{ 1,1 },
                    new int[]{ 1,0 },
                    new int[]{ 1,0 }
                };
                    break;
                case 3:
                    this.Linhas = new List<int[]>{
                    new int[]{ 1,0,0 },
                    new int[]{ 1,1,1 },
                };
                    break;
            }
        }
    }

    public override Color Cor => Color.Orange;

    public override int Rot { get; set; }

    public override List<int[]> Linhas { get; set; }
    
}
