namespace ChessModel
{
    public class PieceCount2P : PieceCount
    {
        public Dictionary<PieceType, int> WhiteCount { get; set; }
        public Dictionary<PieceType, int> BlackCount { get; set; }

        public PieceCount2P()
        {
            WhiteCount = new Dictionary<PieceType, int>();
            BlackCount = new Dictionary<PieceType, int>();

            foreach (PieceType type in Enum.GetValues(typeof(PieceType)))
            {
                WhiteCount[type] = 0;
                BlackCount[type] = 0;
            }
        }

        public override void IncrementPieceCount(PlayerColor color, PieceType type)
        {
            switch (color) 
            { 
                case PlayerColor.White:
                    WhiteCount[type]++;
                    break;
                case PlayerColor.Black:
                    BlackCount[type]++;
                    break;
            }
        }

        public int White(PieceType type)
            => WhiteCount[type];

        public int Black(PieceType type)
            => BlackCount[type];

        public override bool Any(PieceType type, Func<int, bool> condition)
        {
            return (
                condition(WhiteCount[type])
                || condition (BlackCount[type])
            );
        }
    }
}
