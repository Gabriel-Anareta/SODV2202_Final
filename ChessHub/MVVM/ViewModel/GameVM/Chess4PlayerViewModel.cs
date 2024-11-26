using ChessClient.MVVM.ViewModel.Commands;
using ChessClient.Net;
using ChessModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChessClient.MVVM.ViewModel
{
    public class Chess4PlayerViewModel : ChessViewModel
    {
        public event Action<PlayerColor> PlayerEliminated;
        
        
        private string _usernameRed;
        public string UsernameRed 
        {
            get { return _usernameRed; } 
            set 
            {
                if (_usernameRed == value)
                    return;
                _usernameRed = value;
                OnPropertyChanged();
            } 
        }
        
        private string _usernameGreen;
        public string UsernameGreen 
        { 
            get { return _usernameGreen; } 
            set 
            {
                if (_usernameGreen == value)
                    return;
                _usernameGreen = value;
                OnPropertyChanged();
            } 
        }
        
        private string _usernameYellow;
        public string UsernameYellow 
        { 
            get { return _usernameYellow; } 
            set 
            {
                if (_usernameYellow == value)
                    return;
                _usernameYellow = value;
                OnPropertyChanged();
            } 
        }

        private string _usernameBlue;
        public string UsernameBlue 
        { 
            get { return _usernameBlue; } 
            set 
            {
                if (_usernameBlue == value)
                    return;
                _usernameBlue = value;
                OnPropertyChanged();
            } 
        }

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

        private Color _colorRed;
        public Color ColorRed
        {
            get { return _colorRed; }
            set
            {
                if (_colorRed == value)
                    return;
                _colorRed = value;
                OnPropertyChanged();
            }
        }

        private Color _colorGreen;
        public Color ColorGreen
        {
            get { return _colorGreen; }
            set
            {
                if (_colorGreen == value)
                    return;
                _colorGreen = value;
                OnPropertyChanged();
            }
        }

        private Color _colorYellow;
        public Color ColorYellow
        {
            get { return _colorYellow; }
            set
            {
                if (_colorYellow == value)
                    return;
                _colorYellow = value;
                OnPropertyChanged();
            }
        }

        private Color _colorBlue;
        public Color ColorBlue
        {
            get { return _colorBlue; }
            set
            {
                if (_colorBlue == value)
                    return;
                _colorBlue = value;
                OnPropertyChanged();
            }
        }



        public Chess4PlayerViewModel(PlayerColor color, Server server)
        {
            Server = server;
            Server.MoveRecievedEvent += OnMoveRecieved;

            GameState = new GameState4Player(new Board4Player().InitialState(), PlayerColor.Red);
            MoveCache = new Dictionary<Position, Move>();
            SelectedPos = null;
            CurrentMove = null;
            ClientColor = color;

            PieceSelectedCommand = new RelayCommand(
                obj => PieceSelected(obj),
                obj => {
                    return ClientColor == GameState.CurrentPlayer;
                    //return true;
                }
            );

            PromotionSelected = OnPromotionSelected;

            ColorRed = Color.FromArgb(255, 31, 31);
            ColorGreen = Color.FromArgb(0, 191, 63);
            ColorYellow = Color.FromArgb(255, 222, 59);
            ColorBlue = Color.FromArgb(52, 71, 255);

            ScoreRed = "0";
            ScoreGreen = "0";
            ScoreYellow = "0";
            ScoreBlue = "0";

            ((GameState4Player)GameState).PlayerEliminated += OnPlayerEliminated;
            ((GameState4Player)GameState).PlayerScoreChanged += UpdateScores;
        }

        private void OnPlayerEliminated(PlayerColor player)
        {
            GameState.ColorsInPlay--;
            
            foreach (Position pos in GameState.GameBoard.PiecePositionsFor(player))
            {
                Piece piece = GameState.GameBoard[pos];
                piece.Image = piece.Type.GetDeadImage();
                piece.Type = piece.Type.GetDeadType();
            }

            Color grey = Color.FromArgb(54, 54, 54);
            switch (player) 
            {
                case PlayerColor.Red:
                    ColorRed = grey;
                    UsernameRed += " (Eliminated)";
                    break;
                case PlayerColor.Green:
                    ColorGreen = grey;
                    UsernameGreen += " (Eliminated)";
                    break;
                case PlayerColor.Yellow:
                    ColorYellow = grey;
                    UsernameYellow += " (Eliminated)";
                    break;
                case PlayerColor.Blue:
                    ColorBlue = grey;
                    UsernameBlue += " (Eliminated)";
                    break;
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

        protected override void DisplayPlayingUser()
        {
            UsernameRed = RemovePlaying(UsernameRed);
            UsernameGreen = RemovePlaying(UsernameGreen);
            UsernameYellow = RemovePlaying(UsernameYellow);
            UsernameBlue = RemovePlaying(UsernameBlue);

            switch (GameState.CurrentPlayer)
            {
                case PlayerColor.Red:
                    UsernameRed += " (playing)";
                    break;
                case PlayerColor.Green:
                    UsernameGreen += " (playing)";
                    break;
                case PlayerColor.Yellow:
                    UsernameYellow += " (playing)";
                    break;
                case PlayerColor.Blue:
                    UsernameBlue += " (playing)";
                    break;
            }
        }
    }
}
