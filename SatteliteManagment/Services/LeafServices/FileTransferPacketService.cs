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
    internal class FileTransferPacketService
    {
        private readonly FileTransferPacketRepository _repository;

        public FileTransferPacketService(FileTransferPacketRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(FileTransferPacketEntity entity)
            => _repository.AddAsync(entity);

        public Task<FileTransferPacketEntity> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<List<FileTransferPacketEntity>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<List<FileTransferPacketEntity>> GetLastAsync(int count)
            => _repository.GetLastAsync(count);
        public async Task<FileTransferPacketEntity> GetLastAsync() { var list = await _repository.GetLastAsync(1); return list?.FirstOrDefault(); }
        public Task<FileTransferPacketEntity> GetByFileIdAndNumberAsync(byte fileId, ushort number)
        {
            return _repository.GetByFileIdAndNumberAsync(fileId, number);
        }

        public Task UpdateAsync(FileTransferPacketEntity entity)
            => _repository.UpdateAsync(entity);

        public Task DeleteAsync(int id)
            => _repository.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id)
            => _repository.ExistsAsync(id);


    }
}
