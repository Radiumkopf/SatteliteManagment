using SatteliteManagment.Entities.LeafEntities;
using SatteliteManagment.Repositories.LeafRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services.LeafServices
{
    internal class ModuleStatusService
    {
        private readonly ModuleStatusRepository _repository;

        public ModuleStatusService(ModuleStatusRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(ModuleStatusEntity entity)
            => _repository.AddAsync(entity);

        public Task<ModuleStatusEntity> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<List<ModuleStatusEntity>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<List<ModuleStatusEntity>> GetLastAsync(int count)
            => _repository.GetLastAsync(count);

        public Task UpdateAsync(ModuleStatusEntity entity)
            => _repository.UpdateAsync(entity);

        public Task DeleteAsync(int id)
            => _repository.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id)
            => _repository.ExistsAsync(id);
    }
}
