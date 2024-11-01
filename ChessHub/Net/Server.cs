using System;
using System.Net.Sockets;

namespace ChessClient.Net
{
    public class Server
    {
        private const int PORT = 5000;
        private TcpClient _client;

        public Server()
        {
            _client = new TcpClient();
        }

        public void ConnectToServer(string username)
        {
            if (!_client.Connected)
                _client.Connect("127.0.0.1", PORT);
        }
    }
}
