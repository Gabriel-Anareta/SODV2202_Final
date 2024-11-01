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
    }
}
