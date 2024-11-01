using ChessClient.MVVM.ViewModel;

namespace ChessHub
{
    public partial class MainView : Form
    {
        
        public MainView()
        {
            InitializeComponent();
            //Add data binding to connect button to not send blank users
            //btn_Connect.DataBindings.Add("Enabled", )
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            mainViewModelBindingSource.DataSource = new MainViewModel();
        }
    }
}
