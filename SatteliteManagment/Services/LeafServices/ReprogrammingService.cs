using SatteliteManagment.Entities.LeafEntities;
using SatteliteManagment.Repositories.LeafRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services.LeafServices
{
    internal class ReprogrammingService
    {
        private readonly ReprogrammingRepository _repository;

        public ReprogrammingService(ReprogrammingRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(ReprogrammingEntity entity)
            => _repository.AddAsync(entity);

        public Task<ReprogrammingEntity> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<List<ReprogrammingEntity>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<List<ReprogrammingEntity>> GetLastAsync(int count)
            => _repository.GetLastAsync(count);

        public Task UpdateAsync(ReprogrammingEntity entity)
            => _repository.UpdateAsync(entity);

        public Task DeleteAsync(int id)
            => _repository.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id)
            => _repository.ExistsAsync(id);
    }
}
