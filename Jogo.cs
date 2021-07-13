using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class Jogo
{
    private int Ytab { get; set; }   // coordenada y do tabuleiro
    private int Xtab { get; set; }   // coordenada x do tabuleiro
    public Peca At { get; set; }
    public Peca Prox { get; set; }
    private Placar Placar { get; set; }
    private Tabuleiro Tabuleiro { get; set; }
    private int Yoffset { get; set; }
    public Jogo(Tabuleiro t, Label lP)
    {
        this.Tabuleiro = t;
        this.Placar = new Placar(lP, Tabuleiro);
        lP.Text = "0"; //zera a label do placar a cada novo jogo
    }
    public void Espera()
    {
        Wait(1000);
    }
    public void RotacionaPeca()
    {
        int ulAnt = At.QLinhas - 1;
        int ucAnt = At.QColunas(ulAnt);
        int rotAnt = At.Rot;
        ColisaoX Esquerda;
        Tabuleiro.LimpaPeca(At, Ytab + Yoffset, Xtab); // precisa limpar o espaço da peça antes de rotacionar
        if (At.Rot < 4)
        {
            At.Rot++;
        }
        else
        {
            At.Rot = 0;
        }
        /* 
         * DETECTAR COLISÃO HORIZONTAL ANTES DE DESENHAR
         * AS COLISÕES PODEM ACONTECEM NO LADO DIREITO, POIS XTAB É O PONTO DE ORIGEM DO DESENHO DA PEÇA
         */
        int ulPos = At.QLinhas - 1;
        int ucPos = At.QColunas(ulPos);
        if (Xtab + ucPos >= Tabuleiro.ncol)
        {
            Esquerda = new ColisaoX(Tabuleiro, At, Ytab + Yoffset, Xtab, Xtab - ucPos - ucAnt); //detectar colisão uma linha abaixo?
            if (Esquerda.Xcoli == -1)//não houve colisão
            {
                //mantém a rotação
                //move a peça para a esquerda
                Xtab -= ucPos - ucAnt;
            }
            else
            {
                At.Rot = rotAnt; //recupera a rotação anterior, impedindo o movimento
            }
        }
        /* DESENHA QUALQUER UMA DAS DUAS */
        Tabuleiro.DesenhaY(At, Ytab + Yoffset, Xtab);
    }
    public void MoveAbaixo()
    {
        ColisaoY baixo;
        if ((Ytab + Yoffset) < Tabuleiro.nlin - 1)
        {
            Tabuleiro.LimpaPeca(At, Ytab + Yoffset, Xtab);
            baixo = new ColisaoY(Tabuleiro, At, Ytab + Yoffset, Ytab + Yoffset + 1, Xtab); //detectar colisão uma linha abaixo

            if (baixo.Ycoli == -1)//não houve colisão
            {
                Yoffset++;               
            }
            Tabuleiro.DesenhaY(At, Ytab + Yoffset, Xtab);
        }

        /*
        int ul = At.QLinhas - 1;
        int uc = At.QColunas(ul);

        List<int> vetl = new List<int>();

        if ((Ytab + Yoffset) < Tabuleiro.nlin - 1)
        {
            for (int i = 0; i < Tabuleiro.Matrix[Ytab + Yoffset + 1].Length; i++)
            {
                vetl.Add(Tabuleiro.Matrix[Ytab + Yoffset + 1][i].Valor);
            }
            vetl = vetl.GetRange(Xtab, uc);
            if (!vetl.Contains(1))
            {
                Tabuleiro.LimpaPeca(At, Ytab + Yoffset, Xtab);

                Yoffset++;

                Tabuleiro.DesenhaY(At, Ytab + Yoffset, Xtab);
                Wait(100);
            }
            else //colisao
            {
            }

        }
        */

    }
    public void MoveEsquerda()
    {
        ColisaoX Esquerda;
        if (Xtab > 0)
        {
            /* Colisão X não vai limpar a peça 
             * precisa limpar para fazer o teste 
             */
            Tabuleiro.LimpaPeca(At, Ytab + Yoffset, Xtab);
            Esquerda = new ColisaoX(Tabuleiro, At, Ytab + Yoffset, Xtab, Xtab - 1); //detectar colisão uma linha abaixo?

            if (Esquerda.Xcoli == -1)//não houve colisão
            {
                Xtab--;
            }
            Tabuleiro.DesenhaY(At, Ytab + Yoffset, Xtab);
        }
    }
    public void MoveDireita()
    {
        int ul = At.QLinhas - 1;
        int uc = At.QColunas(ul);

        ColisaoX Direita;
        if (Xtab + uc < Tabuleiro.ncol)
        {
            /* Colisão X não vai limpar a peça 
             *  precisa limpar para fazer o teste 
             */
            Tabuleiro.LimpaPeca(At, Ytab + Yoffset, Xtab);
            Direita = new ColisaoX(Tabuleiro, At, Ytab + Yoffset, Xtab, Xtab + uc); //detectar colisão uma linha abaixo?

            if (Direita.Xcoli == -1)//não houve colisão
            {
                Xtab++;
            }
            Tabuleiro.DesenhaY(At, Ytab + Yoffset, Xtab);
        }
    }
    public bool Percorre()
    {
        //condições iniciais:
        Yoffset = 0;

        ColisaoY colisaoY;

        Xtab = (Tabuleiro.ncol - At.QColunas(At.QLinhas - 1)) / 2; // Centraliza a peça
        Placar.Atualiza();

        for (Ytab = 0; (Ytab + Yoffset) < Tabuleiro.nlin; Ytab++) // percorre as linhas do tabuleiro. precisa testar a colisão a cada entrada no loop
        {
            /*
             * NO LOOP PRINCIPAL, O PONTO DE COLISÃO É O PRÓPRIO PONTO A SER DESENHADO
             * NO CASO DE SETA ABAIXO, O YTAB FOI INCREMENTADO FORA DO LOOP
             */
            /*
                 * CASO DO LOOP FOR:
                 * PEÇA JÁ ESTÁ DESENHADA NA LINHA ANTERIOR, PODE IR PARA A ATUAL?
                 */
            Tabuleiro.LimpaPeca(At, Ytab - 1 + Yoffset, Xtab); //precisa limpar A ANTERIOR para fazer o teste
            colisaoY = new ColisaoY(Tabuleiro, At, Ytab + Yoffset, Ytab + Yoffset, Xtab); //destino é a linha atual

            if (colisaoY.Ycoli == -1)//não houve colisão
            {
                /*
                 * detecção de colisão está limpando a peça somente no caso de colisão
                 */
                Tabuleiro.LimpaPeca(At, Ytab + Yoffset - 1, Xtab);
                Tabuleiro.DesenhaY(At, Ytab + Yoffset, Xtab);

            }//if !colisaoY
            else
            {
                /*
                 * DETECTOR DE COLISÃO VAI DESENHAR A PEÇA NO PONTO ANTERIOR
                 *
                 
                 */
                Tabuleiro.LimpaPeca(At, Ytab + Yoffset - 1, Xtab);
                Tabuleiro.DesenhaY(At, Ytab + Yoffset - 1, Xtab);
                if (colisaoY.Ycoli < At.QLinhas)
                {
                    return true; // GAME OVER
                }
                break;
            }

            Wait(Placar.Tempo);
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
