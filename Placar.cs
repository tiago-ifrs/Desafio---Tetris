using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Desafio___Tetris.View;
using static System.Windows.Forms.Control;

namespace Desafio___Tetris
{
    public class Placar
    {
        private Tabuleiro Tabuleiro { get; }
        public ScoreView ScoreView { get; set; }
        private int _qtdPecas { get; set; }
        private int NivelInicial { get; set; }
        public int Score { get; set; }
        public int Nivel { get; set; }
        public double Velo { get; set; }
        public int QtdPecas
        {
            get => _qtdPecas;
            set 
            {
                _qtdPecas = value;
                ScoreView.Speed = value;
            }
        }
        public Placar(Tabuleiro tabuleiro, ScoreView scoreView, int nivelInicial)
        {
            this.Tabuleiro = tabuleiro;
            this.ScoreView = scoreView;
            this.Score = 0;
            this.Nivel = this.NivelInicial = nivelInicial;
            this.Velo = ScoreView.Times[this.Nivel];

            //zera a label do placar a cada novo jogo
            //Initializes score labels each new game
            ScoreView.Score = 0;
            ScoreView.Level = Nivel;
            ScoreView.Speed = 1000 / this.Velo;
            ScoreView.PieceCounter = 0;
        }
        public void Atualiza()
        {
            List<int> indices = new List<int>();
            List<List<int>> vetlin = new List<List<int>>();

            for (int j = 0; j < Tabuleiro.Nlin; j++)
            {
                List<int> vetcol = new List<int>();
                for (int i = 0; i < Tabuleiro.Ncol; i++)
                {
                    vetcol.Add(Tabuleiro.Matrix[j][i].Valor);
                }
                vetlin.Add(vetcol);
                if (!vetlin[j].Contains(0))
                {
                    indices.Add(j);
                }
            }

            foreach (int t in indices)
            {
                Tabuleiro.Deleta(t);

                Score += 10;
                ScoreView.Score = Score;
                
                Thread.Sleep((int)ScoreView.Times[Nivel]);
            }

            if (indices.Count > 0)
            {
                Nivel = NivelInicial + ((int)Score / 100);
                ScoreView.Level = Nivel;
                if (Nivel < ScoreView.Times.Length)
                {
                    Velo = ScoreView.Times[Nivel];
                    ScoreView.Speed = 1000 / this.Velo;
                }
            }
        }
    }
}
