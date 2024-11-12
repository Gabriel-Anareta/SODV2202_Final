using ChessClient.MVVM.ViewModel.Commands;

namespace ChessClient.MVVM.View.Controls
{
    public partial class BoardSquare : UserControl
    {
        public RelayCommand Command { get; set; }
        public int File { get; }
        public int Rank { get; }

        public BoardSquare(int file, int rank, BindingSource imageSource)
        {
            InitializeComponent();
            File = file;
            Rank = rank;
            pb_PieceImg.DataBindings.Add("Image", imageSource, "Image", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void pb_PieceImg_Click(object sender, EventArgs e)
            => Command?.Execute(this);
    }
}
