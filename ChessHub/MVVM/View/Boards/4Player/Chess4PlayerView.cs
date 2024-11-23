using ChessClient.MVVM.View.Controls;
using ChessClient.MVVM.View.ViewUtils;
using ChessClient.MVVM.ViewModel;
using ChessClient.Net;
using ChessModel;

namespace ChessClient.MVVM.View._4Player
{
    public partial class Chess4PlayerView : Form
    {
        private BoardController _boardController;

        public Chess4PlayerView(PlayerColor color, Server server, List<string> users)
        {
            InitializeComponent();

            _boardController = new BoardController(
                this,
                panel_BoardDisplay,
                color,
                server,
                users,
                BoardType.Board4Player
            );

            Chess4PlayerViewModel viewModel = (Chess4PlayerViewModel)_boardController.ViewModel;

            Binding redBinding = new Binding("Text", viewModel, nameof(viewModel.UsernameRed));
            Binding greenBinding = new Binding("Text", viewModel, nameof(viewModel.UsernameGreen));
            Binding yellowBinding = new Binding("Text", viewModel, nameof(viewModel.UsernameYellow));
            Binding blueBinding = new Binding("Text", viewModel, nameof(viewModel.UsernameBlue));
            Binding scoreRedBinding = new Binding(
                "Text",
                viewModel,
                nameof(viewModel.ScoreRed),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            Binding scoreGreenBinding = new Binding(
                "Text",
                viewModel,
                nameof(viewModel.ScoreGreen),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            Binding scoreYellowBinding = new Binding(
                "Text",
                viewModel,
                nameof(viewModel.ScoreYellow),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            Binding scoreBlueBinding = new Binding(
                "Text",
                viewModel,
                nameof(viewModel.ScoreBlue),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            lbl_PlayerRed.DataBindings.Add(redBinding);
            lbl_PlayerGreen.DataBindings.Add(greenBinding);
            lbl_PlayerYellow.DataBindings.Add(yellowBinding);
            lbl_PlayerBlue.DataBindings.Add(blueBinding);

            lbl_ScoreRed.DataBindings.Add(scoreRedBinding);
            lbl_ScoreGreen.DataBindings.Add(scoreGreenBinding);
            lbl_ScoreYellow.DataBindings.Add(scoreYellowBinding);
            lbl_ScoreBlue.DataBindings.Add(scoreBlueBinding);
        }

        private void Chess4PlayerView_Load(object sender, EventArgs e)
            => _boardController.LoadBoard();

        private void Chess4PlayerView_Resize(object sender, EventArgs e)
            => _boardController.AdjustBoardSize();
    }
}
