using SatteliteManagment.Entities.LeafEntities;
using SatteliteManagment.Repositories.LeafRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services.LeafServices
{
    internal class TimeSetService
    {
        private readonly TimeSetRepository _repository;

        public TimeSetService(TimeSetRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(TimeSetEntity entity)
            => _repository.AddAsync(entity);

        public Task<TimeSetEntity> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<List<TimeSetEntity>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<List<TimeSetEntity>> GetLastAsync(int count)
            => _repository.GetLastAsync(count);
        public async Task<TimeSetEntity> GetLastAsync() { var list = await _repository.GetLastAsync(1); return list?.FirstOrDefault(); }
        public Task UpdateAsync(TimeSetEntity entity)
            => _repository.UpdateAsync(entity);

        public Task DeleteAsync(int id)
            => _repository.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id)
            => _repository.ExistsAsync(id);
    }
}
