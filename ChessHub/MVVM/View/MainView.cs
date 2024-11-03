using ChessClient.MVVM.ViewModel;
using ChessClient.Net;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace ChessHub
{
    public partial class MainView : Form
    {
        ClientViewModel clientViewModel;
        
        public MainView()
        {
            InitializeComponent();
            clientViewModel = new ClientViewModel();
            clientViewModel.UsersChanged += ClientViewModel_UsersChanged;
            clientViewModel.MessagesChanged += ClientViewModel_MessagesChanged;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            clientViewModelBindingSource.DataSource = clientViewModel;
            lb_Users.DataSource = clientViewModel.Users;
            lb_Users.DisplayMember = "Username";
            lb_Messages.DataSource = clientViewModel.Messages;
        }

        private void ClientViewModel_UsersChanged()
        {
            if (this.InvokeRequired)
                this.Invoke(() => {
                    RefreshDatasource(lb_Users, clientViewModel.Users);
                    lb_Users.DisplayMember = "Username";
                });
        }

        private void ClientViewModel_MessagesChanged()
        {
            if (this.InvokeRequired)
                this.Invoke(() => RefreshDatasource(lb_Messages, clientViewModel.Messages));
        }

        private void RefreshDatasource<T>(ListBox control, List<T> source)
        {
            control.DataSource = null;
            control.DataSource = source;
        }
    }
}
