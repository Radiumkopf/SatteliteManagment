using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class PacketInfo
    {
        public byte AES_CRC;
        public bool BROADCAST;
        public bool ACK_TYP;
        public bool ACK_REQ;

        public ulong DestAddr { get; set; }
        public ulong SourceAddr { get; set; }
        public byte retrCount { get; set; }
        public byte payload_lth { get; set; }
        public byte[] message { get; set; }
        public uint ID { get; set; }
        public sbyte rssi { get; set; }
        public sbyte snr { get; set; }


        public byte[] ToByteArray()
        {
            List<byte> fullPackage = new List<byte>();

            byte typecode = AES_CRC;
            if(BROADCAST)
            {
                typecode |= (byte)(1 << 5);
            
            }
            if (ACK_TYP)
            {
                typecode |= (byte)(1 << 6);

            }
            if (ACK_REQ)
            {
                typecode |= (byte)(1 << 7);

            }
            fullPackage.AddRange(BitConverter.GetBytes(DestAddr));
            fullPackage.AddRange(BitConverter.GetBytes(SourceAddr));
            fullPackage.Add(retrCount);
            fullPackage.Add(payload_lth);
            fullPackage.AddRange(message);
            fullPackage.AddRange(BitConverter.GetBytes(ID));
            fullPackage.Add((byte)rssi);
            fullPackage.Add((byte)snr);

            return fullPackage.ToArray();


        }

    }
}
