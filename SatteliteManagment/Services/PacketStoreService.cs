using SatteliteManagment.Entities;
using SatteliteManagment.Repositories;
using SatteliteManagment.Telemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services
{
    internal class PacketStoreService
    {
        //private readonly PacketInfoRepository _packetInfoRepository;

        //public PacketStoreService(PacketInfoRepository packetInfoRepository)
        //{
        //    _packetInfoRepository = packetInfoRepository;
        //}

        //public Task SaveTelemetryAsync(PacketInfo packetInfo, TlmPacket tlmPacket)
        //{
        //    var entity = MapTelemetryGraph(packetInfo, tlmPacket);
        //    return _packetInfoRepository.AddGraphAsync(entity);
        //}

        //public Task SaveFileTransferAsync(PacketInfo packetInfo, FileTransferPacket filePacket)
        //{
        //    var entity = MapFileTransferGraph(packetInfo, filePacket);
        //    return _packetInfoRepository.AddGraphAsync(entity);
        //}

        //private static PacketInfoEntity MapTelemetryGraph(PacketInfo packetInfo, TlmPacket tlmPacket)
        //{
        //    return new PacketInfoEntity
        //    {
        //        AES_CRC = packetInfo.AES_CRC,
        //        BROADCAST = packetInfo.BROADCAST,
        //        ACK_TYP = packetInfo.ACK_TYP,
        //        ACK_REQ = packetInfo.ACK_REQ,
        //        DestAddr = packetInfo.DestAddr,
        //        SourceAddr = packetInfo.SourceAddr,
        //        retrCount = packetInfo.retrCount,
        //        payload_lth = packetInfo.payload_lth,
        //        packetID = packetInfo.ID,
        //        rssi = packetInfo.rssi,
        //        snr = packetInfo.snr,

        //        TlmPacket = new TlmPacketEntity
        //        {
        //            Temperature1 = tlmPacket.Temperature1,
        //            Temperature2 = tlmPacket.Temperature2,
        //            BatteryV = tlmPacket.BatteryV,
        //            PvPower1 = tlmPacket.PvPower[0],
        //            PvPower2 = tlmPacket.PvPower[1],
        //            PvPower3 = tlmPacket.PvPower[2],
        //            AngularRate = tlmPacket.AngularRate,
        //            MagFieldAbs = tlmPacket.MagFieldAbs,
        //            BatChargePower = tlmPacket.BatChargePower,
        //            BatDischargePower = tlmPacket.BatDischargePower,
        //            ResetCounter = tlmPacket.ResetCounter,
        //            StatusFlags = tlmPacket.StatusFlags
        //        }
        //    };
        //}

        //private static PacketInfoEntity MapFileTransferGraph(PacketInfo packetInfo, FileTransferPacket filePacket)
        //{
        //    return new PacketInfoEntity
        //    {
        //        AES_CRC = packetInfo.AES_CRC,
        //        BROADCAST = packetInfo.BROADCAST,
        //        ACK_TYP = packetInfo.ACK_TYP,
        //        ACK_REQ = packetInfo.ACK_REQ,
        //        DestAddr = packetInfo.DestAddr,
        //        SourceAddr = packetInfo.SourceAddr,
        //        retrCount = packetInfo.retrCount,
        //        payload_lth = packetInfo.payload_lth,
        //        packetID = packetInfo.ID,
        //        rssi = packetInfo.rssi,
        //        snr = packetInfo.snr,

        //        FileTransferPacket = new FileTransferPacketEntity
        //        {
        //            Type = filePacket.Type,
        //            FileId = filePacket.id,
        //            Number = filePacket.number,
        //            Size = filePacket.size,
        //            Data = filePacket.data ?? Array.Empty<byte>()
        //        }
        //    };
        //}
    }
}
