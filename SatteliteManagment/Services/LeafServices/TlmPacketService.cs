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
    internal class TlmPacketService
    {
        private readonly TlmPacketRepository _repository;

        public TlmPacketService(TlmPacketRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(TlmPacketEntity entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task<TlmPacketEntity> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<List<TlmPacketEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<List<TlmPacketEntity>> GetLastAsync(int count)
        {
            return _repository.GetLastAsync(count);
        }

        public Task UpdateAsync(TlmPacketEntity entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<bool> ExistsAsync(int id)
        {
            return _repository.ExistsAsync(id);
        }


        
    }
}
