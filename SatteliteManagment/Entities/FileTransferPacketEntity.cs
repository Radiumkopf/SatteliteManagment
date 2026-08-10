using SatteliteManagment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities
{
    internal class FileTransferPacketEntity : IDbEntity
    {

        public int Id { get; set; }          // PK базы данных

        public int PacketInfoId { get; set; }
        public PacketInfoEntity PacketInfo { get; set; }

        public PacketType Type { get; set; }
        public byte FileId { get; set; }     
        public ushort Number { get; set; }
        public byte Size { get; set; }
        public byte[] Data { get; set; } = Array.Empty<byte>();

        public byte[] ToBytes()
        {
            FileTransferPacket ftp = FileTransferPacketService.MapToModel(this);
            return ftp.ToByteArray();
        }
    }
}
