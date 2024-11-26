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

            Binding nameRedBinding = new Binding(
                "Text", 
                viewModel, 
                nameof(viewModel.UsernameRed), 
                true, 
                DataSourceUpdateMode.OnPropertyChanged
            );
            Binding nameGreenBinding = new Binding(
                "Text", 
                viewModel, 
                nameof(viewModel.UsernameGreen), 
                true, 
                DataSourceUpdateMode.OnPropertyChanged
            );
            Binding nameYellowBinding = new Binding(
                "Text", 
                viewModel, 
                nameof(viewModel.UsernameYellow), 
                true, 
                DataSourceUpdateMode.OnPropertyChanged
            );
            Binding nameBlueBinding = new Binding(
                "Text", 
                viewModel, 
                nameof(viewModel.UsernameBlue), 
                true, 
                DataSourceUpdateMode.OnPropertyChanged
            );
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
            Binding colorRedBinding = new Binding(
                "BackColor",
                viewModel,
                nameof(viewModel.ColorRed),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            Binding colorGreenBinding = new Binding(
                "BackColor",
                viewModel,
                nameof(viewModel.ColorGreen),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            Binding colorYellowBinding = new Binding(
                "BackColor",
                viewModel,
                nameof(viewModel.ColorYellow),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            Binding colorBlueBinding = new Binding(
                "BackColor",
                viewModel,
                nameof(viewModel.ColorBlue),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );

            lbl_PlayerRed.DataBindings.Add(nameRedBinding);
            lbl_PlayerRed.DataBindings.Add(colorRedBinding);

            lbl_PlayerGreen.DataBindings.Add(nameGreenBinding);
            lbl_PlayerGreen.DataBindings.Add(colorGreenBinding);

            lbl_PlayerYellow.DataBindings.Add(nameYellowBinding);
            lbl_PlayerYellow.DataBindings.Add(colorYellowBinding);

            lbl_PlayerBlue.DataBindings.Add(nameBlueBinding);
            lbl_PlayerBlue.DataBindings.Add(colorBlueBinding);

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
