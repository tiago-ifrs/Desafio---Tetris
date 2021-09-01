namespace Desafio___Tetris.Model
{
    public class Score
    {
        #region TimesRegion
        public static readonly int[] Times =
        {
            854,
            800,
            724,
            680,
            610,
            543,
            500, //2/s
            333, //3/s
            250, //4/s
            200, //5/s
            166, //6/s
            143, //7/s
            125, //8/s
            111, //9/s
            100, //10/s
            91, //11/s
            83, //12/s
            77, //13/s
            71, //14/s
            67, //15/s
            50 //20/s
        };
        #endregion
        public int Points { get; set; }
        public int Level { get; set; }
        public int StartLevel { get; set; }
        public double Speed { get; set; }
        public int PieceCounter { get; set; }
        public Score()
        {
            Level = StartLevel;
            PieceCounter = 0;
            Points = 0;
            Speed = Times[StartLevel];
        }
    }
}
