using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class RawPacket
    {

        public ushort Number { get; }

        public byte[] Data { get; }

        public bool IsSent { get; set; }

        public bool IsAckReceived { get; set; }

        public RawPacket(ushort number, byte[] data)
        {
            Number = number;
            Data = data;
        }
    }
}
