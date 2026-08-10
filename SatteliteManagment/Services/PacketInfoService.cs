using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities;
using SatteliteManagment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services
{
    internal class PacketInfoService
    {

        private readonly PacketInfoRepository _repository;

        public PacketInfoService(PacketInfoRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(PacketInfo packetInfo)
        {
            PacketInfoEntity entity = MapToEntity(packetInfo);
            return _repository.AddAsync(entity);
        }

        public async Task<PacketInfo> GetByIdAsync(int id)
        {
            PacketInfoEntity entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToModel(entity);
        }

        public async Task<List<PacketInfo>> GetAllAsync()
        {
            List<PacketInfoEntity> entities = await _repository.GetAllAsync();
            return entities.Select(MapToModel).ToList();
        }

        public async Task<List<PacketInfo>> GetLastAsync(int count)
        {
            List<PacketInfoEntity> entities = await _repository.GetLastAsync(count);
            return entities.Select(MapToModel).ToList();
        }

        public static PacketInfoEntity MapToEntity(PacketInfo packet)
        {
            return new PacketInfoEntity
            {
                AES_CRC = packet.AES_CRC,
                BROADCAST = packet.BROADCAST,
                ACK_TYP = packet.ACK_TYP,
                ACK_REQ = packet.ACK_REQ,
                DestAddr = packet.DestAddr,
                SourceAddr = packet.SourceAddr,
                retrCount = packet.retrCount,
                payload_lth = packet.payload_lth,
                packetID = packet.ID,
                rssi = packet.rssi,
                snr = packet.snr
            };
        }

        public static PacketInfo MapToModel(PacketInfoEntity entity)
        {
            return new PacketInfo
            {
                AES_CRC = entity.AES_CRC,
                BROADCAST = entity.BROADCAST,
                ACK_TYP = entity.ACK_TYP,
                ACK_REQ = entity.ACK_REQ,
                DestAddr = entity.DestAddr,
                SourceAddr = entity.SourceAddr,
                retrCount = entity.retrCount,
                payload_lth = entity.payload_lth,
                ID = entity.packetID,
                rssi = entity.rssi,
                snr = entity.snr
            };
        }
    }
}
