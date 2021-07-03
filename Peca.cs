using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Peca : Abspeca
{
    public int Larg { get; set; }
    public int Alt { get; set; }
    public override List<int[]> Linhas { get; set; }
    public override Color Cor { get { return Abspeca.Cor; } }
    public override int Rot { get { return Abspeca.Rot; } set => Abspeca.Rot = value; }
    public int Ponto(int y, int x)
    {
        return (int)this.Abspeca.Linhas[y].GetValue(x);
    }
    private char Tpeca;
    private Abspeca Abspeca { get; set; }
    private RetanguloTabuleiro[][] Matrix;
    //this.prox.Tela = janelaAtual;
    private Tela Tela { get ; }

    public void Move(Peca p) {
        Tela Nova = this.Tela;
        Abspeca = p;
        geraMatrix(Nova);
    }
    private void geraMatrix(Tela te)
    {
        int x, y, ul, uc;
        ul = QLinhas();
        uc = QColunas(ul - 1);

        if (Matrix != null)
        {
            this.Tela.LayoutPanel.Controls.Clear();
            Matrix = null;
        }

        Matrix = new RetanguloTabuleiro[ul][];

        for (int i = 0; i < ul; i++)
        {
            Matrix[i] = new RetanguloTabuleiro[uc];
            for (int j = 0; j < uc; j++)
            {
                x = j * Larg;
                y = i * Alt;

                Matrix[i][j] = new RetanguloTabuleiro
                {
                    Xy = new Point(x, y),
                    La = new Size(Larg - 1, Alt - 1)
                };

                if (Ponto(i, j) == 1)
                {
                    Matrix[i][j].Cor = Cor;
                    this.Tela.LayoutPanel.Controls.Add(Matrix[i][j].Panel);
                }
                /*
                else
                {
                    Matrix[i][j].Cor = Color.Black;
                }
                */
            }
        }
    }

    public Peca(int larg, int alt, Tela ap)
    {
        char[] TiposPeca = { 'I', 'L', 'O', 'S', 'T', 'J', 'Z' };

        int al;
        Random random = new Random();
        al = random.Next(0, TiposPeca.Length);
        this.Tpeca = TiposPeca[al];
        this.Larg = larg;
        this.Alt = alt;
        this.Matrix = null;
        switch (this.Tpeca)
        {
            case 'I':
                this.Abspeca = new I();
                break;
            case 'L':
                this.Abspeca = new L();
                break;
            case 'O':
                this.Abspeca = new O();
                break;
            case 'S':
                this.Abspeca = new S();
                break;
            case 'T':
                this.Abspeca = new T();
                break;
            case 'J':
                this.Abspeca = new J();
                break;
            case 'Z':
                this.Abspeca = new Z();
                break;
        }
        this.Abspeca.Rot = 0; // devem ser colocados depois da instanciação
        //geraMatrix(ap);
        this.Tela = ap;
    }
    public int QLinhas()
    {
        return this.Abspeca.Linhas.Count;
    }
    public int QColunas(int y)
    {
        return this.Abspeca.Linhas[y].Length;
    }
}
