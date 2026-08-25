using SatteliteManagment.Services;
using SatteliteManagment.Telemetry;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities
{
    internal class TlmPacketEntity : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public int DescriptionId { get; set; }
        public PacketDescriptionEntity DescriptionEntity { get; set; }


        public float Temperature1 { get; set; }
        public float Temperature2 { get; set; }
        public float BatteryV { get; set; }

        public float PvPower1 { get; set; }
        public float PvPower2 { get; set; }
        public float PvPower3 { get; set; }

        public float AngularRate { get; set; }
        public float MagFieldAbs { get; set; }

        public float BatChargePower { get; set; }
        public float BatDischargePower { get; set; }

        public byte ResetCounter { get; set; }
        public uint StatusFlags { get; set; }

        public byte[] ToBytes()
        {
            TlmPacket tlmPacket = TlmPacketService.MapToModel(this);
            return tlmPacket.ToByteArray();
        }
    }
}
