using System;
using System.IO;
using System.Text;

namespace ChessServer.Net.IO
{
    public class PacketBuilder
    {
        private MemoryStream _memStream;

        public PacketBuilder()
        {
            _memStream = new MemoryStream();
        }

        public void WriteOpCode(byte opCode) // used byte instead of int - no need for more than 255 opCodes
        {
            _memStream.WriteByte(opCode); // reserve 1 byte for opCode
        }

        public void WriteMessage(string message)
        {
            int messageLength = message.Length;
            byte[] lengthBytes = BitConverter.GetBytes(messageLength);
            _memStream.Write(lengthBytes, 0, lengthBytes.Length); // reserve 4 bytes for message length
            _memStream.Write(Encoding.ASCII.GetBytes(message), 0, messageLength); // write message to packet
        }

        public byte[] GetPacketBytes()
        {
            return _memStream.ToArray();
        }
    }
}
