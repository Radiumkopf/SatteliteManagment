using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class SatelliteTCPPacket
    {

        // public PacketType Type { get; set; }
        public char symbol { get; set; }
        public byte id { get; set; }
        public short number { get; set; }
        public byte size { get; set; }
        public byte[] data { get; set; }

        public SatelliteTCPPacket(char c,  byte i, short n, byte s, byte[] d) {
            this.symbol = c;
            this.id = i;
            this.number = n;
            this.size = s;
            this.data = d;

        }

        public byte[] ToByteArray()
        {
            List<byte> fullPackage = new List<byte>();

            fullPackage.Add((byte)symbol);
            fullPackage.Add(id);
            fullPackage.AddRange(BitConverter.GetBytes(number));
            fullPackage.Add(size);
            fullPackage.AddRange(data);

            return fullPackage.ToArray();
        }
    }
}
