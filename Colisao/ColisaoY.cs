public sealed class ColisaoY : AbsColisao
{
    public ColisaoY(Tabuleiro tabuleiro, Piece peca, int yorig, int ydest, int xdest)
    {
        Peca = peca;
        Tabuleiro = tabuleiro;
        Ydest = ydest;
        Xdest = xdest;
        Ycoli = -1;
        Xcoli = -1;

        this.Detecta();
    }
    public override void Detecta()
    {
        int ul = Peca.QLinhas - 1;
        int uc = Peca.QColunas(ul);

        for (int ypec = 0; ypec <= ul && (Ydest - ypec) >= 0; ypec++)
        {
            for (int xpec = 0; xpec < uc; xpec++)
            {
                if ((Tabuleiro.Matrix[Ydest - ypec][Xdest + xpec].Valor & Peca.Ponto(ul - ypec, xpec)) == 0)
                {
                    if (Peca.Ponto(ul - ypec, xpec) == 1)
                    {
                        /*TESTE*/
                        //Matrix[Ydest - ypec][xtab + xpec].Valor = 0;
                        //Tabuleiro.Matrix[Ydest - ypec][Xdest + xpec].BackColor = Color.Transparent;
                        //Tabuleiro.Matrix[Ydest - ypec][Xdest + xpec].Refresh();
                    }
                }
                else //houve colisão
                {
                    /*TESTE*/
                    //Matrix[Ydest - ypec][xtab + xpec].Valor = 0;
                    //Tabuleiro.Matrix[Ydest - ypec][Xdest + xpec].BackColor = Color.Black;
                    //Tabuleiro.Matrix[Ydest - ypec][Xdest + xpec].Refresh();

                    Ycoli = Ydest - ypec;
                    Xcoli = Xdest + xpec;
                    //return this;
                    Colisao = this;
                    return;
                    //return true;
                }
            }
        }
        //não houve colisão
        Colisao = this;
        return;
    }
    public override AbsColisao Colisao { get; set; }
    public override int Ycoli { get; set; }
    public override int Xcoli { get; set; }
    public override Tabuleiro Tabuleiro { get; set; }
    public override Piece Peca { get; set; }
    public override int Ydest { get; set; }
    public override int Xdest { get; set; }
}
