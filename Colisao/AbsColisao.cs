using System;

public abstract class AbsColisao
{
    public abstract AbsColisao colisao { get; set; }
    public abstract int Ycoli { get; set; }
    public abstract int Xcoli { get; set; }
    public abstract Tabuleiro Tabuleiro { get; set; }
    public abstract Peca Peca { get; set; }
    public abstract int Ydest { get; set; }
    public abstract int Xdest { get; set; }
    public abstract void Detecta();
}
