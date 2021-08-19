using System;
using System.Collections.Generic;
using System.Threading;
using Desafio___Tetris.View;

namespace Desafio___Tetris
{
    public class Placar
    {
        private Tabuleiro Tabuleiro { get; }
        private ScoreView ScoreView { get; set; }
        private int NivelInicial { get; set; }
        public int Score { get; set; }
        public int Nivel { get; set; }
        public double Velo { get; set; }
        private int _qtdPecas { get; set; }
        public int QtdPecas
        {
            get => _qtdPecas;
            set 
            {
                _qtdPecas = value;
                ScoreView.PieceCounter = value;
            }
        }
        private TimeSpan _timeSpan { get; set; }
        public TimeSpan TimeSpan
        {
            get => _timeSpan;
            set
            {
                _timeSpan = value;
                ScoreView.TimeSpan = value;
            }
        }
        public Placar(Tabuleiro tabuleiro, int nivelInicial)
        {
            this.Tabuleiro = tabuleiro;
            this.Score = 0;
            this.Nivel = this.NivelInicial = nivelInicial;
            this.Velo = ScoreView.Times[this.Nivel];
            ScoreView = new ScoreView
            {
                //Initializes score labels each new game
                Score = 0,
                Level = Nivel,
                Speed = Velo,
                PieceCounter = 0
            };
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
                    ScoreView.Speed = Velo;
                }
            }
        }
    }
}
