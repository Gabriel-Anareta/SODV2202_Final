namespace ChessModel
{
    public class GameState4Player : GameState
    {
        public event Action<PlayerColor> PlayerEliminated;
        public event Action<PlayerColor, string> PlayerScoreChanged;
        
        public Dictionary<PlayerColor, PlayerState> PlayerStates { get; set; }
        
        public GameState4Player(Board4Player board, PlayerColor player)
        {
            PlayerStates = new Dictionary<PlayerColor, PlayerState>
            {
                { PlayerColor.Red, new PlayerState() },
                { PlayerColor.Green, new PlayerState() },
                { PlayerColor.Yellow, new PlayerState() },
                { PlayerColor.Blue, new PlayerState() }
            };
            
            GameBoard = board;
            CurrentPlayer = player;

            Move.CapturedPieceEvent += OnCapturedPiece;
        }
        
        public override void ExecuteMove(Move move)
        {
            // Execute move
            GameBoard.SetEnPassantSquare(CurrentPlayer, null);
            move.Execute(GameBoard, true);

            Piece movingPiece = GameBoard[move.To];

            // Get all move positions that capture a king
            IEnumerable<Position> kingCaptureSpaces = movingPiece
                .GetMoves(move.To, GameBoard)
                .Where(move => GameBoard[move.To].Type == PieceType.King)
                .Select(move => move.To);

            int kingsChecked = 0;
            
            // Check for check and checkmate scenarios
            foreach (Position pos in kingCaptureSpaces)
                if (ValidMovesFor(pos, GameBoard[pos].Color).Any())
                    kingsChecked++;

            // Award points for any check
            AwardCheckPoints(movingPiece, kingsChecked);
            
            int kingsCheckmated = 0;

            // Check for eliminations
            foreach (PlayerColor player in CurrentPlayer.Opponents())
                if (PlayerStates[player].IsInPlay)
                    CheckElimination(player, ref kingsCheckmated);

            AwardCheckmatePoints(kingsCheckmated);

            // Update game state
            CheckGameOver();
            PlayerColor initial = CurrentPlayer;
            while (true)
            {
                CurrentPlayer = CurrentPlayer.Next();
                if (PlayerStates[CurrentPlayer].IsInPlay || CurrentPlayer == initial)
                    break;
            }
        }

        protected override void CheckGameOver()
        {
            bool opponentsAreInPlay = true;
            foreach (PlayerColor opponent in CurrentPlayer.Opponents())
                opponentsAreInPlay = opponentsAreInPlay && PlayerStates[opponent].IsInPlay;

            if (!opponentsAreInPlay)
                RaiseGameOver();
        }

        private void RaiseGameOver()
        {
            
        }

        private void CheckElimination(PlayerColor player, ref int kingsCheckmated)
        {
            if (ValidMovesFor(player).Any())
                return;

            kingsCheckmated++;
            EliminatePlayer(player);

            if (!GameBoard.IsInCheck(player))
                AwardStalematePoints(player);
        }

        private void EliminatePlayer(PlayerColor player)
        {
            PlayerStates[player].IsInPlay = false;
            PlayerEliminated?.Invoke(player);
        }

        private void AwardStalematePoints(PlayerColor player)
        {
            foreach (PlayerColor opponent in player.Opponents())
            {
                if (!PlayerStates[opponent].IsInPlay)
                    continue;

                PlayerStates[opponent].Score += 10;
                PlayerScoreChanged?.Invoke(opponent, PlayerStates[opponent].Score.ToString());
            }
        }

        private void AwardCheckPoints(Piece movingPiece, int checkCount)
        {
            PlayerColor color = movingPiece.Color;

            if (checkCount <= 2)
                return;

            switch (checkCount)
            {
                case 2:
                    if (movingPiece.Type == PieceType.Queen)
                        PlayerStates[CurrentPlayer].Score += 1;
                    else
                        PlayerStates[CurrentPlayer].Score += 5;
                    break;
                case 3:
                    if (movingPiece.Type == PieceType.Queen)
                        PlayerStates[CurrentPlayer].Score += 5;
                    else
                        PlayerStates[CurrentPlayer].Score += 20;
                    break;
                default:
                    break;
            }

            PlayerScoreChanged?.Invoke(color, PlayerStates[color].Score.ToString());
        }

        private void AwardCheckmatePoints(int checkmateCount)
        {
            if (checkmateCount == 0) 
                return;
            
            for (int i = 0; i < checkmateCount; i++)
                PlayerStates[CurrentPlayer].Score += 20;

            PlayerScoreChanged?.Invoke(CurrentPlayer, PlayerStates[CurrentPlayer].Score.ToString());
        }

        private void OnCapturedPiece(Piece capturingPiece, Piece capturedPiece)
        {
            PlayerStates[capturingPiece.Color].Score += capturedPiece.Type.GetPiecePoints();
            PlayerScoreChanged?.Invoke(CurrentPlayer, PlayerStates[CurrentPlayer].Score.ToString());
        }
    }
}
