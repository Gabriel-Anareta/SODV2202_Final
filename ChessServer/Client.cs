using ChessServer.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChessServer
{
    public class Client
    {
        public string Username { get; set; }
        public Guid UID { get; set; }
        public TcpClient ClientSocket { get; set; }

        private PacketReader _packetReader;

        public Client(TcpClient client)
        {
            ClientSocket = client;
            UID = Guid.NewGuid();

            _packetReader = new PacketReader(ClientSocket.GetStream());
            byte opCode = _packetReader.ReadByte();
            // need to implement validation of opCode 
            Username = _packetReader.ReadMessage();

            Console.WriteLine($"[{DateTime.Now}]: Client has connected with the username: {Username}");

            Task.Run(() => ProcessPackets());
        }

        private void ValidateOpCode()
        {
            throw new NotImplementedException();
        }

        private void ProcessPackets()
        {
            while (true)
            {
                try
                {
                    byte opCode = _packetReader.ReadByte();
                    switch (opCode)
                    {
                        case 2:
                            string move = _packetReader.ReadMessage();
                            Console.WriteLine($"[{DateTime.Now}]: {move}");
                            Program.BroadcastMove(move);
                            break;
                        case 5:
                            string message = _packetReader.ReadMessage();
                            Console.WriteLine($"[{DateTime.Now}]: {Username} sent message: {message}");
                            Program.BroadcastMessage(message);
                            break;
                        case 10:
                            Console.WriteLine($"[{DateTime.Now}]: {UID} Disconnected!");
                            Program.BroadcastDisconnect(UID);
                            ClientSocket.Close();
                            break;
                        case 20:
                            string requiredUsers = _packetReader.ReadMessage();
                            Console.WriteLine($"[{DateTime.Now}]: Required Users set to {requiredUsers}");
                            Program.SetRequiredUsers(int.Parse(requiredUsers));
                            break;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine($"[{DateTime.Now}]: {UID} Disconnected!");
                    Program.BroadcastDisconnect(UID);
                    ClientSocket.Close();
                }
            }
        }
    }
}
