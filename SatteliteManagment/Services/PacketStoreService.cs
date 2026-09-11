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
    }
}
