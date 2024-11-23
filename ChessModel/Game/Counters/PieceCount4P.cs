namespace ChessModel
{
    public class PieceCount4P : PieceCount
    {
        public Dictionary<PieceType, int> RedCount { get; set; }
        public Dictionary<PieceType, int> GreenCount { get; set; }
        public Dictionary<PieceType, int> YellowCount { get; set; }
        public Dictionary<PieceType, int> BlueCount { get; set; }

        public PieceCount4P()
        {
            RedCount = new Dictionary<PieceType, int>();
            GreenCount = new Dictionary<PieceType, int>();
            YellowCount = new Dictionary<PieceType, int>();
            BlueCount = new Dictionary<PieceType, int>();

            foreach(PieceType type in Enum.GetValues(typeof(PieceType)))
            {
                RedCount[type] = 0;
                GreenCount[type] = 0;
                YellowCount[type] = 0;
                BlueCount[type] = 0;
            }
        }

        public override void IncrementPieceCount(PlayerColor color, PieceType type)
        {
            switch (color)
            {
                case PlayerColor.Red:
                    RedCount[type]++;
                    break;
                case PlayerColor.Green:
                    GreenCount[type]++;
                    break;
                case PlayerColor.Yellow:
                    YellowCount[type]++;
                    break;
                case PlayerColor.Blue:
                    BlueCount[type]++;
                    break;
            }
        }

        public int Red(PieceType type)
            => RedCount[type];

        public int Green(PieceType type)
            => GreenCount[type];

        public int Yellow(PieceType type)
            => YellowCount[type];

        public int Blue(PieceType type)
            => BlueCount[type];

        public override bool Any(PieceType type, Func<int, bool> condition)
        {
            return (
                condition(RedCount[type])
                || condition(GreenCount[type])
                || condition(YellowCount[type])
                || condition(BlueCount[type])
            );
        }
    }
}
