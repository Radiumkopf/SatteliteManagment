using SatteliteManagment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities
{
    internal class PacketInfoEntity : IDbEntity
    {
        public int Id { get; set; }
        public byte AES_CRC { get; set; }
        public bool BROADCAST { get; set; }
        public bool ACK_TYP { get; set; }
        public bool ACK_REQ { get; set; }

        public ulong DestAddr { get; set; }
        public ulong SourceAddr { get; set; }
        public byte retrCount { get; set; }
        public byte payload_lth { get; set; }
        //public byte[] message { get; set; }
        public uint packetID { get; set; }
        public sbyte rssi { get; set; }
        public sbyte snr { get; set; }

        public DateTime dateTime = DateTime.Now;

        //не уверен
        public TlmPacketEntity TlmPacket { get; set; }
        public FileTransferPacketEntity FileTransferPacket { get; set; }

        public byte[] ToBytes()
        {
            PacketInfo packetInfo = PacketInfoService.MapToModel(this);
            return packetInfo.ToByteArray();
        }
    }
}
