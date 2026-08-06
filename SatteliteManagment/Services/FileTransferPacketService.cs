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
    internal class FileTransferPacketService
    {
        private readonly FileTransferPacketRepository _repository;

        public FileTransferPacketService(FileTransferPacketRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(FileTransferPacket packet)
        {
            FileTransferPacketEntity entity = MapToEntity(packet);
            return _repository.AddAsync(entity);
        }

        public async Task<FileTransferPacket> GetByDbIdAsync(int id)
        {
            FileTransferPacketEntity entity = await _repository.GetByDbIdAsync(id);
            return entity == null ? null : MapToModel(entity);
        }

        public async Task<List<FileTransferPacket>> GetAllAsync()
        {
            List<FileTransferPacketEntity> entities = await _repository.GetAllAsync();
            return entities.Select(MapToModel).ToList();
        }

        public async Task<List<FileTransferPacket>> GetByFileIdAsync(byte fileId)
        {
            List<FileTransferPacketEntity> entities = await _repository.GetByFileIdAsync(fileId);
            return entities.Select(MapToModel).ToList();
        }

        public async Task<List<FileTransferPacket>> GetByTypeAsync(PacketType type)
        {
            List<FileTransferPacketEntity> entities = await _repository.GetByTypeAsync(type);
            return entities.Select(MapToModel).ToList();
        }
        public async Task<List<FileTransferPacket>> GetLastAsync(int count)
        {
            List<FileTransferPacketEntity> entities = await _repository.GetLastAsync(count);
            return entities.Select(MapToModel).ToList();
        }

        private static FileTransferPacketEntity MapToEntity(FileTransferPacket packet)
        {
            return new FileTransferPacketEntity
            {
                Type = packet.Type,
                FileId = packet.id,
                Number = packet.number,
                Size = packet.size,
                Data = packet.data ?? System.Array.Empty<byte>()
            };
        }

        private static FileTransferPacket MapToModel(FileTransferPacketEntity entity)
        {
            return new FileTransferPacket
            {
                Type = entity.Type,
                id = entity.FileId,
                number = entity.Number,
                size = entity.Size,
                data = entity.Data ?? System.Array.Empty<byte>()
            };
        }
    }
}
