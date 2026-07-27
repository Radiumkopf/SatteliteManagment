using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class RawPacket
    {

        public short Number { get; }

        public byte[] Data { get; }

        public bool IsSent { get; set; }

        public bool IsAckReceived { get; set; }

        public RawPacket(short number, byte[] data)
        {
            Number = number;
            Data = data;
        }
    }
}
