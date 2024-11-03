using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChessClient.Net.IO
{
    public class PacketReader : BinaryReader
    {
        private NetworkStream _netStream;

        public PacketReader(NetworkStream ns) : base(ns)
        {
            _netStream = ns;
        }

        public string ReadMessage()
        {
            byte[] messageBuffer;
            int bufferLength = ReadInt32();
            messageBuffer = new byte[bufferLength];
            _netStream.Read(messageBuffer, 0, bufferLength);

            return Encoding.ASCII.GetString(messageBuffer);
        }
    }
}
