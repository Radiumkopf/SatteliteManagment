using SatteliteManagment.Entities.LeafEntities;
using SatteliteManagment.Repositories.LeafRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services.LeafServices
{
    internal class MotorSpeedService
    {
        private readonly MotorSpeedRepository _repository;

        public MotorSpeedService(MotorSpeedRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(MotorSpeedEntity entity)
            => _repository.AddAsync(entity);

        public Task<MotorSpeedEntity> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<List<MotorSpeedEntity>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<List<MotorSpeedEntity>> GetLastAsync(int count)
            => _repository.GetLastAsync(count);
        public async Task<MotorSpeedEntity> GetLastAsync() { var list = await _repository.GetLastAsync(1); return list?.FirstOrDefault(); }
        public Task UpdateAsync(MotorSpeedEntity entity)
            => _repository.UpdateAsync(entity);

        public Task DeleteAsync(int id)
            => _repository.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id)
            => _repository.ExistsAsync(id);
    }
}
