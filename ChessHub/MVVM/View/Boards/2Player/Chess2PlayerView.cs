using ChessModel;
using ChessClient.MVVM.ViewModel;
using ChessClient.MVVM.View.Controls;
using ChessClient.Net;
using System.Drawing;
using ChessClient.MVVM.View.ViewUtils;

namespace ChessClient.MVVM.View._2Player
{
    public partial class Chess2PlayerView : Form
    {
        private BoardController _boardController;

        public Chess2PlayerView(PlayerColor color, Server server, List<string> users)
        {
            InitializeComponent();

            _boardController = new BoardController(
                this,
                panel_BoardDisplay,
                color,
                server,
                users,
                BoardType.Board2Player
            );

            Chess2PlayerViewModel viewModel = (Chess2PlayerViewModel)_boardController.ViewModel;

            Binding blackBinding = new Binding("Text", viewModel, nameof(viewModel.UsernameBlack));
            Binding whiteBinding = new Binding("Text", viewModel, nameof(viewModel.UsernameWhite));

            lbl_PlayerBlack.DataBindings.Add(blackBinding);
            lbl_PlayerWhite.DataBindings.Add(whiteBinding);
        }

        private void Chess2PlayerView_Load(object sender, EventArgs e)
            => _boardController.LoadBoard();

        private void Chess2PlayerView_Resize(object sender, EventArgs e)
            => _boardController.AdjustBoardSize();
    }
}
