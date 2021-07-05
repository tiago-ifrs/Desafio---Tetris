using System.Drawing;
using System.Threading;
using System.Windows.Forms;

public class Jogo
{
    private Peca at;
    private Peca prox;

    private readonly Tabuleiro tabuleiro;
    private readonly Panel janelaAtual;
    private readonly Panel janelaProx;

    private readonly int ytab;   // coordenada y do tabuleiro
    private void GeraProx() 
    {
        if (this.prox != null)
        {
            this.prox.ap = janelaAtual;
            this.at = this.prox;
            at.AtualizaPeca();
        }
        this.prox = new Peca(tabuleiro, janelaProx);
    }
    
    public Jogo(Tabuleiro tabuleiro, Panel janelaAtual, Panel janelaProx)
    {
        this.at = new Peca(tabuleiro, janelaAtual);
        this.prox = null;
        this.tabuleiro = tabuleiro;
        this.janelaAtual = janelaAtual;
        this.janelaProx = janelaProx;

        //condições iniciais:
        bool over = false;
        bool pecaNova = true;
        
        int ypec = -1;
        int ul = -1;
        while (!over)
        {
            if (pecaNova)
            {
                GeraProx();               
                pecaNova = false;
            }
            //atualiza o índice de peça após a geração de cada peça nova ou em condição inicial:
            ul = at.QLinhas - 1;
            ypec = ul;

            //condições atualizadas a cada nova peça
            //bool colisaoX = false;
            bool colisaoY = false;
            bool tabXLivre = true;
            bool terminaPeca = false;

            for (ytab = 0; ytab < tabuleiro.nlin-1; ytab++) // percorre as linhas do tabuleiro
            {
                if (tabXLivre == true) // os 4 espaços inferiores estão vazios, peça cai
                {
                    if (ypec >= 0)
                    {
                        tabuleiro.PoePeca(at, ytab, ypec);
                        ypec--;
                    }
                    else //ypec == -1
                    {
                        if (!pecaNova)
                        {
                            //tabuleiro.PoePeca(at, ytab, ypec);
                            //tabuleiro.TerminaPeca(at);
                            pecaNova = true;
                        }
                    }
                    if (!colisaoY)
                    {
                        for (int xtab = 0; xtab < at.QColunas(ul); xtab++)        // percorre as colunas do tabuleiro abaixo da peça
                        {
                            if (!colisaoY)
                            {
                                if (tabuleiro.Matrix[ytab + 1][xtab].Valor == 0) //local vazio no tabuleiro
                                {
                                    colisaoY = false; //não há colisão
                                    tabXLivre = true; // posição livre
                                }
                                else // local ocupado no tabuleiro
                                {
                                    tabXLivre = false;  // posição ocupada
                                                        // pode haver colisão se a peça for 1
                                    if (at.Ponto(ul, xtab) == 1) // peça está ocupando posição x
                                    {
                                        colisaoY = true;
                                        //empilhar peças
                                    }
                                } //else local ocupado no tabuleiro			
                            }
                        } //for xtab
                        if (!colisaoY)
                        {
                            tabuleiro.MoveY(at, ytab);

                            tabuleiro.LimpaAcima(at, ytab, ypec);
                            Thread.Sleep(1000);
                        }
                        
                    }
                } // fim if tabXlivre
                else
                {
                    if (colisaoY)
                    {
                        if(ytab < this.prox.QLinhas)
                        {
                            MessageBox.Show("Game Over");
                            over = true;
                        }
                    }
                }
            } //for ytab
            
        }//while !over
    } //construtor
}
