namespace ChessModel
{
    public class GameState4Player : GameState
    {
        public Dictionary<PlayerColor, int> PlayerScore { get; set; }
        
        public GameState4Player(Board4Player board, PlayerColor player)
        {
            PlayerScore = new Dictionary<PlayerColor, int>
            {
                { PlayerColor.Red, 0 },
                { PlayerColor.Green, 0 },
                { PlayerColor.Yellow, 0 },
                { PlayerColor.Blue, 0 },
            };
            
            GameBoard = board;
            CurrentPlayer = player;

            Move.CapturedPieceEvent += OnCapturedPiece;
        }

        public override void ExecuteMove(Move move)
        {
            GameBoard.SetEnPassantSquare(CurrentPlayer, null);
            move.Execute(GameBoard, true);

            Piece movedPiece = GameBoard[move.To];
            IEnumerable<Position> kingCaptureSpaces = movedPiece
                .GetMoves(move.To, GameBoard)
                .Where(move => GameBoard[move.To].Type == PieceType.King)
                .Select(move => move.To);

            if (kingCaptureSpaces.Any())
            {
                foreach (Position pos in kingCaptureSpaces)
                {
                    if (ValidMovesFor(pos, GameBoard[pos].Color).Any())
                        OnKingCheck();
                    else
                        OnKingCheckMate();
                }
            }



            CurrentPlayer = PlayerManager.Next(CurrentPlayer);
            CheckGameOver();
        }

        protected override void CheckGameOver()
        {
            
        }

        private void OnCapturedPiece(PlayerColor movingPlayer, PlayerColor capturedPlayer, PieceType capturedPiece)
        {

        }

        private void OnKingCheck()
        {

        }

        private void OnKingCheckMate()
        {

        }
    }
}
