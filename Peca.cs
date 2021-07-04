using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Peca : Abspeca
{
    //public int Larg { get; set; }
    //public int Alt { get; set; }
    public override List<int[]> Linhas { get; set; }
    public override Color Cor { get { return Abspeca.Cor; } }
    public override int Rot { get { return Abspeca.Rot; } set => Abspeca.Rot = value; }
    public int Ponto(int y, int x) { return (int)this.Abspeca.Linhas[y].GetValue(x); }
    private Abspeca Abspeca { get; set; }
    private RetanguloTabuleiro[][] Matrix;
    //this.prox.Tela = janelaAtual;
    public Panel ap { get; set; } //ap = atual ou proximo
    private readonly Tabuleiro tabuleiro;
    public Peca(Tabuleiro tab, Panel ap) 
    {
        char[] TiposPeca = { 'I', 'L', 'O', 'S', 'T', 'J', 'Z' };
        char Tpeca;

        int al;
        Random random = new Random();
        al = random.Next(0, TiposPeca.Length);
        Tpeca = TiposPeca[al];
        this.ap = ap;
        this.tabuleiro = tab;

        switch (Tpeca)
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
        // devem ser colocados depois da instanciação
        this.Abspeca.Rot = 0;
        //cria os quadradinhos redimensionados conforme o tamanho da peça
        int ql, qc, h, w;
        ql = QLinhas;
        qc = QColunas(QLinhas-1);
        //altura e largura do 1º quadradinho do tabuleiro:
        h = tab.Matrix[0][0].Height;
        w = tab.Matrix[0][0].Width;
        Matrix = RetanguloTabuleiro.Inicializa(ap, QLinhas, qc, h, w);
        AtualizaPeca();
    }
    /*
    public int QLinhas()
    {
        return this.Abspeca.Linhas.Count;
    }*/
    public int QLinhas { get { return this.Abspeca.Linhas.Count; } }
    public int QColunas(int y) { return this.Abspeca.Linhas[y].Length; }
    public void AtualizaPeca() 
    {
        RetanguloTabuleiro[][] nova;
        int xform, yform;
        
        ap.Controls.Clear();

        nova = new RetanguloTabuleiro[QLinhas][];
        for (int i = 0; i < QLinhas; i++)
        {
            nova[i] = new RetanguloTabuleiro[QColunas(QLinhas-1)];
            for (int j = 0; j < QColunas(QLinhas-1); j++)
            {
                xform = j * tabuleiro.Matrix[0][0].Width; //larg;
                yform = i * tabuleiro.Matrix[0][0].Height; //alt;
                nova[i][j] = new RetanguloTabuleiro
                {
                    Size = tabuleiro.Matrix[0][0].Size, //quadrados iguais, pega o primeiro índice
                    Location = new Point(xform, yform),
                    Valor = Ponto(i, j),
                    BorderStyle = BorderStyle.FixedSingle
                };

                if (Ponto(i, j) == 0)
                {
                    nova[i][j].BackColor = ap.BackColor;// Color.Black;
                }
                else 
                {
                    nova[i][j].BackColor = Abspeca.Cor;
                }
                ap.Controls.Add(nova[i][j]);
            }
        }
        ap.Size = new Size(ap.Controls[0].Width * QColunas(QLinhas - 1), ap.Controls[0].Height * QLinhas);
        Matrix = nova;
    }
}
