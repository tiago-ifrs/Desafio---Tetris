using System;
using Desafio___Tetris.Model;
using Desafio___Tetris.View;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Desafio___Tetris.Presenter
{
    class ScorePresenter
    {
        public Score Score { get; set; }
        public TimeSpan TimeSpan
        {
            get => Score.TimeSpan;
            set
            {
                Score.TimeSpan = value;
                ScoreView.TimeSpan = value;
            }
        }

        public Timer Timer { get; set; }

        public int QtdPecas
        {
            get => ScoreView.PieceCounter;
            set => ScoreView.PieceCounter = value;
        }
        private ScoreView ScoreView { get; }
        public ScorePresenter(int startLevel)
        {
            ScoreView = new ScoreView
            {
                //Initializes score labels each new game
                Level = startLevel,
                PieceCounter = 0,
                Score = 0,
                Speed = Score.Times[startLevel]
            };
        }
        public void Atualiza()
        {
            List<int> indices = new List<int>();
            List<List<int>> vetlin = new List<List<int>>();

            for (int j = 0; j < Board.LineCount; j++)
            {
                List<int> vetcol = new List<int>();
                for (int i = 0; i < Board.ColumnCount; i++)
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

                Score.Points += 10;
                ScoreView.Score = Score.Points;

                Thread.Sleep((int)Score.Times[Score.Level]);
            }

            if (indices.Count > 0)
            {
                Score.Level = NivelInicial + ((int)Score.Points / 100);
                ScoreView.Level = Score.Level;
                if (Score.Level < Score.Times.Length)
                {
                    Score.Speed= Score.Times[Score.Level];
                    ScoreView.Speed = Score.Speed;
                }
            }
        }
    }
}
