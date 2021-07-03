using System;
using System.Drawing;
using System.Windows.Forms;

public class RetanguloTabuleiro
{
    public Panel Panel { get; }
    public int Valor { get; set; }
    public Point Xy 
    { 
        get { return Panel.Location; } 
        set { Panel.Location = value; } 
    }   
    public Size La
    {
        get { return Panel.Size; }
        set { Panel.Size = value; }
    }
    public Color Cor
    {
        get { return Panel.BackColor; }
        set 
        { 
            Panel.BackColor = value;
            Panel.Refresh();
        }
    }
    public RetanguloTabuleiro()
    {
        this.Panel = new Panel();
    }
}
