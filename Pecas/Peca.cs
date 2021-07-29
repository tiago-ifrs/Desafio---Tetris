using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Peca : Abspeca
{
    public override List<int[]> Linhas { get; set; }
    public override Color Cor
    {
        get { return Abspeca.Cor; }
    }
    public Color CorPonto(int y, int x)
    {
        if (Ponto(y, x) == 0)
        {
            return Color.Transparent;
        }
        else
        {
            return Abspeca.Cor;
        }
    }
    public override int Rot
    {
        get { return Abspeca.Rot; }
        set
        {
            Abspeca.Rot = value;
            Linhas = Abspeca.Linhas;
        }
    }
    public int Ponto(int y, int x)
    {
        return (int)Linhas[y].GetValue(x);
    }
    private Abspeca Abspeca { get; set; }
    private RetanguloTabuleiro[][] Matrix { get; set; }
    public Panel ap { get; set; } //ap = atual ou proximo
    private readonly Tabuleiro tabuleiro;
    public char Tpeca { get; }
    public Peca(Tabuleiro tab, Panel ap)
    {
        char[] TiposPeca = { 'I', 'L', 'O', 'S', 'T', 'J', 'Z' };
        Random random = new Random();
        int al = random.Next(0, TiposPeca.Length);
        Tpeca = TiposPeca[al];
        this.ap = ap;
        tabuleiro = tab;

        Type type = Type.GetType(Tpeca.ToString());
        Abspeca = (Abspeca)Activator.CreateInstance(type);

        // devem ser colocados depois da instanciação
        Abspeca.Rot = 0;
        Linhas = Abspeca.Linhas;
        //cria os quadradinhos redimensionados conforme o tamanho da peça
        int qc, h, w;
        qc = QColunas(QLinhas - 1);
        //altura e largura do 1º quadradinho do tabuleiro:
        h = tab.Matrix[0][0].Height;
        w = tab.Matrix[0][0].Width;
        Matrix = RetanguloTabuleiro.Inicializa(ap, QLinhas, qc, h, w);
        AtualizaPeca();
    }
    public int QLinhas { get { return Abspeca.Linhas.Count; } }
    public int QColunas(int y) { return Abspeca.Linhas[y].Length; }
    public void AtualizaPeca()
    {
        RetanguloTabuleiro[][] nova;
        int xform, yform;

        ap.Controls.Clear();

        nova = new RetanguloTabuleiro[QLinhas][];
        for (int i = 0; i < QLinhas; i++)
        {
            nova[i] = new RetanguloTabuleiro[QColunas(QLinhas - 1)];
            for (int j = 0; j < QColunas(QLinhas - 1); j++)
            {
                xform = j * tabuleiro.Matrix[0][0].Width; //larg;
                yform = i * tabuleiro.Matrix[0][0].Height; //alt;
                nova[i][j] = new RetanguloTabuleiro
                {
                    Size = tabuleiro.Matrix[0][0].Size, //quadrados iguais, pega o primeiro índice
                    Location = new Point(xform, yform),
                    Valor = Ponto(i, j),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = CorPonto(i, j)
                };
                ap.Controls.Add(nova[i][j]);
            }
        }
        ap.Size = new Size(ap.Controls[0].Width * QColunas(QLinhas - 1), ap.Controls[0].Height * QLinhas);
        Matrix = nova;
    }
}