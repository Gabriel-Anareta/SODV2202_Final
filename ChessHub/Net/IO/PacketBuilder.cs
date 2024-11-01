using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClient.Net.IO
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

        public void WriteString(string message)
        {
            int messageLength = message.Length;
            _memStream.Write(BitConverter.GetBytes(messageLength)); // reserve 4 bytes for message length
            _memStream.Write(Encoding.ASCII.GetBytes(message)); // write message to packet
        }

        public byte[] GetPacketBytes()
        {
            return _memStream.ToArray();
        }
    }
}
