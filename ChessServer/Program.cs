using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChessServer
{
    internal class Program
    {
        private const int PORT = 5000;
        private static TcpListener _listener;

        private static List<Client> _users;
        
        static void Main(string[] args)
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), PORT);
            _listener.Start(); // implement blacklog ?

            _users = new List<Client>();

            while (true)
            {
                Client client = new Client(_listener.AcceptTcpClient());
                _users.Add(client);

                // Broadcast connection to everyone on server
            }
        }
    }
}
