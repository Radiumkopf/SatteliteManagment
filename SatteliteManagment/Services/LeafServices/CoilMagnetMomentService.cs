using SatteliteManagment.Entities.LeafEntities;
using SatteliteManagment.Repositories.LeafRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services.LeafServices
{
    internal class CoilMagnetMomentService
    {
        private readonly CoilMagnetMomentRepository _repository;

        public CoilMagnetMomentService(CoilMagnetMomentRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(CoilMagnetMomentEntity entity)
            => _repository.AddAsync(entity);

        public Task<CoilMagnetMomentEntity> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<List<CoilMagnetMomentEntity>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<List<CoilMagnetMomentEntity>> GetLastAsync(int count)
            => _repository.GetLastAsync(count);
        public async Task<CoilMagnetMomentEntity> GetLastAsync() { var list = await _repository.GetLastAsync(1); return list?.FirstOrDefault(); }

        public Task UpdateAsync(CoilMagnetMomentEntity entity)
            => _repository.UpdateAsync(entity);

        public Task DeleteAsync(int id)
            => _repository.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id)
            => _repository.ExistsAsync(id);
    }
}
