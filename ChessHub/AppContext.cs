using ChessClient.MVVM.ViewModel;
using ChessClient.Net;
using ChessHub;
using System.Windows.Forms;
using ChessClient.Net.IO;

namespace ChessClient
{
    public class AppContext : ApplicationContext
    {
        private Server _server;

        public AppContext()
        {
            _server = new Server();
            
            List<Form> forms = new List<Form>() {
                new MainView(),
                new MainView()
            };

            foreach (var form in forms)
            {
                //form.FormClosing += OnFormClosing;
                form.Show();
            }  
        }

        public static event EventHandler FormClosing;
        private void OnFormClosing(object? sender, EventArgs e)
            => FormClosing?.Invoke(sender, e);
    }
}
