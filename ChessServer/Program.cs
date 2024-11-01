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
        
        static void Main(string[] args)
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), PORT);
            _listener.Start(); // implement blacklog ?

            var client = _listener.AcceptTcpClient();
            Console.WriteLine("Client has connected!");
        }
    }
}
