using ChessClient.MVVM.View.Boards.Controls;
using ChessClient.MVVM.View.Controls;
using ChessClient.MVVM.ViewModel;
using ChessClient.Net;
using ChessModel;

namespace ChessClient.MVVM.View.ViewUtils
{
    public class BoardController
    {
        public ChessViewModel ViewModel { get; set; }

        private Form _boundedForm;
        private Panel _boardDisplay;
        private PromotionControl _promCtrl;
        private GameOverControl _gameOverCtrl;
        private BoardSquare[,] _pieces;
        private int _squaresOnSide;

        public BoardController(
            Form form,
            Panel boardDisplay,
            PlayerColor color,
            Server server,
            List<string> users,
            BoardType boardType
        )
        {
            _boundedForm = form;
            _boardDisplay = boardDisplay;

            ViewModel = boardType switch
            {
                BoardType.Board2Player => new Chess2PlayerViewModel(color, server)
                {
                    UsernameWhite = users[0],
                    UsernameBlack = users[1]
                },
                BoardType.Board4Player => new Chess4PlayerViewModel(color, server) 
                {
                    UsernameRed = users[0],
                    UsernameGreen = users[1],
                    UsernameYellow = users[2],
                    UsernameBlue = users[3]
                },
                _ => throw new Exception("you wanna explain?")
            };

            _squaresOnSide = boardType switch
            {
                BoardType.Board2Player => 8,
                BoardType.Board4Player => 14,
                _ => throw new Exception("you wanna explain?")
            };

            _pieces = new BoardSquare[_squaresOnSide, _squaresOnSide];
            _promCtrl = new PromotionControl(color, ViewModel.PromotionSelected);

            Func<int, int, bool> skipTest = boardType switch
            {
                BoardType.Board2Player => (file, rank) => false,
                BoardType.Board4Player => (file, rank) => ((Chess4PlayerViewModel)ViewModel).IsDeadSpace(file, rank),
                _ => throw new Exception("you wanna explain?")
            };

            _boundedForm.Text = $"Player: {color} / Name: {server.Username}";

            _boardDisplay.Paint += (obj, e) => DrawSquares(e, skipTest);

            ViewModel.ShowHighlights += ShowHighlights;
            ViewModel.HideHighlights += HideHighlights;
            ViewModel.ChoosePromotion += ShowPromotion;
            ViewModel.ConfirmPromotion += HidePromotion;
            ViewModel.ShowGameOver += ShowGameOver;

            InitializeBoard(skipTest);
            AdjustBoardSize();
        }

        public void LoadBoard()
        {
            for (int file = 0; file < _squaresOnSide; file++)
                for (int rank = 0; rank < _squaresOnSide; rank++)
                    if (_pieces[file, rank] != null)
                        _boardDisplay.Controls.Add(_pieces[file, rank]);
        }

        public void InitializeBoard(Func<int, int, bool> checkSquare)
        {
            Size size = _boardDisplay.Size;
            int tileSize = size.Width / _squaresOnSide;
            BindingSource[,] bindings = ViewModel.GetBindings();

            for (int file = 0; file < _squaresOnSide; file++)
            {
                for (int rank = 0; rank < _squaresOnSide; rank++)
                {
                    if (checkSquare(file, rank))
                        continue;
                    
                    _pieces[file, rank] = new BoardSquare(rank, file, bindings[rank, file]);
                    _pieces[file, rank].Size = new Size(tileSize, tileSize);
                    _pieces[file, rank].Location = new Point(
                        tileSize * rank,
                        size.Height - tileSize * (file + 1)
                    );
                    _pieces[file, rank].DataBindings.Add(
                        "Command",
                        ViewModel,
                        nameof(ViewModel.PieceSelectedCommand),
                        true,
                        DataSourceUpdateMode.OnPropertyChanged
                    );
                }
            }
        }

        public void AdjustBoardSize()
        {
            int maxSize = Math.Min(_boundedForm.ClientSize.Width / 2 - 20, _boundedForm.ClientSize.Height - 20);
            int boardSize = maxSize - maxSize % _squaresOnSide;
            _boardDisplay.Size = new Size(boardSize, boardSize);

            Size size = _boardDisplay.Size;
            int tileSize = size.Width / _squaresOnSide;

            for (int file = 0; file < _squaresOnSide; file++)
            {
                for (int rank = 0; rank < _squaresOnSide; rank++)
                {
                    if (_pieces[file, rank] == null)
                        continue;

                    _pieces[file, rank].Size = new Size(tileSize, tileSize);
                    _pieces[file, rank].Location = new Point(
                        tileSize * rank,
                        size.Height - tileSize * (file + 1)
                    );
                }
            }

            _boardDisplay.Refresh();
        }

        public void DrawSquares(PaintEventArgs e, Func<int, int, bool> checkSquare)
        {
            Size size = _boardDisplay.Size;
            int tileSize = size.Width / _squaresOnSide;

            Color light = Color.FromArgb(0xFF, 0xFF, 0xCF, 0x9F);
            Color Dark = Color.FromArgb(0xFF, 0xD2, 0x8C, 0x45);
            SolidBrush brushWhite = new SolidBrush(light);
            SolidBrush brushBlack = new SolidBrush(Dark);

            for (int file = 0; file < _squaresOnSide; file++)
            {
                for (int rank = 0; rank < _squaresOnSide; rank++)
                {
                    if (checkSquare(file, rank))
                        continue;
                    
                    Rectangle rect = new Rectangle();
                    rect.Size = new Size(tileSize, tileSize);
                    rect.Location = new Point(size.Width - tileSize * (file + 1), size.Width - tileSize * (rank + 1));
                    if ((file + rank) % 2 == 0)
                        e.Graphics.FillRectangle(brushBlack, rect);
                    else
                        e.Graphics.FillRectangle(brushWhite, rect);
                }
            }

            brushBlack.Dispose();
            brushWhite.Dispose();
        }

        public void ShowHighlights(Dictionary<Position, Move> moveCache)
        {
            Color greenHighlight = Color.FromArgb(150, 125, 255, 125);
            Color redHighlight = Color.FromArgb(150, 255, 125, 125);

            foreach (Position to in moveCache.Keys)
                if (ViewModel.IsEmpty(to))
                    _pieces[to.Rank, to.File].BackColor = greenHighlight;
                else
                    _pieces[to.Rank, to.File].BackColor = redHighlight;
        }

        public void HideHighlights(Dictionary<Position, Move> moveCache)
        {
            foreach (Position to in moveCache.Keys)
                _pieces[to.Rank, to.File].BackColor = Color.Transparent;
        }

        public void ShowPromotion()
        {
            _promCtrl.Size = new Size(
                _boardDisplay.Width * 3 / 4,
                _boardDisplay.Height / 4
            );

            AddControlToContainer(_boardDisplay, _promCtrl);
        }

        public void HidePromotion()
            => _boardDisplay.Controls.Remove(_promCtrl);

        private void ShowGameOver(Result result)
        {
            _gameOverCtrl.Size = new Size(
                _boardDisplay.Width * 3 / 4,
                _boardDisplay.Height / 4
            );

            AddControlToContainer(_boardDisplay, _gameOverCtrl);
        }

        private void AddControlToContainer(Control container, Control control)
        {
            control.Location = CenterControl(container, control);

            container.Controls.Add(_promCtrl);
            control.BringToFront();
        }

        private Point CenterControl(Control container, Control control)
        {
            return new Point(
                container.Width / 2 - control.Width / 2,
                container.Height / 2 - control.Height / 2
            );
        }
    }
}
