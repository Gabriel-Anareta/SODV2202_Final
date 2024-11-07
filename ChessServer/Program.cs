using ChessServer.Net.IO;
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
            }
        }

        private static void BroadcastConnection() // broadcast all connected users to all clients
        {
            foreach (Client userClient in _users)
            {
                foreach (Client user in _users)
                {
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
                PacketBuilder broadcastPacket = new PacketBuilder();
                broadcastPacket.WriteOpCode(5);
                broadcastPacket.WriteMessage(message);
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
                PacketBuilder broadcastPacket = new PacketBuilder();
                broadcastPacket.WriteOpCode(10);
                broadcastPacket.WriteMessage(uid.ToString());
                user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
            }

            BroadcastMessage($"[{DateTime.Now}]: {disconnectedUser.Username} Disconnected!");
        }
    }
}
