using ChessClient.MVVM.ViewModel;

namespace ChessHub
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            mainViewModelBindingSource.DataSource = new MainViewModel();
        }
    }
}
