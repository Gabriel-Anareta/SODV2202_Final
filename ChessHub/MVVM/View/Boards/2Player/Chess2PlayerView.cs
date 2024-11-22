using ChessModel;
using ChessClient.MVVM.ViewModel;
using ChessClient.MVVM.View.Controls;

namespace ChessClient.MVVM.View._2Player
{
    public partial class Chess2PlayerView : Form
    {
        private readonly BoardSquare[,] _pieces;
        private Chess2PlayerViewModel _viewModel;

        private PromotionControl promCtrl;
        //private Panel container;

        public Chess2PlayerView(PlayerColor color)
        {
            InitializeComponent();

            this.ClientSize = new Size(800, 800);
            this.Paint += DrawSquares;

            _viewModel = new Chess2PlayerViewModel(color);
            _viewModel.ShowHighlights += ShowHighlights;
            _viewModel.HideHighlights += HideHighlights;
            _viewModel.ChoosePromotion += ShowPromotion;
            _viewModel.ConfirmPromotion += HidePromotion;

            _pieces = new BoardSquare[8, 8];

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
                    BindingSource imageSource = _viewModel.GetBindings()[rank, file];
                    _pieces[file, rank] = new BoardSquare(rank, file, imageSource);
                    _pieces[file, rank].Size = new Size(tileSize, tileSize);
                    _pieces[file, rank].Location = new Point(tileSize * rank, size.Height - tileSize * (file + 1));
                    _pieces[file, rank].DataBindings.Add(
                        "Command",
                        _viewModel, 
                        nameof(_viewModel.PieceSelectedCommand), 
                        true, 
                        DataSourceUpdateMode.OnPropertyChanged
                    );
                    Controls.Add(_pieces[file, rank]);
                }
            }
        }

        private void DrawSquares(object? sender, PaintEventArgs e)
        {
            Size size = this.ClientSize;
            int tileSize = size.Width / 8;
            Color light = Color.FromArgb(0xFF, 0xFF, 0xCF, 0x9F);
            Color Dark = Color.FromArgb(0xFF, 0xD2, 0x8C, 0x45);
            SolidBrush brushWhite = new SolidBrush(light);
            SolidBrush brushBlack = new SolidBrush(Dark);
            for (int file = 0; file < 8; file++)
            {
                for (int rank = 0; rank < 8; rank++)
                {
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

        private void ShowHighlights(Dictionary<Position, Move> moveCache)
        {
            Color color = Color.FromArgb(150, 125, 255, 125);
            foreach (Position to in moveCache.Keys)
                if (_viewModel.IsEmpty(to))
                    _pieces[to.Rank, to.File].BackColor = Color.FromArgb(150, 125, 255, 125);
                else
                    _pieces[to.Rank, to.File].BackColor = Color.FromArgb(150, 255, 125, 125);
        }

        private void HideHighlights(Dictionary<Position, Move> moveCache)
        {
            foreach (Position to in moveCache.Keys)
                _pieces[to.Rank, to.File].BackColor = Color.Transparent;
        }

        private void ShowPromotion(PlayerColor color)
        {
            promCtrl = new PromotionControl(color, _viewModel.PromotionSelected);
            promCtrl.Location = new Point(this.ClientSize.Width / 2 - promCtrl.Width / 2, this.ClientSize.Height / 2 - promCtrl.Height / 2);

            Controls.Add(promCtrl);
            promCtrl.BringToFront();
        }

        private void HidePromotion()
            => Controls.Remove(promCtrl);
    }
}
