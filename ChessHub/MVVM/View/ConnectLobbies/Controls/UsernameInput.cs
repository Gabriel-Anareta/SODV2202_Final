using ChessClient.MVVM.ViewModel;
using ChessClient.MVVM.ViewModel.Commands;

namespace ChessClient.MVVM.View.ConnectLobbies.Controls
{
    public partial class UsernameInput : UserControl
    {
        public Action UsernameSubmitted { get; set; }

        public UsernameInput(ConnectViewModel cvm)
        {
            InitializeComponent();
            Binding usernameBinding = new Binding("Text", cvm, nameof(cvm.Username), true, DataSourceUpdateMode.OnPropertyChanged);
            Binding commandBinding = new Binding("Command", cvm, nameof(cvm.ConnectToServerCommand), true);

            tb_UsernameInput.DataBindings.Add(usernameBinding);
            btn_Submit.DataBindings.Add(commandBinding);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
            => UsernameSubmitted.Invoke();
    }
}
