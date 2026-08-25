using SatteliteManagment.Entities;
using SatteliteManagment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services
{
    internal class PacketDescriptionService
    {
        private readonly PacketDescriptionRepository _repository;

        public PacketDescriptionService(PacketDescriptionRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(PacketDescriptionEntity entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task<PacketDescriptionEntity> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<List<PacketDescriptionEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<List<PacketDescriptionEntity>> GetLastAsync(int count)
        {
            return _repository.GetLastAsync(count);
        }

        public Task UpdateAsync(PacketDescriptionEntity entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}
