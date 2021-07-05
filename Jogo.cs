using System.Drawing;
using System.Threading;
using System.Windows.Forms;

public class Jogo
{
    private readonly Peca at;
    private readonly Peca prox;
    private readonly int ytab;   // coordenada y do tabuleiro
    private readonly bool pecaNova = false;
    public Jogo(Tabuleiro tabuleiro, Panel janelaAtual, Panel janelaProx)
    {
        this.at = new Peca(tabuleiro, janelaAtual);
        this.prox = null;

        this.pecaNova = false;

        //condições iniciais:
        bool over = false;
        //bool colisaoX = false;
        bool colisaoY = false;
        bool tabXLivre = true;

        while (!over)
        {
            if(pecaNova)
            {
                if(this.prox != null) 
                {
                    this.prox.ap = janelaAtual;
                    this.at = this.prox;
                    at.AtualizaPeca();
                }

                this.prox = new Peca(tabuleiro, janelaProx);
                pecaNova = false;

            }
            
            for (ytab = 0; ytab < tabuleiro.nlin; ytab++) // percorre as linhas do tabuleiro
            {
                int ypec;
                int mask = at.QLinhas-1;

                //ypec = (~ytab & at.QLinhas)-1;         //inicializa posição y das peças com ytab de offset          
                ypec = (mask&~ytab);         //inicializa posição y das peças com ytab de offset          
                if (tabXLivre == true) // os 4 espaços inferiores estão vazios, peça cai
                {
                    if (ytab < at.QLinhas)
                    {
                        tabuleiro.PoePeca(at, ytab, ypec);
                    }
                    else
                    {
                        tabuleiro.TerminaPeca(at);
                        pecaNova = true;
                    }
                    if (!colisaoY)
                    {
                        tabuleiro.MoveY(at, ytab);
                        Thread.Sleep(1000);
                    }
                } // fim if tabXlivre
                for (int xtab = 0; xtab < at.QColunas(at.QLinhas-1); xtab++)        // percorre as colunas do tabuleiro abaixo da peça
                {
                    if (tabuleiro.Matrix[ytab][xtab].Valor == 0) //local vazio no tabuleiro
                    {
                        colisaoY = false; //não há colisão
                        tabXLivre = true; // posição livre
                    }
                    else // local ocupado no tabuleiro
                    {
                        tabXLivre = false;  // posição ocupada
                                            // pode haver colisão se a peça for 1
                        if (at.Ponto(ypec, xtab) == 1) // peça está ocupando posição x
                        {
                            colisaoY = true;
                            //empilhar peças
                        }

                        // comparar as 4 colunas da peça onde ela for cair no tabuleiro
                        // coordenadas do tabuleiro (xtab, ytab)

                        // percorre as colunas da peça se a posição não estiver livre no tabuleiro:
                        /*
                        for (xpec = 0; xpec < linTabAt.Length - 1; xpec++)
                        {
                            if (ultLinPecAt[xpec] == 1)
                            {
                                if (linTabAt[xpec] == 1)
                                {
                                    colisaoY = true;
                                    break;
                                }
                            }
                            else //uma das posiçoes é 0
                            {
                                colisaoY = false;
                            }
                        } // terminou de percorrer as colunas da peça
                        */
                    } //else local ocupado no tabuleiro			
                } //for xtab
            } //for ytab
        }//while !over
    } //construtor
}
