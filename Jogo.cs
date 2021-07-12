using System;
using System.Windows.Forms;

public class Jogo
{
    private int Ytab { get; set; }   // coordenada y do tabuleiro
    private int Xtab { get; set; }   // coordenada x do tabuleiro
    private Panel JanelaAtual { get; set; }
    private Panel JanelaProx { get; set; }
    private Peca At { get; set; }
    private Peca Prox { get; set; }
    private Placar Placar { get; set; }
    private Tabuleiro Tabuleiro { get; set; }



    public Jogo(Tabuleiro t, Panel jA, Panel jP, Label lP)
    {
        this.Tabuleiro = t;
        this.JanelaAtual = jA;
        this.JanelaProx = jP;
        this.Placar = new Placar(lP, Tabuleiro);

    }
    private void GeraProx()
    {
        if (this.Prox != null)
        {
            this.Prox.ap = JanelaAtual;
            this.At = this.Prox;
            At.AtualizaPeca();
        }
        this.Prox = new Peca(Tabuleiro, JanelaProx);
    }
    public void Espera()
    {
        Wait(1000);
    }
    public void RotacionaPeca()
    {
        Tabuleiro.LimpaPeca(At, Ytab, Xtab); // precisa limpar o espaço da peça antes de rotacionar
        if (At.Rot < 4)
        {
            At.Rot++;
        }
        else
        {
            At.Rot = 0;
        }
        Tabuleiro.DesenhaY(At, Ytab, Xtab);
    }
    public void MoveAbaixo()
    {
        Colisao baixo;
        if (Ytab < Tabuleiro.nlin-1)
        {
            baixo = new Colisao(Tabuleiro, At, Ytab+1, Xtab); //detectar colisão uma linha abaixo

            if (baixo.Ycoli == -1)//não houve colisão
            {
                Tabuleiro.LimpaPeca(At, Ytab, Xtab);
                Ytab++;
                
                Tabuleiro.DesenhaY(At, Ytab, Xtab);
            }//if !colisaoY
        }
        /*
        if (colisaoY.Ycoli == -1)//não houve colisão
        {
            //detecção de colisão está limpando a peça, limpar de novo
            Tabuleiro.LimpaPeca(At, Ytab - 1, Xtab);
            Tabuleiro.DesenhaY(At, Ytab, Xtab);

        }//if !colisaoY
        else
        {
            Tabuleiro.DesenhaY(At, Ytab - 1, Xtab); //desenha na linha anterior se houver colisão
            if (colisaoY.Ycoli == 0) // colisão na 1ª linha, não é detectada pela classe colisão ainda
            {
                return true;
            }
            break;
        }
        */
        /*
        if (ytab < tabuleiro.nlin - at.QLinhas)
        {
            tabuleiro.LimpaPeca(at, ytab, xtab);//limpa o espaço da peça antes de alterar a variável
            ytab++;
            tabuleiro.DesenhaY(at, ytab, xtab); //verificar valor de ytab antes de mandar o parâmetro
        }
        */
    }
    public void MoveEsquerda()
    {
        if (Xtab > 0)
        {
            Tabuleiro.LimpaPeca(At, Ytab, Xtab);//limpa o espaço da peça antes de alterar a variável
            Xtab--;
            Tabuleiro.DesenhaY(At, Ytab, Xtab); //verificar valor de ytab antes de mandar o parâmetro
        }
    }
    public void MoveDireita()
    {
        if (Xtab < Tabuleiro.ncol - At.QColunas(At.QLinhas - 1))
        {
            Tabuleiro.LimpaPeca(At, Ytab, Xtab);//limpa o espaço da peça antes de alterar a variável
            Xtab++;
            Tabuleiro.DesenhaY(At, Ytab, Xtab); //verificar valor de ytab antes de mandar o parâmetro
        }
    }
    public bool Percorre()
    {
        //condições iniciais:
        this.At = new Peca(Tabuleiro, JanelaAtual);
        this.Prox = null;
        Colisao colisaoY;

        GeraProx();
        Xtab = (Tabuleiro.ncol - At.QColunas(At.QLinhas - 1)) / 2; // coordenada x inicial da queda de peças
        colisaoY = null;
        //for (ytab = 0; ytab < tabuleiro.nlin && colisaoY==false; ytab++) // percorre as linhas do tabuleiro. precisa testar a colisão a cada entrada no loop
        for (Ytab = 0; Ytab < Tabuleiro.nlin; Ytab++) // percorre as linhas do tabuleiro. precisa testar a colisão a cada entrada no loop
        {
            colisaoY = new Colisao(Tabuleiro, At, Ytab, Xtab);

            if (colisaoY.Ycoli == -1)//não houve colisão
            {
                //detecção de colisão está limpando a peça, limpar de novo
                Tabuleiro.LimpaPeca(At, Ytab - 1, Xtab);
                Tabuleiro.DesenhaY(At, Ytab, Xtab);

            }//if !colisaoY
            else
            {
                Tabuleiro.DesenhaY(At, Ytab - 1, Xtab); //desenha na linha anterior se houver colisão
                if (colisaoY.Ycoli == 0) // colisão na 1ª linha, não é detectada pela classe colisão ainda
                {
                    return true;
                }
                break;
            }
            Placar.Atualiza();
            Wait(1000);
        }
        return false;
    }
    private void Wait(int ms)
    {
        DateTime start = DateTime.Now;
        while ((DateTime.Now - start).TotalMilliseconds < ms)
            Application.DoEvents();
    }
}
