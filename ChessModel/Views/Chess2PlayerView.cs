using ChessModel.Views;

namespace ChessModel
{
    public partial class Chess2PlayerView : Form
    {
        private readonly BoardSquare[,] _pieces = new BoardSquare[8, 8];
        private readonly Rectangle[,] highlights = new Rectangle[8, 8];
        private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();
        private readonly GameState _gameState;
        private Position _selectedPos;
        private Panel container;
        private bool menuOnScreen = false;

        private TestViewModel _testViewModel = new TestViewModel();

        public Chess2PlayerView()
        {
            InitializeComponent();
            this.ClientSize = new Size(800, 800);
            _gameState = new GameState(new Board2Player().InitialState(), PlayerColor.White);
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Size size = this.ClientSize;
            int tileSize = size.Width / 8;

            for (int file = 0; file < 8; file++)
            {
                for (int rank = 0; rank < 8; rank++)
                {
                    BindingSource imageSource = _gameState.GameBoard.Pieces.Bindings[file, rank];

                    highlights[file, rank] = new Rectangle();
                    highlights[file, rank].Size = new Size(tileSize, tileSize);
                    highlights[file, rank].Location = new Point(size.Width - tileSize * (file + 1), size.Width - tileSize * (rank + 1));

                    _pieces[file, rank] = new BoardSquare(imageSource);
                    _pieces[file, rank].Size = new Size(tileSize, tileSize);
                    _pieces[file, rank].Location = new Point(tileSize * file, size.Width - tileSize * (rank + 1));
                    _pieces[file, rank].DataBindings.Add("Command", _testViewModel, "TestCommand", true, DataSourceUpdateMode.OnPropertyChanged);
                    _pieces[file, rank].Click += Piece_Click;
                    Controls.Add(_pieces[file, rank]);
                }
            }
        }


        public Action<Position> PieceSelected;
        private void Piece_Click(object? sender, EventArgs e)
        {
            if (menuOnScreen)
                return;

            PictureBox pb = sender as PictureBox;
            Position pos = ToSquarePosition(pb.Location);

            PieceSelected?.Invoke(pos);
        }

        private Position ToSquarePosition(Point point)
        {
            Size size = this.ClientSize;
            int tileSize = size.Width / 8;
            int file = (int)(point.X / tileSize);
            int rank = (int)((size.Height - point.Y) / tileSize - 1);
            return new Position(file, rank);
        }
    }
}
