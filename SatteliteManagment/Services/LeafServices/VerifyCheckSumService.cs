using SatteliteManagment.Entities.LeafEntities;
using SatteliteManagment.Repositories.LeafRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services.LeafServices
{
    internal class VerifyCheckSumService
    {
        private readonly VerifyCheckSumRepository _repository;

        public VerifyCheckSumService(VerifyCheckSumRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(VerifyCheckSumEntity entity)
            => _repository.AddAsync(entity);

        public Task<VerifyCheckSumEntity> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<List<VerifyCheckSumEntity>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<List<VerifyCheckSumEntity>> GetLastAsync(int count)
            => _repository.GetLastAsync(count);
        public async Task<VerifyCheckSumEntity> GetLastAsync() { var list = await _repository.GetLastAsync(1); return list?.FirstOrDefault(); }
        public Task UpdateAsync(VerifyCheckSumEntity entity)
            => _repository.UpdateAsync(entity);

        public Task DeleteAsync(int id)
            => _repository.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id)
            => _repository.ExistsAsync(id);
    }
}
