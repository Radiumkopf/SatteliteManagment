using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities;
using SatteliteManagment.Entities.LeafEntities;
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
        private readonly AppDbContext _db;

        public PacketStoreService(AppDbContext db)
        {
            _db = db;
        }

        public async Task SaveIncomingPacketAsync<TLeaf>(
            PacketInfoEntity packetInfo,
            PacketType packetType,
            TLeaf leaf)
            where TLeaf : class, IDbEntity, IPacketDescriptionEntity
        {
            var description =
                new PacketDescriptionEntity(packetType);

            leaf.DescriptionEntity = description;

            var radioPacket = new RadioPacketEntity
            {
                PacketInfo = packetInfo,
                PacketDescription = description,
                dateTime = DateTime.Now
            };

            _db.PacketInfos.Add(packetInfo);
            _db.PacketDescriptions.Add(description);
            _db.RadioPackets.Add(radioPacket);
            _db.Set<TLeaf>().Add(leaf);

            await _db.SaveChangesAsync();
        }
        public async Task SavePacketAwaitingAckAsync<TLeaf>(
        PacketType packetType,
        TLeaf leaf)
        where TLeaf : class, IDbEntity, IPacketDescriptionEntity
        {
            var placeholderPacketInfo = new PacketInfoEntity
            {
                //IsPlaceholder = true,

                DestAddr = 0,
                SourceAddr = 0,
                retrCount = 0,
                payload_lth = 0,
                packetID = 0,
                rssi = 0,
                snr = 0
            };

            var description = new PacketDescriptionEntity(packetType);

            leaf.DescriptionEntity = description;

            var radioPacket = new RadioPacketEntity
            {
                PacketInfo = placeholderPacketInfo,
                PacketDescription = description,
                dateTime = DateTime.Now
            };

            _db.PacketInfos.Add(placeholderPacketInfo);
            _db.PacketDescriptions.Add(description);
            _db.RadioPackets.Add(radioPacket);
            _db.Set<TLeaf>().Add(leaf);

            await _db.SaveChangesAsync();
        }

        public async Task ProcessAckAsync(IPacketDescriptionEntity leaf, PacketInfoEntity realPacketInfo)
        {
            var radioPacket = await _db.RadioPackets
                .FirstOrDefaultAsync(x => x.DescriptionId == leaf.DescriptionId);

            if (radioPacket == null)
            {
                throw new InvalidOperationException($"Не найден RadioPacket для DescriptionId={leaf.DescriptionId}");
            }

            var packetInfo = await _db.PacketInfos
                .FirstOrDefaultAsync(x => x.Id == radioPacket.PacketInfoId);

            if (packetInfo == null)
            {
                throw new InvalidOperationException($"Не найден PacketInfo для RadioPacket={radioPacket.Id}");
            }

            UpdatePacketInfo(packetInfo, realPacketInfo);

            //await _db.SaveChangesAsync();
        }

        private static void UpdatePacketInfo( PacketInfoEntity target, PacketInfoEntity source)
        {
            target.AES_CRC = source.AES_CRC;
            target.BROADCAST = source.BROADCAST;
            target.ACK_TYP = source.ACK_TYP;
            target.ACK_REQ = source.ACK_REQ;
            target.DestAddr = source.DestAddr;
            target.SourceAddr = source.SourceAddr;
            target.retrCount = source.retrCount;
            target.payload_lth = source.payload_lth;
            target.packetID = source.packetID;
            target.rssi = source.rssi;
            target.snr = source.snr;

            //target.IsPlaceholder = false;
        }
    }
}
