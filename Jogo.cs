using System;
using System.Windows.Forms;

public class Jogo
{
    private int Ytab { get; set; }   // coordenada y do tabuleiro
    private int Xtab { get; set; }   // coordenada x do tabuleiro
    public Peca At { get; set; }
    public Peca Prox { get; set; }
    public Placar Placar { get; set; }
    public Tabuleiro Tabuleiro { get; set; }
    private int Yoffset { get; set; }
    public Jogo(Tabuleiro t, Placar p)
    {
        this.Tabuleiro = t;
        this.Placar = p;
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
        if (Xtab + ucPos >= Tabuleiro.Ncol)
        {
            //Direita = new ColisaoX(Tabuleiro, At, Ytab + Yoffset, Xtab, Xtab - ucPos - ucAnt); //detectar colisão uma linha abaixo?
            ColisaoX direita = new ColisaoX(Tabuleiro, At, Ytab + Yoffset, Xtab, Xtab - ucPos + ucAnt);
            if (direita.Xcoli == -1)//não houve colisão
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
        if ((Ytab + Yoffset) < Tabuleiro.Nlin - 1)
        {
            Tabuleiro.LimpaPeca(At, Ytab + Yoffset, Xtab);
            ColisaoY baixo = new ColisaoY(Tabuleiro, At, Ytab + Yoffset, Ytab + Yoffset + 1, Xtab);

            if (baixo.Ycoli == -1)//não houve colisão
            {
                Yoffset++;
            }
            Tabuleiro.DesenhaY(At, Ytab + Yoffset, Xtab);
        }
    }
    public void MoveEsquerda()
    {
        if (Xtab > 0)
        {
            /* Colisão X não vai limpar a peça 
             * precisa limpar para fazer o teste 
             */
            Tabuleiro.LimpaPeca(At, Ytab + Yoffset, Xtab);
            ColisaoX esquerda = new ColisaoX(Tabuleiro, At, Ytab + Yoffset, Xtab, Xtab - 1);

            if (esquerda.Xcoli == -1)//não houve colisão
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

        if (Xtab + uc < Tabuleiro.Ncol)
        {
            /* Colisão X não vai limpar a peça 
             *  precisa limpar para fazer o teste 
             */
            Tabuleiro.LimpaPeca(At, Ytab + Yoffset, Xtab);
            ColisaoX direita = new ColisaoX(Tabuleiro, At, Ytab + Yoffset, Xtab, Xtab + uc);

            if (direita.Xcoli == -1)//não houve colisão
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

        Xtab = (Tabuleiro.Ncol - At.QColunas(At.QLinhas - 1)) / 2; // Centraliza a peça
        Placar.Atualiza();
        Placar.QtdPecas++;

        for (Ytab = 0; (Ytab + Yoffset) < Tabuleiro.Nlin; Ytab++) // percorre as linhas do tabuleiro. precisa testar a colisão a cada entrada no loop
        {
            /*
             * NO LOOP PRINCIPAL, O PONTO DE COLISÃO É O PRÓPRIO PONTO A SER DESENHADO
             * NO CASO DE SETA ABAIXO, O YTAB FOI INCREMENTADO FORA DO LOOP
             *
             * CASO DO LOOP FOR:
             * PEÇA JÁ ESTÁ DESENHADA NA LINHA ANTERIOR, PODE IR PARA A ATUAL?
             */
            Tabuleiro.LimpaPeca(At, Ytab - 1 + Yoffset, Xtab); //precisa limpar A ANTERIOR para fazer o teste
            ColisaoY colisaoY = new ColisaoY(Tabuleiro, At, Ytab + Yoffset, Ytab + Yoffset, Xtab);

            if (colisaoY.Ycoli == -1)//não houve colisão
            {
                Tabuleiro.LimpaPeca(At, Ytab + Yoffset - 1, Xtab);
                Tabuleiro.DesenhaY(At, Ytab + Yoffset, Xtab);

            } 
            else
            {
                Tabuleiro.LimpaPeca(At, Ytab + Yoffset - 1, Xtab);
                Tabuleiro.DesenhaY(At, Ytab + Yoffset - 1, Xtab);
                if (colisaoY.Ycoli < At.QLinhas-1)
                {
                    return true; // GAME OVER
                }
                break;
            }
            Wait((int)Placar.Velo);
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
