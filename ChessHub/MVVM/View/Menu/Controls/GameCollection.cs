using ChessClient.MVVM.View.ViewUtils;

namespace ChessClient.MVVM.View.Menu.Controls
{
    public partial class GameCollection : UserControl
    {
        public Action<BoardType> OptionSelected;

        public GameCollection()
        {
            InitializeComponent();
            player2Option.Selected += OnOptionSelected;
            player4Option.Selected += OnOptionSelected;
            this.DoubleBuffered = true;
        }

        private void OnOptionSelected(BoardType type)
            => OptionSelected.Invoke(type);
    }
}
