using ChessServer.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChessServer
{
    internal class Program
    {
        /*
        opCode key:
        0 - connect client
        1 - broadcasted client connection
        5 - broadcasted message
        10 - broadcasted client disconnection
         */

        private const int PORT = 5000;
        private const string HOST = "127.0.0.1";

        private static TcpListener _listener;
        private static List<Client> _users;
        private static int? _requiredUsers = null;
        
        static void Main(string[] args)
        {
            _listener = new TcpListener(IPAddress.Parse(HOST), PORT);
            _listener.Start(); // implement blacklog ?

            _users = new List<Client>();

            while (true)
            {
                Client client = new Client(_listener.AcceptTcpClient());

                _users.Add(client);

                // Broadcast connection to everyone on server
                BroadcastConnection();

                if (_requiredUsers != null && _users.Count == _requiredUsers + 1)
                    StartGame();
            }
        }

        private static void BroadcastConnection() // broadcast all connected users to all clients
        {
            foreach (Client userClient in _users)
            {
                if (userClient.Username == "App Context")
                    continue;

                foreach (Client user in _users)
                {
                    if (user.Username == "App Context")
                        continue;

                    PacketBuilder broadcastPacket = new PacketBuilder();
                    broadcastPacket.WriteOpCode(1);
                    broadcastPacket.WriteMessage(user.Username);
                    broadcastPacket.WriteMessage(user.UID.ToString());
                    userClient.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
                }
            }
        }

        public static void BroadcastMessage(string message)
        {
            foreach (Client user in _users)
            {
                if (user.Username == "App Context")
                    continue;

                PacketBuilder broadcastPacket = new PacketBuilder();
                broadcastPacket.WriteOpCode(5);
                broadcastPacket.WriteMessage(message);
                user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
            }
        }

        public static void BroadcastMove(string move)
        {
            foreach (Client user in _users)
            {
                if (user.Username == "App Context")
                    continue;

                PacketBuilder broadcastPacket = new PacketBuilder();
                broadcastPacket.WriteOpCode(2);
                broadcastPacket.WriteMessage(move);
                user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
            }
        }

        public static void BroadcastDisconnect(Guid uid)
        {
            Client disconnectedUser = _users.Where(user => user.UID == uid).FirstOrDefault();
            if (disconnectedUser == null)
                return;

            _users.Remove(disconnectedUser);
            foreach (Client user in _users)
            {
                if (user.Username == "App Context")
                    continue;

                PacketBuilder broadcastPacket = new PacketBuilder();
                broadcastPacket.WriteOpCode(10);
                broadcastPacket.WriteMessage(uid.ToString());
                user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
            }

            BroadcastMessage($"[{DateTime.Now}]: {disconnectedUser.Username} Disconnected!");
        }

        public static void StartGame()
        {
            Client app = _users.Find(user => user.Username == "App Context");

            PacketBuilder StartPacket = new PacketBuilder();
            StartPacket.WriteOpCode(21);
            StartPacket.WriteMessage("Start Game");
            app.ClientSocket.Client.Send(StartPacket.GetPacketBytes());
        }

        public static void SetRequiredUsers(int count)
            => _requiredUsers = count;
    }
}
