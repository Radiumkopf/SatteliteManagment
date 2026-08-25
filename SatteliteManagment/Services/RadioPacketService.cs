using SatteliteManagment.Entities;
using SatteliteManagment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services
{
    internal class RadioPacketService
    {
        private readonly RadioPacketRepository _repository;

        public RadioPacketService(RadioPacketRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(RadioPacketEntity entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task<RadioPacketEntity> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<List<RadioPacketEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<List<RadioPacketEntity>> GetLastAsync(int count)
        {
            return _repository.GetLastAsync(count);
        }

        public Task UpdateAsync(RadioPacketEntity entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}
