namespace ChessModel
{
    public class GameState4Player : GameState
    {
        public event Action<PlayerColor> PlayerEliminated;
        public event Action ScoresChanged;
        
        public Dictionary<PlayerColor, PlayerState> PlayerStates { get; set; }

        private PieceType? _capturedPiece = null;
        
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
            ColorsInPlay = 4;

            Move.CapturedPieceEvent += OnCapturedPiece;
        }

        public PlayerColor GetWinner()
        {
            List<PlayerColor> winners = new List<PlayerColor>();
            int highestScore = 0;
            foreach (var state in PlayerStates)
            {
                if (winners.Count == 0)
                {
                    winners.Add(state.Key);
                    highestScore = state.Value.Score;
                    continue;
                }

                if (state.Value.Score > highestScore)
                {
                    winners.Clear();
                    winners.Add(state.Key);
                    highestScore = state.Value.Score;
                }

                if (state.Value.Score == highestScore)
                {
                    winners.Add(state.Key);
                }
            }

            if (winners.Count > 1)
                return PlayerColor.None;

            return winners.First();
        }
        
        public override void ExecuteMove(Move move)
        {
            // Execute move
            GameBoard.SetEnPassantSquare(CurrentPlayer, null);
            bool pawnMovedOrCapture = move.Execute(GameBoard, true);

            if (pawnMovedOrCapture)
                _reversableMoves = 0;
            else
                _reversableMoves++;

            if (_capturedPiece != null)
                PlayerStates[CurrentPlayer].Score += ((PieceType)_capturedPiece).GetPiecePoints();

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

            ScoresChanged?.Invoke();

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
            if (ColorsInPlay == 1)
                EndResult = Result.Draw(EndReason.AllOpponentsEliminated);
            else if (GameBoard.InsufficientMaterial())
                EndResult = Result.Draw(EndReason.InsufficientMaterial);
            else if (FiftyMoveRule(ColorsInPlay))
                EndResult = Result.Draw(EndReason.FiftyMoveRule);
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
            ColorsInPlay--;
            PlayerEliminated?.Invoke(player);
        }

        private void AwardStalematePoints(PlayerColor player)
        {
            foreach (PlayerColor opponent in player.Opponents())
            {
                if (!PlayerStates[opponent].IsInPlay)
                    continue;

                PlayerStates[opponent].Score += 10;
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
        }

        private void AwardCheckmatePoints(int checkmateCount)
        {
            if (checkmateCount == 0) 
                return;
            
            for (int i = 0; i < checkmateCount; i++)
                PlayerStates[CurrentPlayer].Score += 20;
        }

        private void OnCapturedPiece(Piece capturedPiece)
            => _capturedPiece = capturedPiece.Type;
    }
}
