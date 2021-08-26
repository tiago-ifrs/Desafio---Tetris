using System;
using System.Collections.Generic;
using System.Drawing;

namespace Desafio___Tetris.Model.Pecas
{
    public sealed class Piece : Abspeca
    {
        public override List<int[]> Linhas { get; set; }
        public override Color Cor => Abspeca.Cor;
        public Color CorPonto(int y, int x)
        {
            return Ponto(y, x) == 0 ? Color.Transparent : Abspeca.Cor;
        }
        public override int Rot
        {
            get => Abspeca.Rot;
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
        public Piece()
        {
            char[] tiposPeca = { 'I', 'L', 'O', 'S', 'T', 'J', 'Z' };
            Random random = new Random();
            int al = random.Next(0, tiposPeca.Length);
            string tpeca = $"{this.GetType().Namespace}.{tiposPeca[al]}";
            Type type = Type.GetType(tpeca);
            
            Abspeca = (Abspeca)Activator.CreateInstance(type ?? throw new InvalidOperationException());
            if (Abspeca != null)
            {
                Abspeca.Rot = 0;
                Linhas = Abspeca.Linhas;
            }
        }
        public int LineCount => Abspeca.Linhas.Count;
        public int ColumnCount(int y) { return Abspeca.Linhas[y].Length; }
    }
}