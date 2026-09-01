using SatteliteManagment.Entities;
using SatteliteManagment.Entities.LeafEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
        public enum PacketType : byte
        {
            TimeSet = 0x0A,
            FileSending = 0x0B,
            FileRequesting = 0x0C,
            VerifyCheckSum = 0x0E,
            ReprogrammingStart = 0x0F,
            GetModuleStatus = 0x07,
            SetCoilMagnetMoment = 0x08,
            SetMotorSpeed = 0x09,


            TimeSetAck = 0x1A,
            FileSendingAck = 0x1B,
            FileSendingNack = 0x2B,
            VerifyCheckSumAck = 0x1E,

            ReprogrammingStartACK = 0x1F,
            ReprogrammingStartNACK = 0x2F,

            FileRequestingAck = 0x1C,
            FileRequestingLast = 0x2C,
            ModuleStatus = 0x17,
            SetCoilMagnetMomentAck = 0x18, 
            SetCoilMagnetMomentNack = 0x28,
            SetMotorSpeedAck = 0x19,
            SetMotorSpeedNack = 0x29,
            Telemetry = 0x1D,

            AddressChanging = 0xAC

        }

        internal class FileTransferPacket : IDataConvertable
        {
            public PacketType Type { get; set; }
            public byte id { get; set; }
            public ushort number { get; set; }
            public byte size { get; set; }
            public byte[] data { get; set; }

            public FileTransferPacket()
            {

            }
            public FileTransferPacket(PacketType type,  byte _id, ushort _number, byte _size, byte[] _data) {
                this.Type = type;

                this.id = _id;
                this.number = _number;
                this.size = _size;
                this.data = _data;

            }

            public byte[] ToByteArray()
            {
                List<byte> fullPackage = new List<byte>();

            
                fullPackage.Add((byte)Type);
                fullPackage.Add(id);
                fullPackage.AddRange(BitConverter.GetBytes(number));
                fullPackage.Add(size);
                fullPackage.AddRange(data);

                return fullPackage.ToArray();
            }

            public static FileTransferPacketEntity MapToSendEntity(FileTransferPacket packet)
            {
                return new FileTransferPacketEntity
                (
                    packet.id,
                    packet.number,
                    packet.size,
                    packet.data ?? System.Array.Empty<byte>()
                );
            }

            public static FileTransferPacket MapToModel(FileTransferPacketEntity entity)
            {
                return new FileTransferPacket
                {
                    id = entity.FileId,
                    number = entity.Number,
                    size = entity.Size,
                    data = entity.Data ?? System.Array.Empty<byte>()
                };
            }
            public static FileRequestEntity MapToRequestEntity(FileTransferPacket packet)
            {
                return new FileRequestEntity
                (
                    packet.id,
                    packet.number,
                    packet.size,
                    packet.data ?? System.Array.Empty<byte>()
                );
            }

            public static FileTransferPacket MapToModel(FileRequestEntity entity)
            {
                return new FileTransferPacket
                {
                    id = entity.FileId,
                    number = entity.Number,
                    size = entity.Size,
                    data = entity.Data ?? System.Array.Empty<byte>()
                };
            }
    }
}
