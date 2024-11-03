using ChessClient.Net.IO;
using System;
using System.Net.Sockets;

namespace ChessClient.Net
{
    public sealed class Server
    {
        private const int PORT = 5000;
        private const string HOST = "127.0.0.1";
        private TcpClient _client;
        public PacketReader PacketReader;

        public event Action ConnectedEvent;
        public event Action MessageRecievedEvent;
        public event Action UserDisconnectedEvent;


        public Server()
        {
            _client = new TcpClient();
        }

        public void ConnectToServer(string username)
        {
            if (_client.Connected)
                return;

            _client.Connect(HOST, PORT);
            PacketReader = new PacketReader(_client.GetStream());

            if (!string.IsNullOrEmpty(username))
            {
                PacketBuilder connectPacket = new PacketBuilder();
                connectPacket.WriteOpCode(0); // using opCode 0 temporalily for testing
                connectPacket.WriteMessage(username);
                _client.Client.Send(connectPacket.GetPacketBytes());
            }

            ReadPackets();
        }

        public void SendMessageToServer(string message)
        {
            if (!_client.Connected)
                return;

            PacketBuilder messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5); // using opCode 5 temporalily for testing
            messagePacket.WriteMessage(message);
            _client.Client.Send(messagePacket.GetPacketBytes());
        }

        private void ReadPackets()
        {
            Task.Run(() => // Avoids locking up the app while packets are being read
            {
                while (true)
                {
                    int opCode = PacketReader.ReadByte();
                    switch (opCode)
                    {
                        case 1:
                            ConnectedEvent?.Invoke();
                            break;
                        case 5:
                            MessageRecievedEvent?.Invoke();
                            break;
                        case 10:
                            UserDisconnectedEvent?.Invoke();
                            break;
                    }
                }
            });
        }
    }
}
