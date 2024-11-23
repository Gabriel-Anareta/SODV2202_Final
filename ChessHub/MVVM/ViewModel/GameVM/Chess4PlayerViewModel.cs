using ChessClient.MVVM.ViewModel.Commands;
using ChessClient.Net;
using ChessModel;

namespace ChessClient.MVVM.ViewModel
{
    public class Chess4PlayerViewModel : ChessViewModel
    {
        public event Action<PlayerColor> PlayerEliminated;
        
        public string UsernameRed { get; set; }
        public string UsernameGreen { get; set; }
        public string UsernameYellow { get; set; }
        public string UsernameBlue { get; set; }

        private string _scoreRed;
        public string ScoreRed
        {
            get { return _scoreRed; }
            set 
            {
                if (_scoreRed == value)
                    return;
                _scoreRed = value;
                OnPropertyChanged();
            }
        }

        private string _scoreGreen;
        public string ScoreGreen
        {
            get { return _scoreGreen; }
            set 
            {
                if (_scoreGreen == value)
                    return;
                _scoreGreen = value;
                OnPropertyChanged();
            }
        }

        private string _scoreYellow;
        public string ScoreYellow
        {
            get { return _scoreYellow; }
            set 
            { 
                if (_scoreYellow == value)
                    return;
                _scoreYellow = value; 
                OnPropertyChanged();
            }
        }

        private string _scoreBlue;
        public string ScoreBlue
        {
            get { return _scoreBlue; }
            set 
            {
                if (_scoreBlue == value)
                    return;
                _scoreBlue = value; 
                OnPropertyChanged();
            }
        }


        public Chess4PlayerViewModel(PlayerColor color, Server server)
        {
            Server = server;
            
            GameState = new GameState4Player(new Board4Player().InitialState(), color);
            MoveCache = new Dictionary<Position, Move>();
            SelectedPos = null;
            CurrentMove = null;
            ClientColor = color;

            PieceSelectedCommand = new RelayCommand(
                obj => PieceSelected(obj)
                //obj => ClientColor == GameState.CurrentPlayer
            );

            PromotionSelected = piece =>
            {
                MenuOnScreen = false;
                ConfirmPromotion.Invoke();
                HandleMove(new PawnPromotion(CurrentMove.From, CurrentMove.To, piece));
            };

            ScoreRed = "0";
            ScoreGreen = "0";
            ScoreYellow = "0";
            ScoreBlue = "0";

            ((GameState4Player)GameState).PlayerEliminated += OnPlayerEliminated;
            ((GameState4Player)GameState).PlayerScoreChanged += UpdateScores;
        }
        
        private void OnPlayerEliminated(PlayerColor player)
        {
            foreach (Position pos in GameState.GameBoard.PiecePositionsFor(player))
            {
                Piece piece = GameState.GameBoard[pos];
                piece.Image = piece.Type.GetDeadImage();
                piece.Type = piece.Type.GetDeadType();
            }
        }
            

        private void UpdateScores(PlayerColor color, string score)
        {
            switch (color) 
            {
                case PlayerColor.Red:
                    ScoreRed = score;
                    break;
                case PlayerColor.Green:
                    ScoreGreen = score;
                    break;
                case PlayerColor.Yellow:
                    ScoreYellow = score;
                    break;
                case PlayerColor.Blue:
                    ScoreBlue = score;
                    break;
            }
        }

        public bool IsDeadSpace(int file, int rank)
            => ((Board4Player)GameState.GameBoard).PositionInDeadSpace(new Position(file, rank));
    }
}
