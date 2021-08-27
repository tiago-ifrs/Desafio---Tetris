using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Desafio___Tetris.View;

namespace Desafio___Tetris
{
    public class Placar
    {
        private Tabuleiro Tabuleiro { get; }
        private ScoreView ScoreView { get; }
        private int NivelInicial { get; }
        public int Score { get; set; }
        public int Nivel { get; set; }
        public double Velo { get; set; }
        public int QtdPecas
        {
            get => ScoreView.PieceCounter;
            set => ScoreView.PieceCounter = value;
        }
        public TimeSpan TimeSpan
        {
            get => ScoreView.TimeSpan;
            set => ScoreView.TimeSpan = value;
        }
        public Panel Output
        {
            get => ScoreView.Output;
            set => ScoreView.Output = value;
        }
        public Placar(int nivelInicial, Panel scorePlaceHolderPanel)
        {
            this.Tabuleiro = Tabuleiro.GetInstance();
            this.Score = 0;
            this.Nivel = this.NivelInicial = nivelInicial;
            this.Velo = ScoreView.Times[this.Nivel];
            ScoreView = new ScoreView
            {
                //Initializes score labels each new game
                Level = Nivel,
                PieceCounter = 0,
                Score = 0,
                Speed = Velo,
                Output = scorePlaceHolderPanel
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
