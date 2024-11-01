using ChessClient.Net.IO;
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
            {
                _client.Connect("127.0.0.1", PORT);
                PacketBuilder connectPacket = new PacketBuilder();
                connectPacket.WriteOpCode(0); // using opCode 0 temporalily for testing
                connectPacket.WriteString(username);
                _client.Client.Send(connectPacket.GetPacketBytes());
            }
                
        }
    }
}
