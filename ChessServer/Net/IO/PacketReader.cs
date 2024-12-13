using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ChessServer.Net.IO
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
            var bufferLength = ReadInt32();
            messageBuffer = new byte[bufferLength];
            _netStream.Read(messageBuffer, 0, bufferLength);

            return Encoding.ASCII.GetString(messageBuffer);
        }
    }
}
