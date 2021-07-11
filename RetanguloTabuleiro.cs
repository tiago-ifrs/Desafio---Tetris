using System;
using System.Drawing;
using System.Windows.Forms;

public class RetanguloTabuleiro:Panel
{
    public int Valor { get; set; }   
    public RetanguloTabuleiro() { }
    public static RetanguloTabuleiro[][] Inicializa(Panel pai, int qy, int qx, int alt, int larg)
    {
        RetanguloTabuleiro[][] rt;
        int xform, yform;
        pai.Controls.Clear();

        rt = new RetanguloTabuleiro[qy][];

        for (int i = 0; i < qy; i++)
        {
            rt[i] = new RetanguloTabuleiro[qx];
            for (int j = 0; j < qx; j++)
            {
                rt[i][j] = new RetanguloTabuleiro();
                xform = j * larg;
                yform = i * alt;

                rt[i][j].Valor = 0;
                rt[i][j].BackColor = Color.White;
                rt[i][j].Location = new Point(xform, yform);
                rt[i][j].Size = new Size(larg - 1, alt - 1);

                pai.Controls.Add(rt[i][j]);
            }
        }
        pai.Size = new Size(larg * qx, alt * qy);
        return rt;
    }
}
